using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
//using Microsoft.Extensions.Http;
using System.Security;
using NBitcoin;
using Tatum.Blockchain;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

/// <summary>
/// Summary description for DogeClient
/// </summary>
/// 
namespace Tatum
{
    public class DogeClient : IDogecoinClient
    {
        private readonly string _privateKey;
        private readonly string _serverUrl;
        public DogeClient(string privateKey, string serverUrl)
        {
            _privateKey = privateKey;
            _serverUrl = serverUrl;
        }




        Wallets IDogecoinClient.CreateWallet(string mnemonic, bool testnet)
        {
            var xPub = new Mnemonic(mnemonic)
                .DeriveExtKey()
                .Derive(new KeyPath(testnet ? Constants.TestKeyDerivationPath : Constants.DogeKeyDerivationPath))
                .Neuter();

            return new Wallets
            {
                Mnemonic = mnemonic,
                XPub = xPub.ToString(testnet ? Network.TestNet : Network.Main)
            };
        }

        string IDogecoinClient.GeneratePrivateKey(string mnemonic, int index, bool testnet)
        {
            return new Mnemonic(mnemonic)
                .DeriveExtKey()
                .Derive(new KeyPath(testnet ? Constants.TestKeyDerivationPath : Constants.DogeKeyDerivationPath))
                .Derive(Convert.ToUInt32(index))
                .PrivateKey
                .GetWif(testnet ? Network.TestNet : Network.Main)
                .ToString();
        }

        string IDogecoinClient.GenerateAddress(string xPubString, int index, bool testnet)
        {
            return ExtPubKey.Parse(xPubString, testnet ? Network.TestNet : Network.Main)
                .Derive(Convert.ToUInt32(index))
                .PubKey
                .GetAddress(ScriptPubKeyType.Legacy, testnet ? Network.TestNet : Network.Main)
                .ToString();
        }


      


        public async Task<Dogecoin> GetDogecoinBlockchainInfo()
        {


            var stringResult = await GetSecureRequest($"info");

            var result = JsonConvert.DeserializeObject<Dogecoin>(stringResult);

            return result;
        }



        public async Task<Dogecoin> GetDogecoinBlockHash(int i)
        {


            var stringResult = await GetSecureRequest($"block/hash/{i}");

            var result = JsonConvert.DeserializeObject<Dogecoin>(stringResult);

            return result;
        }


        public async Task<Dogecoin> GetDogecoinBlockByHash(string hash)
        {


            var stringResult = await GetSecureRequest($"block/{hash}");

            var result = JsonConvert.DeserializeObject<Dogecoin>(stringResult);

            return result;
        }



        public async Task<Dogecoin> GetDogecoinTransactionByHash(string hash)
        {


            var stringResult = await GetSecureRequest($"transaction/{hash}");

            var result = JsonConvert.DeserializeObject<Dogecoin>(stringResult);

            return result;
        }


        public async Task<List<Dogecoin>> GetMempoolTransactions()
        {


            var stringResult = await GetSecureRequest($"mempool");

            var result = JsonConvert.DeserializeObject<List<Dogecoin>>(stringResult);

            return result;
        }


        public Task<List<DogecoinTx>> GetTxForAccount(string address, int pageSize = 50, int offset = 0)
        {

            throw new NotImplementedException();

        }


        public async Task<List<Dogecoin>> GetDogecoinUTXOTransaction(string hash, int index)
        {


            var stringResult = await GetSecureRequest($"utxo/{hash}/{index}");

            var result = JsonConvert.DeserializeObject<List<Dogecoin>>(stringResult);

            return result;
        }


        



        public Task<DogecoinUtxo> GetUtxo(string txHash, int txOutputIndex)
        {

            throw new NotImplementedException();

        }

        public Task<TransactionHash> BroadcastSignedTransaction(BroadcastRequest request)
        {
            throw new NotImplementedException();
        }









        Task<string> IDogecoinClient.SignKmsTransaction(TransactionKms tx, List<string> privateKeys, bool testnet)
        {
            throw new NotImplementedException();
        }

        Task<string> IDogecoinClient.PrepareSignedTransaction(TransferBtcBasedBlockchain body, bool testnet)
        {
            return PrepareSignedTransaction(testnet ? LitecoinTatum.Instance.Testnet : LitecoinTatum.Instance.Mainnet, body);
        }

        async Task<TransactionHash> IDogecoinClient.SendTransaction(TransferBtcBasedBlockchain body, bool testnet)
        {
            string txData = await (this as IDogecoinClient).PrepareSignedTransaction(body, testnet).ConfigureAwait(false);
            var broadcastRequest = new BroadcastRequest
            {
                TxData = txData
            };

            return await (this as IDogecoinClient).BroadcastSignedTransaction(broadcastRequest).ConfigureAwait(false);
        }

        private async Task<string> PrepareSignedTransaction(Network network, TransferBtcBasedBlockchain body)
        {
            var validationContext = new ValidationContext(body);
            Validator.ValidateObject(body, validationContext);

            NBitcoin.Transaction transaction = network.CreateTransaction();
            List<BitcoinSecret> privateKeysToSign = new List<BitcoinSecret>();
            List<Coin> coinsToSpent = new List<Coin>();

            if (body.FromAddresses != null)
            {
                foreach (FromAddress fromAddress in body.FromAddresses)
                {
                    List<DogecoinTx> inputTxes = await (this as IDogecoinClient).GetTxForAccount(fromAddress.Address).ConfigureAwait(false);
                    foreach (DogecoinTx inputTx in inputTxes)
                    {
                        for (int i = 0; i < inputTx.Outputs.Count; i++)
                        {
                            if (inputTx.Outputs[i].Address == fromAddress.Address)
                            {
                                var secret = new BitcoinSecret(fromAddress.PrivateKey, network);
                                try
                                {
                                    DogecoinUtxo utxo = await (this as IDogecoinClient).GetUtxo(inputTx.Hash, i).ConfigureAwait(false);

                                    TxIn input = GetInputFromUtxo(secret, utxo, privateKeysToSign, coinsToSpent);
                                    transaction.Inputs.Add(input);
                                }
                                catch (Exception)
                                {
                                    // spent, unconfirmed or invalid utxos
                                }
                            }
                        }
                    }
                }
            }

            if (body.FromUtxos != null)
            {
                foreach (FromUtxo fromUtxo in body.FromUtxos)
                {
                    var secret = new BitcoinSecret(fromUtxo.PrivateKey, network);

                    try
                    {
                        DogecoinUtxo utxo = await (this as IDogecoinClient).GetUtxo(fromUtxo.TxHash, (int)fromUtxo.Index).ConfigureAwait(false);

                        TxIn input = GetInputFromUtxo(secret, utxo, privateKeysToSign, coinsToSpent);
                        transaction.Inputs.Add(input);
                    }
                    catch (Exception)
                    {
                        // spent, unconfirmed or invalid utxos
                    }
                }
            }

            foreach (Tox to in body.Tos)
            {
                var outputAddress = BitcoinAddress.Create(to.Address, network);
                transaction.Outputs.Add(new Money(to.Value, MoneyUnit.BTC), outputAddress.ScriptPubKey);
            }

            transaction.Sign(privateKeysToSign, coinsToSpent);

            return transaction.ToHex();
        }

        private TxIn GetInputFromUtxo(BitcoinSecret secret, DogecoinUtxo utxo, List<BitcoinSecret> privateKeysToSign, List<Coin> coinsToSpent)
        {
            uint256 transactionId = uint256.Parse(utxo.Hash);
            var outpoint = new OutPoint(transactionId, (uint)utxo.Index);

            privateKeysToSign.Add(secret);
            var scriptSig = secret.GetAddress(ScriptPubKeyType.Legacy).ScriptPubKey;

            var coinToSpent = new Coin(transactionId, (uint)utxo.Index, Money.Satoshis(utxo.Value), scriptSig);
            coinsToSpent.Add(coinToSpent);

            return new TxIn(outpoint, scriptSig);
        }




























































        private async Task<string> GetSecureRequest(string path, Dictionary<string, string> paramaters = null)
        {
            var baseUrl = serverUrl + "/v3/dogecoin";

            baseUrl = $"{baseUrl}/{path}";


            HttpWebRequest reqc = (HttpWebRequest)WebRequest.Create(baseUrl);

            reqc.Method = "GET";
            reqc.Headers.Add("x-api-key", _privateKey);
            reqc.Credentials = CredentialCache.DefaultCredentials;
            reqc.ContentType = "application/json";




            try
            {
                HttpWebResponse httpResponse = (HttpWebResponse)(await reqc.GetResponseAsync());
                string json;
                using (Stream responseStream = httpResponse.GetResponseStream())
                {
                    json = new StreamReader(responseStream).ReadToEnd();
                }

                return json;
            }
            catch (Exception ex)
            {
                throw new SecurityException("Bad credentials", ex);
            }
        }


        private async Task<string> PostSecureRequest(string path, string parameters)
        {

            var baseUrl = serverUrl + "/v3/dogecoin";

            baseUrl = $"{baseUrl}/{path}";


            HttpWebRequest reqc = (HttpWebRequest)WebRequest.Create(baseUrl);

            reqc.Method = "POST";
            reqc.Headers.Add("x-api-key", _privateKey);
            reqc.Credentials = CredentialCache.DefaultCredentials;
            reqc.ContentType = "multipart/form-data";

            using (var streamWriter = new StreamWriter(reqc.GetRequestStream()))
            {

                streamWriter.Write(parameters);
            }


            try
            {
                HttpWebResponse httpResponse = (HttpWebResponse)(await reqc.GetResponseAsync());
                string json;
                using (Stream responseStream = httpResponse.GetResponseStream())
                {
                    json = new StreamReader(responseStream).ReadToEnd();
                }

                return json;
            }
            catch (Exception ex)
            {
                throw new SecurityException("Bad credentials", ex);
            }

        }


        private async Task<string> PUTSecureRequest(string path, string parameters)
        {

            var baseUrl = serverUrl + "/v3/dogecoin";

            baseUrl = $"{baseUrl}/{path}";


            HttpWebRequest reqc = (HttpWebRequest)WebRequest.Create(baseUrl);

            reqc.Method = "PUT";
            reqc.Headers.Add("x-api-key", _privateKey);
            reqc.Credentials = CredentialCache.DefaultCredentials;
            reqc.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(reqc.GetRequestStream()))
            {

                streamWriter.Write(parameters);
            }


            try
            {
                HttpWebResponse httpResponse = (HttpWebResponse)(await reqc.GetResponseAsync());
                string json;
                using (Stream responseStream = httpResponse.GetResponseStream())
                {
                    json = new StreamReader(responseStream).ReadToEnd();
                }

                return json;
            }
            catch (Exception ex)
            {
                throw new SecurityException("Bad credentials", ex);
            }

        }

        private async Task<string> DeleteSecureRequest(string path, Dictionary<string, string> paramaters = null)
        {
            var baseUrl = serverUrl + "/v3/dogecoin";

            baseUrl = $"{baseUrl}/{path}";


            HttpWebRequest reqc = (HttpWebRequest)WebRequest.Create(baseUrl);

            reqc.Method = "DELETE";
            reqc.Headers.Add("x-api-key", _privateKey);
            reqc.Credentials = CredentialCache.DefaultCredentials;
            reqc.ContentType = "application/json";




            try
            {
                HttpWebResponse httpResponse = (HttpWebResponse)(await reqc.GetResponseAsync());
                string json;
                using (Stream responseStream = httpResponse.GetResponseStream())
                {
                    json = new StreamReader(responseStream).ReadToEnd();
                }

                return json;
            }
            catch (Exception ex)
            {
                throw new SecurityException("Bad credentials", ex);
            }
        }





















    }
}
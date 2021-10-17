using System;
using System.Collections.Generic;
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
using Tatum.Model.Requests;
using Tatum.Model.Responses;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Summary description for QtumClient
/// </summary>
namespace Tatum
{
    public class QtumClient:IQtumClient
    {



        private readonly string _privateKey;
        public QtumClient(string privateKey)
        {
            _privateKey = privateKey;
        }





        Wallets IQtumClient.CreateWallet(string mnemonic, bool testnet)
        {
            var xPub = new Mnemonic(mnemonic)
                .DeriveExtKey()
                .Derive(new KeyPath(testnet ? Constants.TestKeyDerivationPath : Constants.QtumKeyDerivationPath))
                .Neuter();

            return new Wallets
            {
                Mnemonic = mnemonic,
                XPub = xPub.ToString(testnet ? Network.TestNet : Network.Main)
            };
        }

        string IQtumClient.GeneratePrivateKey(string mnemonic, int index, bool testnet)
        {
            return new Mnemonic(mnemonic)
                .DeriveExtKey()
                .Derive(new KeyPath(testnet ? Constants.TestKeyDerivationPath : Constants.QtumKeyDerivationPath))
                .Derive(Convert.ToUInt32(index))
                .PrivateKey
                .GetWif(testnet ? Network.TestNet : Network.Main)
                .ToString();
        }

        string IQtumClient.GenerateAddress(string xPubString, int index, bool testnet)
        {
            return ExtPubKey.Parse(xPubString, testnet ? Network.TestNet : Network.Main)
                .Derive(Convert.ToUInt32(index))
                .PubKey
                .GetAddress(ScriptPubKeyType.Legacy, testnet ? Network.TestNet : Network.Main)
                .ToString();
        }




      

        public async Task<QTUM> Web3HttpDriver(string xapikey)
        {
            string parameters = "{\"jsonrpc\":\"2.0\",\"method\":\"web3_clientVersion\",\"params\":[],\"id\":2}";

            var stringResult = await PostSecureRequest($"web3/{xapikey}", parameters);

            var result = JsonConvert.DeserializeObject<QTUM>(stringResult);

            return result;
        }


        public async Task<QTUM> GetCurrentBlockNumber()
        {

            var stringResult = await GetSecureRequest($"block/current");

            var result = JsonConvert.DeserializeObject<QTUM>(stringResult);

            return result;
        }

        public async Task<QTUM> GetQtumBlockByHash(string hash)
        {

            var stringResult = await GetSecureRequest($"block/{hash}");

            var result = JsonConvert.DeserializeObject<QTUM>(stringResult);

            return result;
        }

      

        public async Task<QTUM> GetUTXO(string address)
        {

            var stringResult = await GetSecureRequest($"utxo/{address}");

            var result = JsonConvert.DeserializeObject<QTUM>(stringResult);

            return result;
        }

        public async Task<QTUM> GetQtumAccountBalance(string address)
        {

            var stringResult = await GetSecureRequest($"balance/{address}");

            var result = JsonConvert.DeserializeObject<QTUM>(stringResult);

            return result;
        }

        public async Task<QTUM> GetQtumTransaction(string id)
        {

            var stringResult = await GetSecureRequest($"transaction/{id}");

            var result = JsonConvert.DeserializeObject<QTUM>(stringResult);

            return result;
        }

        public async Task<QTUM> GetQtumTransactionsByAddress(string address, int pageSize = 50, int offset = 0)
        {

            var stringResult = await GetSecureRequest($"transactions/address/{address}/?pageSize=20&offset=0");

            var result = JsonConvert.DeserializeObject<QTUM>(stringResult);

            return result;
        }


        public async Task<QTUM> GetQtumEstimatedGasFees(string nblocks)
        {

            var stringResult = await GetSecureRequest($"transactions/gas/{nblocks}");

            var result = JsonConvert.DeserializeObject<QTUM>(stringResult);

            return result;
        }

        public async Task<QTUM> GetQtumEstimatedGasFeesByte(string nblocks)
        {

            var stringResult = await GetSecureRequest($"transactions/gasbytes/{nblocks}");

            var result = JsonConvert.DeserializeObject<QTUM>(stringResult);

            return result;
        }



     


        public async Task<TransactionHash> Broadcast(BroadcastRequest request)
        {
            string parameters = "{\"txData\":" + "\"" + request.TxData + "" + "\",\"signatureId\":" + "\"" + request.SignatureId + "" + "\"}";

            var stringResult = await PostSecureRequest($"broadcast", parameters);

            var result = JsonConvert.DeserializeObject<TransactionHash>(stringResult);

            return result;
        }



        public Task<BitcoinUtxo> GetUtxo(string txHash, int txOutputIndex)
        {
            throw new NotImplementedException();
        }

        public Task<List<BitcoinTx>> GetTxForAccount(string address, int pageSize = 50, int offset = 0)
        {
            throw new NotImplementedException();
        }

        Task<string> IQtumClient.SignKmsTransaction(TransactionKms tx, List<string> privateKeys, bool testnet)
        {
            throw new NotImplementedException();
        }

        Task<string> IQtumClient.PrepareSignedTransaction(TransferBtcBasedBlockchain body, bool testnet)
        {
            return PrepareSignedTransaction(testnet ? Network.TestNet : Network.Main, body);
        }

        async Task<TransactionHash> IQtumClient.SendTransaction(TransferBtcBasedBlockchain body, bool testnet)
        {
            string txData = await (this as IBitcoinClient).PrepareSignedTransaction(body, testnet).ConfigureAwait(false);
            var broadcastRequest = new BroadcastRequest
            {
                TxData = txData
            };

            return await (this as IQtumClient).Broadcast(broadcastRequest).ConfigureAwait(false);
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
                    List<BitcoinTx> inputTxes = await (this as IBitcoinClient).GetTxForAccount(fromAddress.Address).ConfigureAwait(false);
                    foreach (BitcoinTx inputTx in inputTxes)
                    {
                        for (int i = 0; i < inputTx.Outputs.Count; i++)
                        {
                            if (inputTx.Outputs[i].Address == fromAddress.Address)
                            {
                                var secret = new BitcoinSecret(fromAddress.PrivateKey, network);
                                try
                                {
                                    BitcoinUtxo utxo = await (this as IBitcoinClient).GetUtxo(inputTx.Hash, i).ConfigureAwait(false);

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
                        BitcoinUtxo utxo = await (this as IBitcoinClient).GetUtxo(fromUtxo.TxHash, (int)fromUtxo.Index).ConfigureAwait(false);

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

        private TxIn GetInputFromUtxo(BitcoinSecret secret, BitcoinUtxo utxo, List<BitcoinSecret> privateKeysToSign, List<Coin> coinsToSpent)
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
            var baseUrl = "https://api-eu1.tatum.io/v3/qtum";

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

            var baseUrl = "https://api-eu1.tatum.io/v3/qtum";

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

            var baseUrl = "https://api-eu1.tatum.io/v3/qtum";

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
            var baseUrl = "https://api-eu1.tatum.io/v3/qtum";

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
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
using System.ComponentModel.DataAnnotations;
using NBitcoin;
using NBitcoin.Altcoins;
using Tatum.Model.Requests;
using Tatum.Model.Responses;


/// <summary>
/// Summary description for BitcoinCashClient
/// </summary>
/// 
namespace Tatum
{
    public class BitcoinCashClient : IBitcoinCashClient
    {
        private readonly string _privateKey;
        public BitcoinCashClient(string privateKey)
        {
            _privateKey = privateKey;
        }



        Wallets IBitcoinCashClient.CreateWallet(string mnemonic, bool testnet)
        {
            var xPub = new Mnemonic(mnemonic)
                .DeriveExtKey()
                .Derive(new KeyPath(Constants.BchKeyDerivationPath))
                .Neuter();

            return new Wallets
            {
                Mnemonic = mnemonic,
                XPub = xPub.ToString(testnet ? BCash.Instance.Testnet : BCash.Instance.Mainnet)
            };
        }

        string IBitcoinCashClient.GeneratePrivateKey(string mnemonic, int index, bool testnet)
        {
            return new Mnemonic(mnemonic)
                .DeriveExtKey()
                .Derive(new KeyPath(Constants.BchKeyDerivationPath))
                .Derive(Convert.ToUInt32(index))
                .PrivateKey
                .GetWif(testnet ? BCash.Instance.Testnet : BCash.Instance.Mainnet)
                .ToString();
        }

        string IBitcoinCashClient.GenerateAddress(string xPubString, int index, bool testnet)
        {
            return ExtPubKey.Parse(xPubString, testnet ? BCash.Instance.Testnet : BCash.Instance.Mainnet)
                .Derive(Convert.ToUInt32(index))
                .PubKey
                .GetAddress(ScriptPubKeyType.Legacy, testnet ? BCash.Instance.Testnet : BCash.Instance.Mainnet)
                .ToString();
        }




        public async Task<BitcoinCash> GetBlockchainInfo()
        {


            var stringResult = await GetSecureRequest($"info");

            var result = JsonConvert.DeserializeObject<BitcoinCash>(stringResult);

            return result;
        }

        public async Task<BitcoinCash> GetBitcoinCashBlockHash(int i)
        {


            var stringResult = await GetSecureRequest($"block/hash/{i}");

            var result = JsonConvert.DeserializeObject<BitcoinCash>(stringResult);

            return result;
        }


        public async Task<BitcoinCash> GetBitcoinCashBlockByHash(string hash)
        {


            var stringResult = await GetSecureRequest($"block/{hash}");

            var result = JsonConvert.DeserializeObject<BitcoinCash>(stringResult);

            return result;
        }


        public async Task<BitcoinCash> GetBitcoinCashTransactionByHash(string hash)
        {


            var stringResult = await GetSecureRequest($"transaction/{hash}");

            var result = JsonConvert.DeserializeObject<BitcoinCash>(stringResult);

            return result;
        }


        public async Task<List<BitcoinCash>> GetBitcoinCashTransactionByAddress(string address)
        {


            var stringResult = await GetSecureRequest($"transaction/{address}");

            var result = JsonConvert.DeserializeObject<List<BitcoinCash>>(stringResult);

            return result;
        }




        //public async Task<BitcoinCash> SendBitcoinCashTransactionFromUTXO(string txHash, int index, string privateKey, string toAddress, string value)
        //{

        //    string parameters = "{\"fromUTXO\":[{\"txHash\":" + "\"" + txHash + "" + "\",\"index\":" + "\"" + index + "" + "\",\"privateKey\":" + "\"" + privateKey + "" + "\"}],\"to\":[{\"address\":" + "\"" + toAddress + "" + "\",\"value\":" + "\"" + value + "" + "\"}]}";


        //    var stringResult = await PostSecureRequest($"transaction", parameters);

        //    var result = JsonConvert.DeserializeObject<BitcoinCash>(stringResult);

        //    return result;
        //}


        //public async Task<BitcoinCash> SendBitcoinCashTransactionFromUTXOKMS(string txHash, int index, string signatureId, string toAddress, string value)
        //{

        //    string parameters = "{\"fromUTXO\":[{\"txHash\":" + "\"" + txHash + "" + "\",\"index\":" + "\"" + index + "" + "\",\"signatureId\":" + "\"" + signatureId + "" + "\"}],\"to\":[{\"address\":" + "\"" + toAddress + "" + "\",\"value\":" + "\"" + value + "" + "\"}]}";


        //    var stringResult = await PostSecureRequest($"transaction", parameters);

        //    var result = JsonConvert.DeserializeObject<BitcoinCash>(stringResult);

        //    return result;
        //}


        public  Task<TransactionHash> BroadcastSignedTransaction(BroadcastRequest request)
        {

            throw new NotImplementedException();
        }



        Task<string> IBitcoinCashClient.SignKmsTransaction(TransactionKms tx, List<string> privateKeys, bool testnet)
        {
            throw new NotImplementedException();
        }

        async Task<TransactionHash> IBitcoinCashClient.SendTransaction(TransferBchBlockchain body, bool testnet)
        {
            string txData = (this as IBitcoinCashClient).PrepareSignedTransaction(body, testnet);
            var broadcastRequest = new BroadcastRequest
            {
                TxData = txData
            };

            return await (this as IBitcoinCashClient).BroadcastSignedTransaction(broadcastRequest).ConfigureAwait(false);
        }

        string IBitcoinCashClient.PrepareSignedTransaction(TransferBchBlockchain body, bool testnet)
        {
            return PrepareSignedTransaction(testnet ? BCash.Instance.Testnet : BCash.Instance.Mainnet, body);
        }

        private string PrepareSignedTransaction(Network network, TransferBchBlockchain body)
        {
            var validationContext = new ValidationContext(body);
            Validator.ValidateObject(body, validationContext);

            NBitcoin.Transaction transaction = network.CreateTransaction();
            List<BitcoinSecret> privateKeysToSign = new List<BitcoinSecret>();
            List<Coin> coinsToSpent = new List<Coin>();

            if (body.FromUtxos != null)
            {
                foreach (FromUtxoBcash fromUtxo in body.FromUtxos)
                {
                    var secret = new BitcoinSecret(fromUtxo.PrivateKey, network);

                    try
                    {
                        TxIn input = GetInputFromUtxo(secret, fromUtxo, privateKeysToSign, coinsToSpent);
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

        private TxIn GetInputFromUtxo(BitcoinSecret secret, FromUtxoBcash utxo, List<BitcoinSecret> privateKeysToSign, List<Coin> coinsToSpent)
        {
            uint256 transactionId = uint256.Parse(utxo.TxHash);
            var outpoint = new OutPoint(transactionId, (uint)utxo.Index);

            privateKeysToSign.Add(secret);
            var scriptSig = secret.GetAddress(ScriptPubKeyType.Legacy).ScriptPubKey;

            long value = (long)(Convert.ToDecimal(utxo.Value) * 100000000);

            var coinToSpent = new Coin(transactionId, (uint)utxo.Index, Money.Satoshis(value), scriptSig);
            coinsToSpent.Add(coinToSpent);

            return new TxIn(outpoint, scriptSig);
        }

















        private async Task<string> GetSecureRequest(string path, Dictionary<string, string> paramaters = null)
        {
            var baseUrl = "https://api-eu1.tatum.io/v3/bcash";

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

            var baseUrl = "https://api-eu1.tatum.io/v3/bcash";

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

            var baseUrl = "https://api-eu1.tatum.io/v3/bcash";

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
            var baseUrl = "https://api-eu1.tatum.io/v3/bcash";

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
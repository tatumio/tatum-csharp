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

/// <summary>
/// Summary description for DogeClient
/// </summary>
/// 
namespace Tatum
{
    public class DogeClient : IDogecoinClient
    {
        private readonly string _privateKey;
        public DogeClient(string privateKey)
        {
            _privateKey = privateKey;
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


        public async Task<List<Dogecoin>> GetDogecoinUTXOTransaction(string hash, int index)
        {


            var stringResult = await GetSecureRequest($"utxo/{hash}/{index}");

            var result = JsonConvert.DeserializeObject<List<Dogecoin>>(stringResult);

            return result;
        }


        public async Task<Dogecoin> SendDogeTransactionUTXO(string fee, string changeAddress, string txHash, string sentvalue, string fromAddress, int index, string privateKey, string toAddress, string value)
        {

            string parameters = "{\"fee\":" + "\"" + fee + "" + "\",\"changeAddress\":" + "\"" + changeAddress + "" + "\",\"fromUTXO\":[{\"txHash\":" + "\"" + txHash + "" + "\",\"value\":" + "\"" + value + "" + "\",\"address\":" + "\"" + fromAddress + "" + "\",\"index\":" + "\"" + index + "" + "\",\"privateKey\":" + "\"" + privateKey + "" + "\"}],\"to\":[{\"address\":" + "\"" + toAddress + "" + "\",\"value\":" + "\"" + value + "" + "\"}]}";

            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<Dogecoin>(stringResult);

            return result;
        }




        public async Task<Dogecoin> SendDogeTransactionUTXOKMS(string txHash, string sentvalue, string fromAddress, int index, string signatureId, string toAddress, string value, string fee, string changeAddress)
        {

            string parameters = "{\"fromUTXO\":[{\"txHash\":" + "\"" + txHash + "" + "\",\"value\":" + "\"" + value + "" + "\",\"address\":" + "\"" + fromAddress + "" + "\",\"index\":" + "\"" + index + "" + "\",\"signatureId\":" + "\"" + signatureId + "" + "\"}],\"to\":[{\"address\":" + "\"" + toAddress + "" + "\",\"value\":" + "\"" + value + "" + "\"}],\"fee\":" + "\"" + fee + "" + "\",\"changeAddress\":" + "\"" + changeAddress + "" + "\"}";

            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<Dogecoin>(stringResult);

            return result;
        }




        public async Task<Dogecoin> BroadcastSignedDogecoinTransaction(string txData, string signatureId)
        {

            string parameters = "{\"txData\":" + "\"" + txData + "" + "\",\"signatureId\":" + "\"" + signatureId + "" + "\"}";

            var stringResult = await PostSecureRequest($"broadcast", parameters);

            var result = JsonConvert.DeserializeObject<Dogecoin>(stringResult);

            return result;
        }































































        private async Task<string> GetSecureRequest(string path, Dictionary<string, string> paramaters = null)
        {
            var baseUrl = "https://api-eu1.tatum.io/v3/dogecoin";

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

            var baseUrl = "https://api-eu1.tatum.io/v3/dogecoin";

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

            var baseUrl = "https://api-eu1.tatum.io/v3/dogecoin";

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
            var baseUrl = "https://api-eu1.tatum.io/v3/dogecoin";

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
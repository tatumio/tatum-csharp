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
using Neo.Lux.Core;
using Neo.Lux.Utils;
using Neo.Lux.Cryptography;


/// <summary>
/// Summary description for NeoClient
/// </summary>
/// 
namespace Tatum
{
    public class NeoClient : INeoClient
    {


        private readonly string _privateKey;
        private readonly string _serverUrl;
        private KeyPair keyPair;
        public NeoClient(string privateKey, string serverUrl)
        {
            _privateKey = privateKey;
            _serverUrl = serverUrl;
        }


        Wallets INeoClient.CreateWallet(string keyinput, bool testnet)
        {
            if (keyinput.Length == 52)
            {
                keyPair = KeyPair.FromWIF(keyinput);
               
            }
            else
           if (keyinput.Length == 64)
            {
                var keyBytes = keyinput.HexToBytes();
                keyPair = new KeyPair(keyBytes);
            }
            

            return new Wallets
            {
               Address=keyPair.address,
               PrivateKey=keyPair.PrivateKey.ToString()
            };
        }

     

        public async Task<neo> GenerateCurrentNeoBlock()
        {

            var stringResult = await GetSecureRequest($"block/current");

            var result = JsonConvert.DeserializeObject<neo>(stringResult);

            return result;
        }

        public async Task<neo> GenerateNeoBlock(string hash)
        {

            var stringResult = await GetSecureRequest($"block/{hash}");

            var result = JsonConvert.DeserializeObject<neo>(stringResult);

            return result;
        }

        public async Task<neo> GenerateNeoAccountBalance(string address)
        {

            var stringResult = await GetSecureRequest($"account/balance/{address}");

            var result = JsonConvert.DeserializeObject<neo>(stringResult);

            return result;
        }

        public async Task<neo> GenerateNeoAssetDetails(string asset)
        {

            var stringResult = await GetSecureRequest($"asset/{asset}");

            var result = JsonConvert.DeserializeObject<neo>(stringResult);

            return result;
        }

        public async Task<neo> GenerateNeoUnspentTransactionOutput(string txId, int index)
        {

            var stringResult = await GetSecureRequest($"transaction/out/{txId}/{index}");

            var result = JsonConvert.DeserializeObject<neo>(stringResult);

            return result;
        }

        public async Task<List<neo>> GenerateNeoTransactions(string address)
        {

            var stringResult = await GetSecureRequest($"account/tx/{address}");

            var result = JsonConvert.DeserializeObject<List<neo>>(stringResult);

            return result;
        }
        public async Task<neo> GetNeoContractDetails(string scriptHash)
        {

            var stringResult = await GetSecureRequest($"contract/{scriptHash}");

            var result = JsonConvert.DeserializeObject<neo>(stringResult);

            return result;
        }

        public async Task<neo> GetNeoTransactionByHash(string hash)
        {

            var stringResult = await GetSecureRequest($"transaction/{hash}");

            var result = JsonConvert.DeserializeObject<neo>(stringResult);

            return result;
        }


        public async Task<neo> SendNeoAsset(string to, int Neo, int gas, string fromprivatekey)
        {

            string parameters = "{\"to\":" + "\"" + to + "" + "\",\"assets\":{\"NEO\":" + "\"" + Neo + "" + "\",\"GAS\":" + "\"" + gas + "" + "\"},\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\"}";

            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<neo>(stringResult);

            return result;
        }

        public async Task<neo> ClaimGas(string privatekey)
        {

            string parameters = "{\"privateKey\":" + "\"" + privatekey + "" + "\"}";

            var stringResult = await PostSecureRequest($"claim", parameters);

            var result = JsonConvert.DeserializeObject<neo>(stringResult);

            return result;
        }


        public async Task<neo> SendNeoSmartContractTokens(string numOfdecimals, int additionalInvocationGas, int amount, string scriptHash, string to, string fromPrivateKey)
        {

            string parameters = "{\"numOfDecimals\":" + "\"" + numOfdecimals + "" + "\",\"additionalInvocationGas\":" + "\"" + additionalInvocationGas + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"scriptHash\":" + "\"" + scriptHash + "" + "\",\"to\":" + "\"" + to + "" + "\",\"fromPrivateKey\":" + "\"" + fromPrivateKey + "" + "\"}";

            var stringResult = await PostSecureRequest($"invoke", parameters);

            var result = JsonConvert.DeserializeObject<neo>(stringResult);

            return result;
        }




        public async Task<neo> BroadcastSignedNeoTransaction(string txdata)
        {
            string parameters = "{\"txData\":" + "\"" + txdata + "" + "\"}";

            var stringResult = await PostSecureRequest($"broadcast", parameters);

            var result = JsonConvert.DeserializeObject<neo>(stringResult);

            return result;
        }


































        private async Task<string> GetSecureRequest(string path, Dictionary<string, string> paramaters = null)
        {
            var baseUrl = serverUrl + "/v3/neo";

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

            var baseUrl = serverUrl + "/v3/neo";

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

            var baseUrl = serverUrl + "/v3/neo";

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
            var baseUrl = serverUrl + "/v3/neo";

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
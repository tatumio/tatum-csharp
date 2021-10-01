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
using Microsoft.Extensions.Http;
using System.Security;

/// <summary>
/// Summary description for FlowClient
/// </summary>
/// 
namespace Tatum
{
    public class FlowClient
    {
        private readonly string _privateKey;
        public FlowClient(string privateKey)
        {
            _privateKey = privateKey;
        }



        public async Task<Flow> GenerateFlowWallet(string mnemonic)
        {


            var stringResult = await GetSecureRequest($"wallet?mnemonic=" + mnemonic);

            var result = JsonConvert.DeserializeObject<Flow>(stringResult);

            return result;
        }


        public async Task<Flow> GenerateFlowAddressFromPublicKey(string xpub, int index)
        {


            var stringResult = await GetSecureRequest($"address/{xpub}/{index}");

            var result = JsonConvert.DeserializeObject<Flow>(stringResult);

            return result;
        }

        public async Task<Flow> GenerateFlowPublicKey(string xpub, int index)
        {


            var stringResult = await GetSecureRequest($"pubkey/{xpub}/{index}");

            var result = JsonConvert.DeserializeObject<Flow>(stringResult);

            return result;
        }


        public async Task<Flow> GenerateFlowPrivateKey(string index, int mnemonic)
        {

            string parameters = "{\"index\":" + "\"" + index + "" + "\",\"mnemonic\":" + "\"" + mnemonic + "" + "\"}";

            var stringResult = await PostSecureRequest($"wallet/priv",parameters);

            var result = JsonConvert.DeserializeObject<Flow>(stringResult);

            return result;
        }


        public async Task<Flow> GetFlowCurrentBlockNumber()
        {


            var stringResult = await GetSecureRequest($"block/current");

            var result = JsonConvert.DeserializeObject<Flow>(stringResult);

            return result;
        }


        public async Task<Flow> GetFlowBlockByHash(string hash)
        {


            var stringResult = await GetSecureRequest($"block/{hash}");

            var result = JsonConvert.DeserializeObject<Flow>(stringResult);

            return result;
        }


        public async Task<Flow> GetFlowEventsFromBlock(string type, string from, string to)
        {


            var stringResult = await GetSecureRequest($"block/events");

            var result = JsonConvert.DeserializeObject<Flow>(stringResult);

            return result;
        }


        public async Task<Flow> GetFlowTransactionByHash(string hash)
        {


            var stringResult = await GetSecureRequest($"transaction/{hash}");

            var result = JsonConvert.DeserializeObject<Flow>(stringResult);

            return result;
        }

        public async Task<Flow> GetFlowAccount(string address)
        {


            var stringResult = await GetSecureRequest($"account/{address}");

            var result = JsonConvert.DeserializeObject<Flow>(stringResult);

            return result;
        }



        public async Task<Flow> SendFlowTransactionMnemonic(string account, string currency, string to, string amount, string mnemonic, int index)
        {

            string parameters = "{\"account\":" + "\"" + account + "" + "\",\"currency\":" + "\"" + currency + "" + "\",\"to\":" + "\"" + to + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"mnemonic\":" + "\"" + mnemonic + "" + "\",\"index\":" + "\"" + index + "" + "\"}";

            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<Flow>(stringResult);

            return result;
        }



        public async Task<Flow> SendFlowTransactionPK(string account, string currency, string to, string amount, string privatekey)
        {

            string parameters = "{\"account\":" + "\"" + account + "" + "\",\"currency\":" + "\"" + currency + "" + "\",\"to\":" + "\"" + to + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"privateKey\":" + "\"" + privatekey + "\"}";

            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<Flow>(stringResult);

            return result;
        }


        public async Task<Flow> SendFlowTransactionKMS(string account, string currency, string to, string amount, string signatureid, int index)
        {

            string parameters = "{\"account\":" + "\"" + account + "" + "\",\"currency\":" + "\"" + currency + "" + "\",\"to\":" + "\"" + to + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"index\":" + "\"" + index + "" + "\"}";

            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<Flow>(stringResult);

            return result;
        }





        public async Task<Flow> CreateFlowCreateAddressFromPubKeyMnemonic(string account, string publickey, string mnemonic, int index)
        {

            string parameters = "{\"account\":" + "\"" + account + "" + "\",\"publicKey\":" + "\"" + publickey + "" + "\",\"mnemonic\":" + "\"" + mnemonic + "" + "\",\"index\":" + "\"" + index + "" + "\"}";

            var stringResult = await PostSecureRequest($"account", parameters);

            var result = JsonConvert.DeserializeObject<Flow>(stringResult);

            return result;
        }


        public async Task<Flow> CreateFlowCreateAddressFromPubKeySecret(string account, string publickey, string privatekey)
        {

            string parameters = "{\"account\":" + "\"" + account + "" + "\",\"publicKey\":" + "\"" + publickey + "" + "\",\"privateKey\":" + "\"" + privatekey + "" + "\"}";

            var stringResult = await PostSecureRequest($"account", parameters);

            var result = JsonConvert.DeserializeObject<Flow>(stringResult);

            return result;
        }


        public async Task<Flow> CreateFlowCreateAddressFromPubKeyKMS(string account, string publickey, string signatureid, int index)
        {

            string parameters = "{\"account\":" + "\"" + account + "" + "\",\"publicKey\":" + "\"" + publickey + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"index\":" + "\"" + index + "" + "\"}";

            var stringResult = await PostSecureRequest($"account", parameters);

            var result = JsonConvert.DeserializeObject<Flow>(stringResult);

            return result;
        }








        public async Task<Flow> AddFlowCreateAddressFromPubKeyMnemonic(string account, string publickey, string mnemonic, int index)
        {

            string parameters = "{\"account\":" + "\"" + account + "" + "\",\"publicKey\":" + "\"" + publickey + "" + "\",\"mnemonic\":" + "\"" + mnemonic + "" + "\",\"index\":" + "\"" + index + "" + "\"}";

            var stringResult = await PUTSecureRequest($"account", parameters);

            var result = JsonConvert.DeserializeObject<Flow>(stringResult);

            return result;
        }


        public async Task<Flow> AddFlowCreateAddressFromPubKeySecret(string account, string publickey, string privatekey)
        {

            string parameters = "{\"account\":" + "\"" + account + "" + "\",\"publicKey\":" + "\"" + publickey + "" + "\",\"privateKey\":" + "\"" + privatekey + "" + "\"}";

            var stringResult = await PUTSecureRequest($"account", parameters);

            var result = JsonConvert.DeserializeObject<Flow>(stringResult);

            return result;
        }


        public async Task<Flow> AddFlowCreateAddressFromPubKeyKMS(string account, string publickey, string signatureid, int index)
        {

            string parameters = "{\"account\":" + "\"" + account + "" + "\",\"publicKey\":" + "\"" + publickey + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"index\":" + "\"" + index + "" + "\"}";

            var stringResult = await PUTSecureRequest($"account", parameters);

            var result = JsonConvert.DeserializeObject<Flow>(stringResult);

            return result;
        }





















        private async Task<string> GetSecureRequest(string path, Dictionary<string, string> paramaters = null)
        {
            var baseUrl = "https://api-eu1.tatum.io/v3/flow";

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

            var baseUrl = "https://api-eu1.tatum.io/v3/flow";

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

            var baseUrl = "https://api-eu1.tatum.io/v3/flow";

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
            var baseUrl = "https://api-eu1.tatum.io/v3/flow";

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
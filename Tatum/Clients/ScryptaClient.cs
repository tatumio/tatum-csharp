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



/// <summary>
/// Summary description for ScryptaClient
/// </summary>
/// 
namespace Tatum
{
    public class ScryptaClient
    {



        private readonly string _privateKey;
        private readonly string _serverUrl;
        public ScryptaClient(string privateKey, string serverUrl)
        {
            _privateKey = privateKey;
            _serverUrl = serverUrl;
        }











        public async Task<Scrypta> GenerateScryptaWallet()
        {

            var stringResult = await GetSecureRequest($"wallet");

            var result = JsonConvert.DeserializeObject<Scrypta>(stringResult);

            return result;
        }

        public async Task<Scrypta> GenerateScryptaDepositAddressFromPublicKey(string xpub, int index)
        {

            var stringResult = await GetSecureRequest($"address/{xpub}/{index}");

            var result = JsonConvert.DeserializeObject<Scrypta>(stringResult);

            return result;
        }

        public async Task<Scrypta> GenerateScryptaPrivateKey(int index, string mnemonic)
        {
            string parameters = "{\"index\":" + "\"" + index + "" + "\",\"mnemonic\":" + "\"" + mnemonic + "" + "\"}";
            var stringResult = await PostSecureRequest($"wallet/priv", parameters);

            var result = JsonConvert.DeserializeObject<Scrypta>(stringResult);

            return result;
        }

      

        public async Task<Scrypta> GetBlockHash(string i)
        {

            var stringResult = await GetSecureRequest($"hash/{i}");

            var result = JsonConvert.DeserializeObject<Scrypta>(stringResult);

            return result;
        }

        public async Task<Scrypta> GetBlockByHash(string hash)
        {

            var stringResult = await GetSecureRequest($"block/{hash}");

            var result = JsonConvert.DeserializeObject<Scrypta>(stringResult);

            return result;
        }


        public async Task<Scrypta> SendLyratoBlockchainAddresses(string signatureidfrom, string address, string privatekeyfrom, string txhash, string index, string privatekeyto, string signatureidto, string addressto, string value)
        {
            string parameters = "{\"fromAddress\":[{\"signatureId\":" + "\"" + signatureidfrom + "" + "\",\"address\":" + "\"" + address + "" + "\",\"privateKey\":" + "\"" + privatekeyfrom + "" + "\"}],\"fromUTXO\":[{\"txHash\":" + "\"" + txhash + "" + "\",\"index\":" + "\"" + index + "" + "\",\"privateKey\":" + "\"" + privatekeyto + "" + "\",\"signatureId\":" + "\"" + signatureidto + "" + "\"}],\"to\":[{\"address\":" + "\"" + address + "" + "\",\"value\":" + "\"" + value + "" + "\"}]}";
            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<Scrypta>(stringResult);

            return result;
        }




        public async Task<Scrypta> GetScryptaTransactionByHash(string hash)
        {

            var stringResult = await GetSecureRequest($"{hash}");

            var result = JsonConvert.DeserializeObject<Scrypta>(stringResult);

            return result;
        }

        public async Task<Scrypta> GetTransactionsByAddress(string address, int pageSize = 50, int offset = 0)
        {

            var stringResult = await GetSecureRequest($"transaction/address/{address}?pageSize=50&offset=100");

            var result = JsonConvert.DeserializeObject<Scrypta>(stringResult);

            return result;
        }

        public async Task<Scrypta> GetScryptaSpendableUTXO(string address, int pageSize = 50, int offset = 0)
        {

            var stringResult = await GetSecureRequest($"utxo/{address}?pageSize=50&offset=100");

            var result = JsonConvert.DeserializeObject<Scrypta>(stringResult);

            return result;
        }

        public async Task<Scrypta> GetUTXOOfTransactions(string hash, string index)
        {

            var stringResult = await GetSecureRequest($"utxo/{hash}/{index}");

            var result = JsonConvert.DeserializeObject<Scrypta>(stringResult);

            return result;
        }

        public async Task<Scrypta> GetBlockchainInfo(string address)
        {

            var stringResult = await GetSecureRequest($"info");

            var result = JsonConvert.DeserializeObject<Scrypta>(stringResult);

            return result;
        }


      






        public async Task<Scrypta> BroadcastSignedScryptaTransaction(string txData, string signatureId)
        {
            string parameters = "{\"txData\":" + "\"" + txData + "" + "\",\"signatureId\":" + "\"" + signatureId + "" + "\"}";

            var stringResult = await PostSecureRequest($"broadcast", parameters);

            var result = JsonConvert.DeserializeObject<Scrypta>(stringResult);

            return result;
        }
























        private async Task<string> GetSecureRequest(string path, Dictionary<string, string> paramaters = null)
        {
            var baseUrl = serverUrl + "/v3/scrypta";

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

            var baseUrl = serverUrl + "/v3/scrypta";

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

            var baseUrl = serverUrl + "/v3/scrypta";

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
            var baseUrl = serverUrl + "/v3/scrypta";

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
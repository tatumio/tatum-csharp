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
/// Summary description for QuorumClient
/// </summary>
/// 
namespace Tatum
{
    public class QuorumClient
    {



        private readonly string _privateKey;
        private readonly string _serverUrl;
        public QuorumClient(string privateKey, string serverUrl)
        {
            _privateKey = privateKey;
            _serverUrl = serverUrl;
        }


        public async Task<Quorum> GenerateQuorumAccount(string password)
        {
            string parameters = "{\"password\":" + "\"" + password + "" + "\"}";
            var stringResult = await PostSecureRequest($"account", parameters);

            var result = JsonConvert.DeserializeObject<Quorum>(stringResult);

            return result;
        }

        public async Task<Quorum> UnlockQuorumAccount(string address)
        {
            string parameters = "{\"address\":" + "\"" + address + "" + "\"}";
            var stringResult = await PostSecureRequest($"account/{address}/unlock", parameters);

            var result = JsonConvert.DeserializeObject<Quorum>(stringResult);

            return result;
        }


        public async Task<Quorum> Web3HttpDriver(string xapikey)
        {
            string parameters = "{\"jsonrpc\":\"2.0\",\"method\":\"web3_clientVersion\",\"params\":[],\"id\":2}";
            var stringResult = await PostSecureRequest($"web3/{xapikey}", parameters);

            var result = JsonConvert.DeserializeObject<Quorum>(stringResult);

            return result;
        }


        public async Task<Quorum> GetCurrentBlockNumber()
        {

            var stringResult = await GetSecureRequest($"block/current");

            var result = JsonConvert.DeserializeObject<Quorum>(stringResult);

            return result;
        }

        public async Task<Quorum> GetQuorumBlockByHash(string hash)
        {

            var stringResult = await GetSecureRequest($"block/{hash}");

            var result = JsonConvert.DeserializeObject<Quorum>(stringResult);

            return result;
        }

        public async Task<Quorum> GetQuorumTransaction(string hash)
        {

            var stringResult = await GetSecureRequest($"transaction/{hash}");

            var result = JsonConvert.DeserializeObject<Quorum>(stringResult);

            return result;
        }

        public async Task<Quorum> GetQuorumTransactionReceipt(string hash)
        {

            var stringResult = await GetSecureRequest($"transaction/{hash}/receipt");

            var result = JsonConvert.DeserializeObject<Quorum>(stringResult);

            return result;
        }




        public async Task<Quorum> SendQuorumTransaction(string from, string to, string data, string amount)
        {
            string parameters = "{\"from\":" + "\"" + from + "" + "\",\"to\":" + "\"" + to + "" + "\",\"data\":" + "\"" + data + "" + "\",\"amount\":" + "\"" + amount + "" + "\"}";
            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<Quorum>(stringResult);

            return result;
        }















        private async Task<string> GetSecureRequest(string path, Dictionary<string, string> paramaters = null)
        {
            var baseUrl = serverUrl + "/v3/quorum";

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

            var baseUrl = serverUrl + "/v3/quorum";

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

            var baseUrl = serverUrl + "/v3/quorum";

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
            var baseUrl = serverUrl + "/v3/quorum";

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
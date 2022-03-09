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
/// Summary description for RecordClient
/// </summary>
/// 
namespace Tatum
{
    public class RecordClient
    {
        private readonly string _privateKey;
        private readonly string _serverUrl;
        public RecordClient(string privateKey, string serverUrl)
        {
            _privateKey = privateKey;
            _serverUrl = serverUrl;
        }



        public async Task<Record> CreateRecord(string data, string chain, string fromprivateKey, string nonce, string to)
        {
            string parameters = "{\"data\":" + "\"" + data + "" + "\",\"chain\":" + "\"" + chain + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivateKey + "" + "\",\"to\":" + "\"" + to + "" + "\"}";

            var stringResult = await PostSecureRequest($"record", parameters);

            var result = JsonConvert.DeserializeObject<Record>(stringResult);

            return result;
        }

        public async Task<Record> CreateRecordCelo(string data, string chain, string feecurrency, string fromprivateKey, string nonce, string to)
        {
            string parameters = "{\"data\":" + "\"" + data + "" + "\",\"chain\":" + "\"" + chain + "" + "\",\"feeCurrency\":" + "\"" + feecurrency + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivateKey + "" + "\",\"to\":" + "\"" + to + "" + "\"}";

            var stringResult = await PostSecureRequest($"record", parameters);

            var result = JsonConvert.DeserializeObject<Record>(stringResult);

            return result;
        }

        public async Task<Record> CreateRecordQuorum(string data, string chain, string from, string to)
        {
            string parameters = "{\"data\":" + "\"" + data + "" + "\",\"chain\":" + "\"" + chain + "" + "\",\"from\":" + "\"" + from + "" + "\",\"to\":" + "\"" + to + "" + "\"}";

            var stringResult = await PostSecureRequest($"record", parameters);

            var result = JsonConvert.DeserializeObject<Record>(stringResult);

            return result;
        }

        public async Task<Record> CreateRecordFabric(string data, string chain, string key)
        {
            string parameters = "{\"data\":" + "\"" + data + "" + "\",\"chain\":" + "\"" + chain + "" + "\",\"key\":" + "\"" + key + "" + "\"}";

            var stringResult = await PostSecureRequest($"record", parameters);

            var result = JsonConvert.DeserializeObject<Record>(stringResult);

            return result;
        }



        public async Task<Record> GetLogRecord(string chain, string id)
        {


            var stringResult = await GetSecureRequest($"record?chain=ETH&id=" + id);

            var result = JsonConvert.DeserializeObject<Record>(stringResult);

            return result;
        }














        private async Task<string> GetSecureRequest(string path, Dictionary<string, string> paramaters = null)
        {
            var baseUrl = _serverUrl + "/v3/record";

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

            var baseUrl = _serverUrl + "/v3/record";

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

            var baseUrl = _serverUrl + "/v3/record";

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
            var baseUrl = _serverUrl + "/v3/record";

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
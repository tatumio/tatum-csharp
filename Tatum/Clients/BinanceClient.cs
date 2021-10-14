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
/// Summary description for BinanceClient
/// </summary>
/// 
namespace Tatum
{
    public class BinanceClient
    {

        private readonly string _privateKey;
        public BinanceClient(string privateKey)
        {
            _privateKey = privateKey;
        }


        public async Task<Binance> GenerateBinanceWallet()
        {

            var stringResult = await GetSecureRequest($"account");

            var result = JsonConvert.DeserializeObject<Binance>(stringResult);

            return result;
        }

        public async Task<Binance> GetBinanceCurrentBlock()
        {


            var stringResult = await GetSecureRequest($"block/current");

            var result = JsonConvert.DeserializeObject<Binance>(stringResult);

            return result;
        }


        public async Task<Binance> GetBinanceTransactionsBlock(int height)
        {


            var stringResult = await GetSecureRequest($"block/{height}");

            var result = JsonConvert.DeserializeObject<Binance>(stringResult);

            return result;
        }

        public async Task<Binance> GetBinanceAccount(string address)
        {


            var stringResult = await GetSecureRequest($"account/{address}");

            var result = JsonConvert.DeserializeObject<Binance>(stringResult);

            return result;
        }

        public async Task<Binance> GetBinanceTransaction(string hash)
        {


            var stringResult = await GetSecureRequest($"transaction/{hash}");

            var result = JsonConvert.DeserializeObject<Binance>(stringResult);

            return result;
        }



        public async Task<Binance> TransferBnbBlockchain(string to, string currency, string amount, string fromprivateKey, string message)
        {
            string parameters = "{\"to\":" + "\"" + to + "" + "\",\"currency\":" + "\"" + currency + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivateKey + "" + "\",\"message\":" + "\"" + message + "" + "\"}";

            var stringResult = await PostSecureRequest($"record", parameters);

            var result = JsonConvert.DeserializeObject<Binance>(stringResult);

            return result;
        }


        public async Task<Binance> TransferBnbBlockchainKMS(string to, string currency, string amount, string signatureid, string fromaddress, string message)
        {
            string parameters = "{\"to\":" + "\"" + to + "" + "\",\"currency\":" + "\"" + currency + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"fromAddress\":" + "\"" + fromaddress + "" + "\",\"message\":" + "\"" + message + "" + "\"}";

            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<Binance>(stringResult);

            return result;
        }


        public async Task<Binance> BroadcastSignedBnbTransaction(string txdata)
        {
            string parameters = "{\"txData\":" + "\"" + txdata + "" + "\"}";

            var stringResult = await PostSecureRequest($"broadcast", parameters);

            var result = JsonConvert.DeserializeObject<Binance>(stringResult);

            return result;
        }





















        private async Task<string> GetSecureRequest(string path, Dictionary<string, string> paramaters = null)
        {
            var baseUrl = "https://api-eu1.tatum.io/v3/bnb";

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

            var baseUrl = "https://api-eu1.tatum.io/v3/bnb";

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

            var baseUrl = "https://api-eu1.tatum.io/v3/bnb";

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
            var baseUrl = "https://api-eu1.tatum.io/v3/bnb";

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
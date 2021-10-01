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
/// Summary description for VechainClient
/// </summary>
/// 
namespace Tatum
{
    public class VechainClient
    {


        private readonly string _privateKey;
        public VechainClient(string privateKey)
        {
            _privateKey = privateKey;
        }


        public async Task<Vechain> GenerateVechainWallet(string mnemonic)
        {

            var stringResult = await GetSecureRequest($"wallet");

            var result = JsonConvert.DeserializeObject<Vechain>(stringResult);

            return result;
        }


        public async Task<Vechain> GenerateVechainFromExtendedPublicKey(string xpub, string index)
        {

            var stringResult = await GetSecureRequest($"address/{xpub}/{index}");

            var result = JsonConvert.DeserializeObject<Vechain>(stringResult);

            return result;
        }

        public async Task<Vechain> GenerateVechainPrivateKey(string index, string mnemonic)
        {

            var stringResult = await PostSecureRequest($"wallet/priv","");

            var result = JsonConvert.DeserializeObject<Vechain>(stringResult);

            return result;
        }

        public async Task<Vechain> GetVechainCurrentBlock()
        {

            var stringResult = await GetSecureRequest($"block/current");

            var result = JsonConvert.DeserializeObject<Vechain>(stringResult);

            return result;
        }

        public async Task<Vechain> GetVechainBlockByHash(string hash)
        {

            var stringResult = await GetSecureRequest($"block/{hash}");

            var result = JsonConvert.DeserializeObject<Vechain>(stringResult);

            return result;
        }

        public async Task<Vechain> GetVechainAccountBalance(string address)
        {

            var stringResult = await GetSecureRequest($"account/balance/{address}");

            var result = JsonConvert.DeserializeObject<Vechain>(stringResult);

            return result;
        }

        public async Task<Vechain> GetVechainAccountEnergy(string address)
        {

            var stringResult = await GetSecureRequest($"account/energy/{address}");

            var result = JsonConvert.DeserializeObject<Vechain>(stringResult);

            return result;
        }


        public async Task<Vechain> GetVechainTransaction(string hash)
        {

            var stringResult = await GetSecureRequest($"transaction/{hash}");

            var result = JsonConvert.DeserializeObject<Vechain>(stringResult);

            return result;
        }


        public async Task<Vechain> GetVechainTransactionReceipt(string hash)
        {

            var stringResult = await GetSecureRequest($"transaction/{hash}/receipt");

            var result = JsonConvert.DeserializeObject<Vechain>(stringResult);

            return result;
        }


        public async Task<Vechain> SendVechainFromAccountToAccount(string to, string amount, string fromprivateKey, string signatureid, string data, string gasLimit)
        {

            string parameters = "{\"to\":" + "\"" + to + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivateKey + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"data\":" + "\"" + data + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\"}}";

            var stringResult = await PostSecureRequest($"transaction",parameters);

            var result = JsonConvert.DeserializeObject<Vechain>(stringResult);

            return result;
        }



        public async Task<Vechain> EstimateVechainGasForTransaction(string from, string to, string value, string data, string nonce)
        {

            string parameters = "{\"from\":" + "\"" + from + "" + "\",\"to\":" + "\"" + to + "" + "\",\"value\":" + "\"" + value + "" + "\",\"data\":" + "\"" + data + "" + "\",\"nonce\":" + "\"" + nonce + "" + "\"}";

            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<Vechain>(stringResult);

            return result;
        }




        public async Task<Record> BroadcastSignedVechainTransaction(string txdata, string signatureid)
        {
            string parameters = "{\"txData\":" + "\"" + txdata + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\"}";

            var stringResult = await PostSecureRequest($"broadcast", parameters);

            var result = JsonConvert.DeserializeObject<Record>(stringResult);

            return result;
        }














        private async Task<string> GetSecureRequest(string path, Dictionary<string, string> paramaters = null)
        {
            var baseUrl = "https://api-eu1.tatum.io/v3/vet";

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

            var baseUrl = "https://api-eu1.tatum.io/v3/vet";

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

            var baseUrl = "https://api-eu1.tatum.io/v3/vet";

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
            var baseUrl = "https://api-eu1.tatum.io/v3/vet";

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
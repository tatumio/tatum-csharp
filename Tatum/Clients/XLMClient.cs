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
using stellar_dotnet_sdk;

/// <summary>
/// Summary description for XLMClient
/// </summary>
/// 

namespace Tatum
{
    public class XLMClient:IXlmClient
    {

        private readonly string _privateKey;
        public XLMClient(string privateKey)
        {
            _privateKey = privateKey;
        }



        Wallets IXlmClient.CreateWallet(string secret)
        {
            KeyPair keypair;
            if (string.IsNullOrWhiteSpace(secret))
            {
              keypair = KeyPair.Random();
            }
            else
            {
               keypair = KeyPair.FromSecretSeed(secret);
            }

            return new Wallets
            {
               PrivateKey = keypair.SecretSeed,
                Address = keypair.Address
            };
        }

        public async Task<Xlm> GenerateXlmBlockchain()
        {


            var stringResult = await GetSecureRequest($"info");

            var result = JsonConvert.DeserializeObject<Xlm>(stringResult);

            return result;
        }

        public async Task<Xlm> GetXlmBlockchainLedger(string sequence)
        {


            var stringResult = await GetSecureRequest($"ledger/{sequence}");

            var result = JsonConvert.DeserializeObject<Xlm>(stringResult);

            return result;
        }

        public async Task<Xlm> GetXlmBlockchainTransactions(string sequence)
        {


            var stringResult = await GetSecureRequest($"ledger/{sequence}/transaction");

            var result = JsonConvert.DeserializeObject<Xlm>(stringResult);

            return result;
        }

        public async Task<Xlm> GetActualXlmFee()
        {


            var stringResult = await GetSecureRequest($"fee");

            var result = JsonConvert.DeserializeObject<Xlm>(stringResult);

            return result;
        }


        public async Task<Xlm> GetXlmAccountTransaction(string account, string pagination)
        {


            var stringResult = await GetSecureRequest($"account/tx/{account}");

            var result = JsonConvert.DeserializeObject<Xlm>(stringResult);

            return result;
        }


        public async Task<Xlm> GetXlmTransactionByHash(string hash)
        {


            var stringResult = await GetSecureRequest($"transaction/{hash}");

            var result = JsonConvert.DeserializeObject<Xlm>(stringResult);

            return result;
        }



        public async Task<Xlm> GetXlmAccountInfo(string account)
        {


            var stringResult = await GetSecureRequest($"account/{account}");

            var result = JsonConvert.DeserializeObject<Xlm>(stringResult);

            return result;
        }



        public async Task<Xlm> SendTransferXlmBlockchain(string fromaccount, string to, string amount, string fromsecret, bool initialize, string message)
        {
            string parameters = "{\"fromAccount\":" + "\"" + fromaccount + "" + "\",\"to\":" + "\"" + to + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"fromSecret\":" + "\"" + fromsecret + "" + "\",\"initialize\":" + "\"" + initialize + "" + "\",\"message\":" + "\"" + message + "" + "\"}";

            var stringResult = await PostSecureRequest($"transaction",parameters);

            var result = JsonConvert.DeserializeObject<Xlm>(stringResult);

            return result;
        }

        public async Task<Xlm> SendTransferXlmBlockchainAsset(string fromaccount, string to, string amount, string fromsecret, bool initialize, string token, string issuerAccount, string message)
        {
            string parameters = "{\"fromAccount\":" + "\"" + fromaccount + "" + "\",\"to\":" + "\"" + to + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"fromSecret\":" + "\"" + fromsecret + "" + "\",\"initialize\":" + "\"" + initialize + "" + "\",\"token\":" + "\"" + token + "" + "\",\"issuerAccount\":" + "\"" + issuerAccount + "" + "\",\"message\":" + "\"" + message + "" + "\"}";

            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<Xlm>(stringResult);

            return result;
        }

        public async Task<Xlm> SendTransferXlmBlockchainKMS(string fromaccount, string to, string amount, string signatureid, bool initialize, string message)
        {
            string parameters = "{\"fromAccount\":" + "\"" + fromaccount + "" + "\",\"to\":" + "\"" + to + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"initialize\":" + "\"" + initialize + "" + "\",\"message\":" + "\"" + message + "" + "\"}";

            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<Xlm>(stringResult);

            return result;
        }

        public async Task<Xlm> SendTransferXlmBlockchainKMSAsset(string fromaccount, string to, string amount, string signatureid, bool initialize, string token, string issuerAccount, string message)
        {
            string parameters = "{\"fromAccount\":" + "\"" + fromaccount + "" + "\",\"to\":" + "\"" + to + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"initialize\":" + "\"" + initialize + "" + "\",\"token\":" + "\"" + token + "" + "\",\"issuerAccount\":" + "\"" + issuerAccount + "" + "\",\"message\":" + "\"" + message + "" + "\"}";

            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<Xlm>(stringResult);

            return result;
        }



        public async Task<Xlm> CreateTrustLineXlmBlockchain(string fromaccount, string issuerAccount, string token, string fromsecret, string limit)
        {
            string parameters = "{\"fromAccount\":" + "\"" + fromaccount + "" + "\",\"issuerAccount\":" + "\"" + issuerAccount + "" + "\",\"token\":" + "\"" + token + "" + "\",\"fromSecret\":" + "\"" + fromsecret + "" + "\",\"limit\":" + "\"" + limit + "" + "\"}";

            var stringResult = await PostSecureRequest($"trust", parameters);

            var result = JsonConvert.DeserializeObject<Xlm>(stringResult);

            return result;
        }


        public async Task<Xlm> CreateTrustLineXlmBlockchainKMS(string fromaccount, string issuerAccount, string token, string signatureid, string limit)
        {
            string parameters = "{\"fromAccount\":" + "\"" + fromaccount + "" + "\",\"issuerAccount\":" + "\"" + issuerAccount + "" + "\",\"token\":" + "\"" + token + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"limit\":" + "\"" + limit + "" + "\"}";

            var stringResult = await PostSecureRequest($"trust", parameters);

            var result = JsonConvert.DeserializeObject<Xlm>(stringResult);

            return result;
        }


        public async Task<Xlm> BroadcastSignedXlmTransaction(string txData, string signatureid)
        {
            string parameters = "{\"txData\":" + "\"" + txData + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\"}";

            var stringResult = await PostSecureRequest($"broadcast", parameters);

            var result = JsonConvert.DeserializeObject<Xlm>(stringResult);

            return result;
        }

























        private async Task<string> GetSecureRequest(string path, Dictionary<string, string> paramaters = null)
        {
            var baseUrl = "https://api-eu1.tatum.io/v3/xlm";

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

            var baseUrl = "https://api-eu1.tatum.io/v3/xlm";

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

            var baseUrl = "https://api-eu1.tatum.io/v3/xlm";

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
            var baseUrl = "https://api-eu1.tatum.io/v3/xlm";

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
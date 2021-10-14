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
/// Summary description for XrpClient
/// </summary>
/// 
namespace Tatum
{
    public class XrpClient
    {
        private readonly string _privateKey;
        public XrpClient(string privateKey)
        {
            _privateKey = privateKey;
        }



        public async Task<Xrp> GenerateXrpAccount()
        {


            var stringResult = await GetSecureRequest($"account");

            var result = JsonConvert.DeserializeObject<Xrp>(stringResult);

            return result;
        }


        public async Task<Xrp> GenerateXrpBlockchainInfo()
        {


            var stringResult = await GetSecureRequest($"info");

            var result = JsonConvert.DeserializeObject<Xrp>(stringResult);

            return result;
        }


        public async Task<Xrp> GetXrpBlockchainFee()
        {


            var stringResult = await GetSecureRequest($"fee");

            var result = JsonConvert.DeserializeObject<Xrp>(stringResult);

            return result;
        }


        public async Task<Xrp> GetAccountTransactions(string account)
        {


            var stringResult = await GetSecureRequest($"tx/{account}");

            var result = JsonConvert.DeserializeObject<Xrp>(stringResult);

            return result;
        }

        public async Task<Xrp> GetLedger(int i)
        {


            var stringResult = await GetSecureRequest($"ledger/{i}");

            var result = JsonConvert.DeserializeObject<Xrp>(stringResult);

            return result;
        }


        public async Task<Xrp> GetXrpTransactionByHash(string hash)
        {


            var stringResult = await GetSecureRequest($"transaction/{hash}");

            var result = JsonConvert.DeserializeObject<Xrp>(stringResult);

            return result;
        }


        public async Task<Xrp> GetAccountInfo(string account)
        {


            var stringResult = await GetSecureRequest($"account/{account}");

            var result = JsonConvert.DeserializeObject<Xrp>(stringResult);

            return result;
        }


        public async Task<Xrp> GetAccountBalance(string account)
        {


            var stringResult = await GetSecureRequest($"{account}/balance");

            var result = JsonConvert.DeserializeObject<Xrp>(stringResult);

            return result;
        }



        public async Task<Xrp> SendXrpBlockchain(string fromaccount, string to, string amount, string fromsecret, string fee, string sourceTag, string destinationTag)
        {

            string parameters = "{\"fromAccount\":" + "\"" + fromaccount + "" + "\",\"to\":" + "\"" + to + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"fromSecret\":" + "\"" + fromsecret + "" + "\",\"fee\":" + "\"" + fee + "" + "\",\"sourceTag\":" + "\"" + sourceTag + "" + "\",\"destinationTag\":" + "\"" + destinationTag + "" + "\"}";

            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<Xrp>(stringResult);

            return result;
        }


        public async Task<Xrp> SendXrpBlockchainAsset(string fromaccount, string to, string amount, string fromsecret, string fee, string sourceTag, string destinationTag, string issuerAccount, string token)
        {

            string parameters = "{\"fromAccount\":" + "\"" + fromaccount + "" + "\",\"to\":" + "\"" + to + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"fromSecret\":" + "\"" + fromsecret + "" + "\",\"fee\":" + "\"" + fee + "" + "\",\"sourceTag\":" + "\"" + sourceTag + "" + "\",\"destinationTag\":" + "\"" + destinationTag + "" + "\",\"issuerAccount\":" + "\"" + issuerAccount + "" + "\",\"token\":" + "\"" + token + "" + "\"}";

            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<Xrp>(stringResult);

            return result;
        }


        public async Task<Xrp> SendXrpBlockchainKMS(string fromaccount, string to, string amount, string signatureid, string fee, string sourceTag, string destinationTag)
        {

            string parameters = "{\"fromAccount\":" + "\"" + fromaccount + "" + "\",\"to\":" + "\"" + to + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"fee\":" + "\"" + fee + "" + "\",\"sourceTag\":" + "\"" + sourceTag + "" + "\",\"destinationTag\":" + "\"" + destinationTag + "" + "\"}";

            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<Xrp>(stringResult);

            return result;
        }



        public async Task<Xrp> SendXrpBlockchainAssetKMS(string fromaccount, string to, string amount, string signatureid, string fee, string sourceTag, string destinationTag, string issuerAccount, string token)
        {

            string parameters = "{\"fromAccount\":" + "\"" + fromaccount + "" + "\",\"to\":" + "\"" + to + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"fee\":" + "\"" + fee + "" + "\",\"sourceTag\":" + "\"" + sourceTag + "" + "\",\"destinationTag\":" + "\"" + destinationTag + "" + "\",\"issuerAccount\":" + "\"" + issuerAccount + "" + "\",\"token\":" + "\"" + token + "" + "\"}";

            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<Xrp>(stringResult);

            return result;
        }


        public async Task<Xrp> CreateTrustLineXrpBlockchain(string fromaccount, string issueraccount, string limit, string token, string signatureId, string fee)
        {

            string parameters = "{\"fromAccount\":" + "\"" + fromaccount + "" + "\",\"issuerAccount\":" + "\"" + issueraccount + "" + "\",\"limit\":" + "\"" + limit + "" + "\",\"token\":" + "\"" + token + "" + "\",\"signatureId\":" + "\"" + signatureId + "" + "\",\"fee\":" + "\"" + fee + "" + "\"}";

            var stringResult = await PostSecureRequest($"trust", parameters);

            var result = JsonConvert.DeserializeObject<Xrp>(stringResult);

            return result;
        }


        public async Task<Xrp> CreateTrustLineXrpBlockchainKMS(string fromaccount, string issueraccount, string limit, string token, string fromsecret, string fee)
        {

            string parameters = "{\"fromAccount\":" + "\"" + fromaccount + "" + "\",\"issuerAccount\":" + "\"" + issueraccount + "" + "\",\"limit\":" + "\"" + limit + "" + "\",\"token\":" + "\"" + token + "" + "\",\"fromsecret\":" + "\"" + fromsecret + "" + "\",\"fee\":" + "\"" + fee + "" + "\"}";

            var stringResult = await PostSecureRequest($"trust", parameters);

            var result = JsonConvert.DeserializeObject<Xrp>(stringResult);

            return result;
        }



        public async Task<Xrp> AddFlowCreateAddressFromPubKeyMnemonic(string account, string publickey, string mnemonic, int index)
        {

            string parameters = "{\"account\":" + "\"" + account + "" + "\",\"publicKey\":" + "\"" + publickey + "" + "\",\"mnemonic\":" + "\"" + mnemonic + "" + "\",\"int\":" + "\"" + index + "" + "\"}";

            var stringResult = await PostSecureRequest($"account/settings", parameters);

            var result = JsonConvert.DeserializeObject<Xrp>(stringResult);

            return result;
        }



        public async Task<Xrp> AddFlowCreateAddressFromPubKeySecret(string account, string publickey, string privatekey)
        {

            string parameters = "{\"account\":" + "\"" + account + "" + "\",\"publicKey\":" + "\"" + publickey + "" + "\",\"privateKey\":" + "\"" + privatekey + "" + "\"}";

            var stringResult = await PostSecureRequest($"account/settings", parameters);

            var result = JsonConvert.DeserializeObject<Xrp>(stringResult);

            return result;
        }

        public async Task<Xrp> AddFlowCreateAddressFromPubKeyKMS(string account, string publickey, string signatureid, int index)
        {

            string parameters = "{\"account\":" + "\"" + account + "" + "\",\"publicKey\":" + "\"" + publickey + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"index\":" + "\"" + index + "" + "\"}";

            var stringResult = await PostSecureRequest($"account/settings", parameters);

            var result = JsonConvert.DeserializeObject<Xrp>(stringResult);

            return result;
        }


        public async Task<Xrp> ModifyAccountSettingsXrpBlockchain(string fromAccount, string fromSecret, string fee, bool rippling, string requireDestinationTag)
        {

            string parameters = "{\"fromAccount\":" + "\"" + fromAccount + "" + "\",\"fromSecret\":" + "\"" + fromSecret + "" + "\",\"fee\":" + "\"" + fee + "" + "\",\"rippling\":" + "\"" + rippling + "" + "\",\"requireDestinationTag\":" + "\"" + requireDestinationTag + "" + "\"}";

            var stringResult = await PostSecureRequest($"account/settings", parameters);

            var result = JsonConvert.DeserializeObject<Xrp>(stringResult);

            return result;
        }

        public async Task<Xrp> ModifyAccountSettingsXrpBlockchainKMS(string fromAccount, string signatureid, string fee, bool rippling, string requireDestinationTag)
        {

            string parameters = "{\"fromAccount\":" + "\"" + fromAccount + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"fee\":" + "\"" + fee + "" + "\",\"rippling\":" + "\"" + rippling + "" + "\",\"requireDestinationTag\":" + "\"" + requireDestinationTag + "" + "\"}";

            var stringResult = await PostSecureRequest($"account/settings", parameters);

            var result = JsonConvert.DeserializeObject<Xrp>(stringResult);

            return result;
        }



        public async Task<Xrp> BroadcastSignedXrpTransaction(string txData, string signatureid)
        {

            string parameters = "{\"txData\":" + "\"" + txData + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\"}";

            var stringResult = await PostSecureRequest($"broadcast", parameters);

            var result = JsonConvert.DeserializeObject<Xrp>(stringResult);

            return result;
        }








































        private async Task<string> GetSecureRequest(string path, Dictionary<string, string> paramaters = null)
        {
            var baseUrl = "https://api-eu1.tatum.io/v3/xrp";

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

            var baseUrl = "https://api-eu1.tatum.io/v3/xrp";

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

            var baseUrl = "https://api-eu1.tatum.io/v3/xrp";

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
            var baseUrl = "https://api-eu1.tatum.io/v3/xrp";

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
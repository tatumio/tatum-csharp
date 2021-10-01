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
/// Summary description for QtumClient
/// </summary>
namespace Tatum
{
    public class QtumClient
    {



        private readonly string _privateKey;
        public QtumClient(string privateKey)
        {
            _privateKey = privateKey;
        }











        public async Task<QTUM> GenerateQtumWallet(string mnemonic)
        {

            var stringResult = await GetSecureRequest($"wallet?mnemonic=" + mnemonic);

            var result = JsonConvert.DeserializeObject<QTUM>(stringResult);

            return result;
        }

        public async Task<QTUM> GenerateQtumAccountAddressFromPublicKey(string xpub, int i)
        {

            var stringResult = await GetSecureRequest($"address/{xpub}/{i}");

            var result = JsonConvert.DeserializeObject<QTUM>(stringResult);

            return result;
        }

        public async Task<QTUM> GenerateQtumPrivateKey(int index, string mnemonic)
        {
            string parameters = "{\"index\":" + "\"" + index + "" + "\",\"mnemonic\":" + "\"" + mnemonic + "" + "\"}";
            var stringResult = await PostSecureRequest($"wallet/priv", parameters);

            var result = JsonConvert.DeserializeObject<QTUM>(stringResult);

            return result;
        }

        public async Task<QTUM> Web3HttpDriver(string xapikey)
        {
            string parameters = "{\"jsonrpc\":\"2.0\",\"method\":\"web3_clientVersion\",\"params\":[],\"id\":2}";

            var stringResult = await PostSecureRequest($"web3/{xapikey}", parameters);

            var result = JsonConvert.DeserializeObject<QTUM>(stringResult);

            return result;
        }


        public async Task<QTUM> GetCurrentBlockNumber()
        {

            var stringResult = await GetSecureRequest($"block/current");

            var result = JsonConvert.DeserializeObject<QTUM>(stringResult);

            return result;
        }

        public async Task<QTUM> GetQtumBlockByHash(string hash)
        {

            var stringResult = await GetSecureRequest($"block/{hash}");

            var result = JsonConvert.DeserializeObject<QTUM>(stringResult);

            return result;
        }

        public async Task<QTUM> GenerateQtumAddressFromPrivateKey(string key)
        {

            var stringResult = await GetSecureRequest($"address/{key}");

            var result = JsonConvert.DeserializeObject<QTUM>(stringResult);

            return result;
        }

        public async Task<QTUM> GetUTXO(string address)
        {

            var stringResult = await GetSecureRequest($"utxo/{address}");

            var result = JsonConvert.DeserializeObject<QTUM>(stringResult);

            return result;
        }

        public async Task<QTUM> GetQtumAccountBalance(string address)
        {

            var stringResult = await GetSecureRequest($"balance/{address}");

            var result = JsonConvert.DeserializeObject<QTUM>(stringResult);

            return result;
        }

        public async Task<QTUM> GetQtumTransaction(string id)
        {

            var stringResult = await GetSecureRequest($"transaction/{id}");

            var result = JsonConvert.DeserializeObject<QTUM>(stringResult);

            return result;
        }

        public async Task<QTUM> GetQtumTransactionsByAddress(string address, int pageSize = 50, int offset = 0)
        {

            var stringResult = await GetSecureRequest($"transactions/address/{address}/?pageSize=20&offset=0");

            var result = JsonConvert.DeserializeObject<QTUM>(stringResult);

            return result;
        }


        public async Task<QTUM> GetQtumEstimatedGasFees(string nblocks)
        {

            var stringResult = await GetSecureRequest($"transactions/gas/{nblocks}");

            var result = JsonConvert.DeserializeObject<QTUM>(stringResult);

            return result;
        }

        public async Task<QTUM> GetQtumEstimatedGasFeesByte(string nblocks)
        {

            var stringResult = await GetSecureRequest($"transactions/gasbytes/{nblocks}");

            var result = JsonConvert.DeserializeObject<QTUM>(stringResult);

            return result;
        }













        public async Task<QTUM> BroadcastSignedQtumTransaction(string txData, string signatureId)
        {
            string parameters = "{\"txData\":" + "\"" + txData + "" + "\",\"signatureId\":" + "\"" + signatureId + "" + "\"}";

            var stringResult = await PostSecureRequest($"broadcast", parameters);

            var result = JsonConvert.DeserializeObject<QTUM>(stringResult);

            return result;
        }
























        private async Task<string> GetSecureRequest(string path, Dictionary<string, string> paramaters = null)
        {
            var baseUrl = "https://api-eu1.tatum.io/v3/qtum";

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

            var baseUrl = "https://api-eu1.tatum.io/v3/qtum";

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

            var baseUrl = "https://api-eu1.tatum.io/v3/qtum";

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
            var baseUrl = "https://api-eu1.tatum.io/v3/qtum";

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
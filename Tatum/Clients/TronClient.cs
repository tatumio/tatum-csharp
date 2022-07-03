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
/// Summary description for TronClient
/// </summary>
/// 

namespace Tatum
{
    public class TronClient
    {
        private readonly string _privateKey;
        private readonly string _serverUrl;
        public TronClient(string privateKey, string serverUrl)
        {
            _privateKey = privateKey;
            _serverUrl = serverUrl;
        }



        public async Task<Tron> GenerateTronWallet(string mnemonic)
        {

            var stringResult = await GetSecureRequest($"wallet?mnemonic=" + mnemonic);

            var result = JsonConvert.DeserializeObject<Tron>(stringResult);

            return result;
        }

        public async Task<Tron> GenerateTronDepositAddressFromPublicKey(string xpub, int index)
        {

            var stringResult = await GetSecureRequest($"address/{xpub}/{index}");

            var result = JsonConvert.DeserializeObject<Tron>(stringResult);

            return result;
        }

        public async Task<Tron> GenerateTronPrivateKey(int index, string mnemonic)
        {
            string parameters = "{\"index\":" + "\"" + index + "" + "\",\"mnemonic\":" + "\"" + mnemonic + "" + "\"}";
            var stringResult = await PostSecureRequest($"wallet/priv", parameters);

            var result = JsonConvert.DeserializeObject<Tron>(stringResult);

            return result;
        }

       


        public async Task<Tron> GetTronCurrentBlock()
        {

            var stringResult = await GetSecureRequest($"block/current");

            var result = JsonConvert.DeserializeObject<Tron>(stringResult);

            return result;
        }

        public async Task<Tron> GetTronBlockByHash(string hash)
        {

            var stringResult = await GetSecureRequest($"block/{hash}");

            var result = JsonConvert.DeserializeObject<Tron>(stringResult);

            return result;
        }

       

        public async Task<Tron> GetTronAccountTransactions(string address,string next)
        {

            var stringResult = await GetSecureRequest($"transaction/account/{address}?next=" + next);

            var result = JsonConvert.DeserializeObject<Tron>(stringResult);

            return result;
        }




        public async Task<Tron> GetTronTrc20Transactions(string address, string next)
        {

            var stringResult = await GetSecureRequest($"transaction/account/{address}/trc20?next=" + next);

            var result = JsonConvert.DeserializeObject<Tron>(stringResult);

            return result;
        }


        public async Task<Tron> GetTronAccountByAddress(string address)
        {

            var stringResult = await GetSecureRequest($"account/{address}");

            var result = JsonConvert.DeserializeObject<Tron>(stringResult);

            return result;
        }

        public async Task<Tron> GetTronTransactionByHash(string hash)
        {

            var stringResult = await GetSecureRequest($"transaction/{hash}");

            var result = JsonConvert.DeserializeObject<Tron>(stringResult);

            return result;
        }













        public async Task<Tron> SendTransferTronBlockchain(string fromprivatekey, string to, string amount)
        {
            string parameters = "{\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"to\":" + "\"" + to + "" + "\",\"amount\":" + "\"" + amount + "" + "\"}";

            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<Tron>(stringResult);

            return result;
        }

        public async Task<Tron> SendTransferTronBlockchain(string from, string signatureid, string to, string amount, int index)
        {
            string parameters = "{\"from\":" + "\"" + from + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"to\":" + "\"" + to + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"index\":" + "\"" + index + "" + "\",}";

            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<Tron>(stringResult);

            return result;
        }


        public async Task<Tron> FreezeTron(string fromprivatekey, string receiver, string duration, string resource, string amount)
        {
            string parameters = "{\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"receiver\":" + "\"" + receiver + "" + "\",\"duration\":" + "\"" + duration + "" + "\",\"resource\":" + "\"" + resource + "" + "\",\"amount\":" + "\"" + amount + "" + "\"}";

            var stringResult = await PostSecureRequest($"freezeBalance", parameters);

            var result = JsonConvert.DeserializeObject<Tron>(stringResult);

            return result;
        }

        public async Task<Tron> FreezeTronKMS(string from, string signatureid, int index, string receiver, string duration, string resource, string amount)
        {
            string parameters = "{\"from\":" + "\"" + from + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"receiver\":" + "\"" + receiver + "" + "\",\"duration\":" + "\"" + duration + "" + "\",\"resource\":" + "\"" + resource + "" + "\",\"amount\":" + "\"" + amount + "" + "\"}";
            var stringResult = await PostSecureRequest($"freezeBalance", parameters);

            var result = JsonConvert.DeserializeObject<Tron>(stringResult);

            return result;
        }



        public async Task<Tron> SendTransferTronTrc10Blockchain(string fromprivatekey, string to, string tokenid, string amount)
        {
            string parameters = "{\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"to\":" + "\"" + to + "" + "\",\"amount\":" + "\"" + amount + "" + "\"}";

            var stringResult = await PostSecureRequest($"trc10/transaction", parameters);

            var result = JsonConvert.DeserializeObject<Tron>(stringResult);

            return result;
        }

        public async Task<Tron> SendTransferTronTrc10BlockchainKMS(string from, string signatureid, int index, string to, string tokenid, string amount)
        {
            string parameters = "{\"from\":" + "\"" + from + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"to\":" + "\"" + to + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"index\":" + "\"" + index + "" + "\",}";

            var stringResult = await PostSecureRequest($"trc10/transaction", parameters);

            var result = JsonConvert.DeserializeObject<Tron>(stringResult);

            return result;
        }



        public async Task<Tron> CreateTronTrc10Blockchain(string fromprivatekey, string recipient, string name, string abbreviation, string description, string url, int totalsupply, int decimals)
        {
            string parameters = "{\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"recipient\":" + "\"" + recipient + "" + "\",\"name\":" + "\"" + name + "" + "\",\"abbreviation\":" + "\"" + abbreviation + "" + "\",\"description\":" + "\"" + description + "" + "\",\"url\":" + "\"" + url + "" + "\",\"totalSupply\":" + "\"" + totalsupply + "" + "\",\"decimals\":" + "\"" + decimals + "" + "\"}";

            var stringResult = await PostSecureRequest($"tron/trc10/deploy", parameters);

            var result = JsonConvert.DeserializeObject<Tron>(stringResult);

            return result;
        }



        public async Task<Tron> CreateTronTrc10BlockchainKMS(string from, string signatureid, int index, string recipient, string name, string abbreviation, string description, string url, int totalsupply, int decimals)
        {
            string parameters = "{\"from\":" + "\"" + from + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"index\":" + "\"" + index + "" + "\",\"recipient\":" + "\"" + recipient + "" + "\",\"name\":" + "\"" + name + "" + "\",\"abbreviation\":" + "\"" + abbreviation + "" + "\",\"description\":" + "\"" + description + "" + "\",\"url\":" + "\"" + url + "" + "\",\"totalSupply\":" + "\"" + totalsupply + "" + "\",\"decimals\":" + "\"" + decimals + "" + "\"}";

            var stringResult = await PostSecureRequest($"tron/trc10/deploy", parameters);

            var result = JsonConvert.DeserializeObject<Tron>(stringResult);

            return result;
        }



        public async Task<Tron> GetTronTrc10TokenDetail(string id)
        {

            var stringResult = await GetSecureRequest($"trc10/detail/{id}");

            var result = JsonConvert.DeserializeObject<Tron>(stringResult);

            return result;
        }




        public async Task<Tron> SendTransferTronTrc20Blockchain(string fromprivatekey, string to, string tokenaddress, string feelimit, string amount)
        {
            string parameters = "{\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"to\":" + "\"" + to + "" + "\",\"tokenAddress\":" + "\"" + tokenaddress + "" + "\",\"feeLimit\":" + "\"" + feelimit + "" + "\",\"amount\":" + "\"" + amount + "" + "\"}";

            var stringResult = await PostSecureRequest($"trc20/transaction", parameters);

            var result = JsonConvert.DeserializeObject<Tron>(stringResult);

            return result;
        }

        public async Task<Tron> SendTransferTronTrc20BlockchainKMS(string from, string signatureid, int index, string to, string tokenaddress, string feelimit, string amount)
        {
            string parameters = "{\"from\":" + "\"" + from + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"index\":" + "\"" + index + "" + "\",\"to\":" + "\"" + to + "" + "\",\"tokenAddress\":" + "\"" + tokenaddress + "" + "\",\"feeLimit\":" + "\"" + feelimit + "" + "\",\"amount\":" + "\"" + amount + "" + "\"}";

            var stringResult = await PostSecureRequest($"trc20/transaction", parameters);

            var result = JsonConvert.DeserializeObject<Tron>(stringResult);

            return result;
        }





        public async Task<Tron> CreateTronTrc20Blockchain(string fromprivatekey, string recipient, string name, string symbol, int totalsupply, int decimals)
        {
            string parameters = "{\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"recipient\":" + "\"" + recipient + "" + "\",\"name\":" + "\"" + name + "" + "\",\"symbol\":" + "\"" + symbol + "" + "\",\"totalSupply\":" + "\"" + totalsupply + "" + "\",\"decimals\":" + "\"" + decimals + "" + "\"}";

            var stringResult = await PostSecureRequest($"tron/trc10/deploy", parameters);

            var result = JsonConvert.DeserializeObject<Tron>(stringResult);

            return result;
        }



        public async Task<Tron> CreateTronTrc20BlockchainKMS(string from, string signatureid, int index, string recipient, string name, string symbol, int totalsupply, int decimals)
        {
            string parameters = "{\"from\":" + "\"" + from + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"index\":" + "\"" + index + "" + "\",\"recipient\":" + "\"" + recipient + "" + "\",\"name\":" + "\"" + name + "" + "\",\"symbol\":" + "\"" + symbol + "" + "\",\"totalSupply\":" + "\"" + totalsupply + "" + "\",\"decimals\":" + "\"" + decimals + "" + "\"}";

            var stringResult = await PostSecureRequest($"tron/trc10/deploy", parameters);

            var result = JsonConvert.DeserializeObject<Tron>(stringResult);

            return result;
        }

        public async Task<Tron> BroadcastTronTransaction(string txData)
        {
            string parameters = "{\"txData\":" + "\"" + txData + "" + "\"}";

            var stringResult = await PostSecureRequest($"broadcast", parameters);

            var result = JsonConvert.DeserializeObject<Tron>(stringResult);

            return result;
        }









        private async Task<string> GetSecureRequest(string path, Dictionary<string, string> paramaters = null)
        {
            var baseUrl = _serverUrl + "/v3/tron";

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

            var baseUrl = _serverUrl + "/v3/tron";

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

            var baseUrl = _serverUrl + "/v3/tron";

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
            var baseUrl = _serverUrl + "/v3/tron";

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
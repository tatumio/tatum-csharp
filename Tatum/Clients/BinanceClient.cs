using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
//using Microsoft.Extensions.Http;
using System.Security;
//using NBitcoin;
using Tatum.Model.Requests;
using Tatum.Model.Responses;
using System.ComponentModel.DataAnnotations;
using BinanceClient.Crypto;
using System.Collections.Generic;
using System.IO;
using System;

/// <summary>
/// Summary description for BinanceClient
/// </summary>
/// 
namespace Tatum
{
    public class BinanceClient : IBinanceClient
    {

        private readonly string _privateKey;
        private readonly string _serverUrl;
        public BinanceClient(string privateKey, string serverUrl)
        {
            _privateKey = privateKey;
            _serverUrl = serverUrl;
        }




        Wallets IBinanceClient.CreateWallet(string mnemonic, bool testnet)
        {

          
            var walletInfo = Wallet.CreateRandomAccount( testnet ? Network.Test : Network.Mainnet);
            

            return new Wallets
            {
                Mnemonic =  walletInfo.Mnemonic,
                Address= walletInfo.Address,
                PrivateKey=walletInfo.PrivateKey
                
            };
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
            var baseUrl = serverUrl + "/v3/bnb";

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

            var baseUrl = serverUrl + "/v3/bnb";

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

            var baseUrl = serverUrl + "/v3/bnb";

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
            var baseUrl = serverUrl + "/v3/bnb";

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
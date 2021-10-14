﻿using System;
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
/// Summary description for PolygonClient
/// </summary>
/// 
namespace Tatum
{
    public class PolygonClient
    {
        private readonly string _privateKey;
        public PolygonClient(string privateKey)
        {
            _privateKey = privateKey;
        }


        public async Task<Polygon> GeneratePolygonWallet(string mnemonic)
        {

            var stringResult = await GetSecureRequest($"wallet?mnemonic=" + mnemonic);

            var result = JsonConvert.DeserializeObject<Polygon>(stringResult);

            return result;
        }

        public async Task<Polygon> GeneratePolygonAccountAddressFromPublicKey(string xpub, int index)
        {

            var stringResult = await GetSecureRequest($"address/{xpub}/{index}");

            var result = JsonConvert.DeserializeObject<Polygon>(stringResult);

            return result;
        }

        public async Task<Polygon> GeneratePolygonPrivateKey(int index, string mnemonic)
        {
            string parameters = "{\"index\":" + "\"" + index + "" + "\",\"mnemonic\":" + "\"" + mnemonic + "" + "\"}";
            var stringResult = await PostSecureRequest($"wallet/priv", parameters);

            var result = JsonConvert.DeserializeObject<Polygon>(stringResult);

            return result;
        }

        public async Task<Polygon> Web3HttpDriver(string xapikey)
        {
            string parameters = "{\"jsonrpc\":\"2.0\",\"method\":\"web3_clientVersion\",\"params\":[],\"id\":2}";

            var stringResult = await PostSecureRequest($"web3/{xapikey}", parameters);

            var result = JsonConvert.DeserializeObject<Polygon>(stringResult);

            return result;
        }


        public async Task<Polygon> GetCurrentBlockNumber()
        {

            var stringResult = await GetSecureRequest($"block/current");

            var result = JsonConvert.DeserializeObject<Polygon>(stringResult);

            return result;
        }

        public async Task<Polygon> GetPolygonBlockByHash(string hash)
        {

            var stringResult = await GetSecureRequest($"block/{hash}");

            var result = JsonConvert.DeserializeObject<Polygon>(stringResult);

            return result;
        }

        public async Task<Polygon> GetPolygonAccountBalance(string address)
        {

            var stringResult = await GetSecureRequest($"balance/{address}");

            var result = JsonConvert.DeserializeObject<Polygon>(stringResult);

            return result;
        }

        public async Task<Polygon> GetPolygonTransaction(string hash)
        {

            var stringResult = await GetSecureRequest($"transaction/{hash}");

            var result = JsonConvert.DeserializeObject<Polygon>(stringResult);

            return result;
        }

        public async Task<Polygon> GetCountOutgoingPolygonTransaction(string address)
        {

            var stringResult = await GetSecureRequest($"transaction/count/{address}");

            var result = JsonConvert.DeserializeObject<Polygon>(stringResult);

            return result;
        }




        public async Task<Polygon> SendTransferPolygonBlockchain(string data, string to, string currency, string gaslimit, string gasprice, string amount, string fromprivatekey)
        {
            string parameters = "{\"data\":" + "\"" + data + "" + "\",\"to\":" + "\"" + to + "" + "\",\"currency\":" + "\"" + currency + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"},\"amount\":" + "\"" + amount + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\"}";

            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<Polygon>(stringResult);

            return result;
        }

        public async Task<Polygon> SendTransferPolygonBlockchainKMS(string data, string to, string currency, string gaslimit, string gasprice, string amount, int index, string signatureid)
        {
            string parameters = "{\"data\":" + "\"" + data + "" + "\",\"to\":" + "\"" + to + "" + "\",\"currency\":" + "\"" + currency + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"},\"amount\":" + "\"" + amount + "" + "\",\"index\":" + "\"" + index + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\"}";

            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<Polygon>(stringResult);

            return result;
        }



        public async Task<Polygon> EstimatePolygonTransactionFees(string from, string to, string amount, string data)
        {
            string parameters = "{\"from\":" + "\"" + from + "" + "\",\"to\":" + "\"" + to + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"data\":" + "\"" + data + "" + "\"}";

            var stringResult = await PostSecureRequest($"gas", parameters);

            var result = JsonConvert.DeserializeObject<Polygon>(stringResult);

            return result;
        }







        public async Task<Polygon> CallPolygonSmartContractReadMethod(string contractaddress, string methodname, string methodabi, string[] contractparams)
        {
            string parameters = "{\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"methodName\":" + "\"" + methodname + "" + "\",\"methodABI\":{" + "\"" + methodabi + "" + "\"},\"params\":[" + "\"" + contractparams + "" + "\"]}";
            var stringResult = await PostSecureRequest($"smartcontract", parameters);

            var result = JsonConvert.DeserializeObject<Polygon>(stringResult);

            return result;
        }


        public async Task<Polygon> CallPolygonSmartContractMethod(string contractaddress,string amount, string methodname, string methodabi, string[] contractparams, string fromprivatekey, string gaslimit, string gasprice)
        {
            string parameters = "{\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"methodName\":" + "\"" + methodname + "" + "\",\"methodABI\":{" + "\"" + methodabi + "" + "\"},\"params\":[" + "\"" + contractparams + "" + "\"],\"amount\":" + "\"" +  amount + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}";
            var stringResult = await PostSecureRequest($"smartcontract", parameters);

            var result = JsonConvert.DeserializeObject<Polygon>(stringResult);

            return result;
        }

        public async Task<Polygon> CallPolygonSmartContractMethodKMS(string contractaddress, string methodname, string methodabi, string[] contractparams, int index, string signatureid, string gaslimit, string gasprice)
        {
            string parameters = "{\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"methodName\":" + "\"" + methodname + "" + "\",\"methodABI\":{" + "\"" + methodabi + "" + "\"},\"params\":[" + "\"" + contractparams + "" + "\"],\"index\":" + "\"" + index + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}";
            var stringResult = await PostSecureRequest($"smartcontract", parameters);

            var result = JsonConvert.DeserializeObject<Polygon>(stringResult);

            return result;
        }




        public async Task<Polygon> BroadcastSignedAdaTransaction(string txData, string signatureId)
        {
            string parameters = "{\"txData\":" + "\"" + txData + "" + "\",\"signatureId\":" + "\"" + signatureId + "" + "\"}";

            var stringResult = await PostSecureRequest($"broadcast", parameters);

            var result = JsonConvert.DeserializeObject<Polygon>(stringResult);

            return result;
        }
























        private async Task<string> GetSecureRequest(string path, Dictionary<string, string> paramaters = null)
        {
            var baseUrl = "https://api-eu1.tatum.io/v3/polygon";

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

            var baseUrl = "https://api-eu1.tatum.io/v3/polygon";

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

            var baseUrl = "https://api-eu1.tatum.io/v3/polygon";

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
            var baseUrl = "https://api-eu1.tatum.io/v3/polygon";

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
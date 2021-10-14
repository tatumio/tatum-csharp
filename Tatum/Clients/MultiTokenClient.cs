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
/// Summary description for MultiTokenClient
/// </summary>
/// 
namespace Tatum
{
    public class MultiTokenClient
    {


        private readonly string _privateKey;
        public MultiTokenClient(string privateKey)
        {
            _privateKey = privateKey;
        }



        public async Task<MultiToken> DeployMultiToken(string chain, string uri, string fromprivatekey, string gaslimit, string gasprice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"uri\":" + "\"" + uri + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}";
            var stringResult = await PostSecureRequest($"deploy", parameters);

            var result = JsonConvert.DeserializeObject<MultiToken>(stringResult);

            return result;
        }


        public async Task<MultiToken> DeployMultiTokenKMS(string chain, string uri, string signatureid, string gaslimit, string gasprice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"uri\":" + "\"" + uri + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}";
            var stringResult = await PostSecureRequest($"deploy", parameters);

            var result = JsonConvert.DeserializeObject<MultiToken>(stringResult);

            return result;
        }

        public async Task<MultiToken> DeployMultiTokenCelo(string chain, string uri, string fromprivatekey, string feecurrency)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"uri\":" + "\"" + uri + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"feeCurrency\":" + "\"" + feecurrency + "" + "\"}";
            var stringResult = await PostSecureRequest($"deploy", parameters);

            var result = JsonConvert.DeserializeObject<MultiToken>(stringResult);

            return result;
        }

        public async Task<MultiToken> DeployMultiTokenCeloKMS(string chain, string uri, string signatureid, string feecurrency)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"uri\":" + "\"" + uri + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"feeCurrency\":" + "\"" + feecurrency + "" + "\"}";
            var stringResult = await PostSecureRequest($"deploy", parameters);

            var result = JsonConvert.DeserializeObject<MultiToken>(stringResult);

            return result;
        }











        public async Task<MultiToken> MintMultiToken(string chain, string tokenid, string to, string contractaddress, string amount, string data, int index, string signatureid, string gaslimit, string gasprice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"to\":" + "\"" + to + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"data\":" + "\"" + data + "" + "\",\"index\":" + "\"" + index + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}";
            var stringResult = await PostSecureRequest($"mint", parameters);

            var result = JsonConvert.DeserializeObject<MultiToken>(stringResult);

            return result;
        }


        public async Task<MultiToken> MintMultiTokenKMS(string chain, string tokenid, string to, string contractaddress, string amount, string data, int index, string signatureid, string gaslimit, string gasprice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"to\":" + "\"" + to + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"data\":" + "\"" + data + "" + "\",\"index\":" + "\"" + index + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}";
            var stringResult = await PostSecureRequest($"mint", parameters);

            var result = JsonConvert.DeserializeObject<MultiToken>(stringResult);

            return result;
        }


        public async Task<MultiToken> MintMultiTokenCelo(string chain, string tokenid, string to, string contractaddress, string amount, string data, string fromprivatekey, string feecurrency)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"to\":" + "\"" + to + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"data\":" + "\"" + data + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"feeCurrency\":" + "\"" + feecurrency + "" + "\"}";
            var stringResult = await PostSecureRequest($"mint", parameters);

            var result = JsonConvert.DeserializeObject<MultiToken>(stringResult);

            return result;
        }

        public async Task<MultiToken> MintMultiTokenKMSCelo(string chain, string tokenid, string to, string contractaddress, string amount, string data, int index, string signatureid, string feecurrency)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"to\":" + "\"" + to + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"data\":" + "\"" + data + "" + "\",\"index\":" + "\"" + index + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"feeCurrency\":" + "\"" + feecurrency + "" + "\"}";
            var stringResult = await PostSecureRequest($"mint", parameters);

            var result = JsonConvert.DeserializeObject<MultiToken>(stringResult);

            return result;
        }











        public async Task<MultiToken> MintMultiTokenBatch(string chain, string[] tokenid, string to, string contractaddress, string[] amounts,string data, string fromprivatekey, string gaslimit, string gasprice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"to\":[" + "\"" + to + "" + "\"],\"tokenId\":[[" + "\"" + tokenid + "" + "\"]],\"amounts\":[[" + "\"" + amounts + "" + "\"]],\"data\":" + "\"" + data + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}}";
            var stringResult = await PostSecureRequest($"mint/batch", parameters);

            var result = JsonConvert.DeserializeObject<MultiToken>(stringResult);

            return result;
        }


        public async Task<MultiToken> MintMultiTokenBatchKMS(string chain, string tokenid, string to, string contractaddress, string amounts, string data, int index, string signatureid, string gaslimit, string gasprice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"to\":[" + "\"" + to + "" + "\"],\"tokenId\":[[" + "\"" + tokenid + "" + "\"]],\"amounts\":[[" + "\"" + amounts + "" + "\"]],\"data\":" + "\"" + data + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"index\":" + "\"" + index + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}}";
            var stringResult = await PostSecureRequest($"mint/batch", parameters);

            var result = JsonConvert.DeserializeObject<MultiToken>(stringResult);

            return result;
        }


        public async Task<MultiToken> MintMultiTokenBatchCelo(string chain, string tokenid, string to, string contractaddress, string amounts, string fromprivatekey, string feecurrency)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"to\":[" + "\"" + to + "" + "\"],\"tokenId\":[[" + "\"" + tokenid + "" + "\"]],\"amounts\":[[" + "\"" + amounts + "" + "\"]],\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"feeCurrency\":" + "\"" + feecurrency + "" + "\"}";
            var stringResult = await PostSecureRequest($"mint/batch", parameters);

            var result = JsonConvert.DeserializeObject<MultiToken>(stringResult);

            return result;
        }

        public async Task<MultiToken> MintMultiTokenBatchKMSCelo(string chain, string tokenid, string to, string contractaddress, string amounts, string data, int index, string signatureid, string feecurrency)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"to\":[" + "\"" + to + "" + "\"],\"tokenId\":[[" + "\"" + tokenid + "" + "\"]],\"amounts\":[[" + "\"" + amounts + "" + "\"]],\"data\":" + "\"" + data + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"index\":" + "\"" + index + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"feeCurrency\":" + "\"" + feecurrency + "" + "\"}";
            var stringResult = await PostSecureRequest($"mint/batch", parameters);

            var result = JsonConvert.DeserializeObject<MultiToken>(stringResult);

            return result;
        }









        public async Task<MultiToken> BurnMultiToken(string chain, string account, string tokenid, string contractaddress, string fromprivatekey, string data, string amount, string gaslimit, string gasprice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"account\":" + "\"" + account + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"data\":" + "\"" + data + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}";
            var stringResult = await PostSecureRequest($"burn", parameters);

            var result = JsonConvert.DeserializeObject<MultiToken>(stringResult);

            return result;
        }


        public async Task<MultiToken> BurnMultiTokenKMS(string chain, string account, string tokenid, string amount, string data, string contractaddress, int index, string signatureid, string gaslimit, string gasprice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"account\":" + "\"" + account + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"index\":" + "\"" + index + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"data\":" + "\"" + data + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}";
            var stringResult = await PostSecureRequest($"burn", parameters);

            var result = JsonConvert.DeserializeObject<MultiToken>(stringResult);

            return result;
        }


        public async Task<MultiToken> BurnMultiTokenCelo(string chain, string account, string tokenid, string amount, string contractaddress, string fromprivatekey, string feecurrency)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"account\":" + "\"" + account + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"feeCurrency\":" + "\"" + feecurrency + "" + "\"}";
            var stringResult = await PostSecureRequest($"burn", parameters);

            var result = JsonConvert.DeserializeObject<MultiToken>(stringResult);

            return result;
        }

        public async Task<MultiToken> BurnMultiTokenKMSCelo(string chain, string account, string tokenid, string amount, string data, string contractaddress, int index, string signatureid, string gaslimit, string gasprice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"account\":" + "\"" + account + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"index\":" + "\"" + index + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"data\":" + "\"" + data + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}";
            var stringResult = await PostSecureRequest($"burn", parameters);

            var result = JsonConvert.DeserializeObject<MultiToken>(stringResult);

            return result;
        }











        public async Task<MultiToken> BurnMultiTokenBatch(string chain, string account, string[] tokenid, string amounts, string data, string contractaddress, string fromprivatekey, string gaslimit, string gasprice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"account\":" + "\"" + account + "" + "\",\"tokenId\":[[" + "\"" + tokenid + "" + "\"]],\"amounts\":[[" + "\"" + amounts + "" + "\"]],\"data\":" + "\"" + data + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}";
            var stringResult = await PostSecureRequest($"burn/batch", parameters);

            var result = JsonConvert.DeserializeObject<MultiToken>(stringResult);

            return result;
        }


        public async Task<MultiToken> BurnMultiTokenBatchKMS(string chain, string account, string tokenid, string amounts, string data, string contractaddress, int index, string signatureid, string gaslimit, string gasprice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"account\":" + "\"" + account + "" + "\",\"tokenId\":[[" + "\"" + tokenid + "" + "\"]],\"amounts\":[[" + "\"" + amounts + "" + "\"]],\"data\":" + "\"" + data + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"index\":" + "\"" + index + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}";
            var stringResult = await PostSecureRequest($"burn/batch", parameters);

            var result = JsonConvert.DeserializeObject<MultiToken>(stringResult);

            return result;
        }


        public async Task<MultiToken> BurnMultiTokenBatchCelo(string chain, string account, string tokenid, string amounts, string contractaddress, string fromprivatekey, string feecurrency)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"account\":" + "\"" + account + "" + "\",\"tokenId\":[[" + "\"" + tokenid + "" + "\"]],\"amounts\":[[" + "\"" + amounts + "" + "\"]],\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"feeCurrency\":" + "\"" + feecurrency + "" + "\"}";
            var stringResult = await PostSecureRequest($"burn/batch", parameters);

            var result = JsonConvert.DeserializeObject<MultiToken>(stringResult);

            return result;
        }


        public async Task<MultiToken> BurnMultiTokenBatchKMSCelo(string chain, string account, string tokenid, string amounts, string contractaddress, int index, string signatureid, string feecurrency)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"account\":" + "\"" + account + "" + "\",\"tokenId\":[[" + "\"" + tokenid + "" + "\"]],\"amounts\":[[" + "\"" + amounts + "" + "\"]],\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"index\":" + "\"" + index + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"feeCurrency\":" + "\"" + feecurrency + "" + "\"}";
            var stringResult = await PostSecureRequest($"burn/batch", parameters);

            var result = JsonConvert.DeserializeObject<MultiToken>(stringResult);

            return result;
        }








        public async Task<MultiToken> TransferMultiToken(string chain, string to, string tokenid, string amount, string data, string contractaddress, string fromprivatekey, string gaslimit, string gasprice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"to\":" + "\"" + to + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"data\":" + "\"" + data + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}}";
            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<MultiToken>(stringResult);

            return result;
        }


        public async Task<MultiToken> TransferMultiTokenCelo(string chain, string to, string tokenid, string amount, string data, string contractaddress, string fromprivatekey, string feecurrency)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"to\":" + "\"" + to + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"data\":" + "\"" + data + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"feeCurrency\":" + "\"" + feecurrency + "" + "\"}";
            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<MultiToken>(stringResult);

            return result;
        }


        public async Task<MultiToken> TransferMultiTokenKMS(string chain, string to, string tokenid, string amount, string data, string contractaddress, int index, string signatureid, string gaslimit, string gasprice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"to\":" + "\"" + to + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"data\":" + "\"" + data + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"index\":" + "\"" + index + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}}";
            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<MultiToken>(stringResult);

            return result;
        }


        public async Task<MultiToken> TransferMultiTokenKMSCelo(string chain, string to, string tokenid, string amount, string data, string contractaddress, int index, string signatureid, string feecurrency)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"to\":" + "\"" + to + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"data\":" + "\"" + data + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"index\":" + "\"" + index + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"feeCurrency\":" + "\"" + feecurrency + "" + "\"}";
            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<MultiToken>(stringResult);

            return result;
        }






        public async Task<MultiToken> TransferMultiTokenBatch(string chain, string to, string tokenid, string[] amounts, string data, string contractaddress, string fromprivatekey, string gaslimit, string gasprice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"to\":" + "\"" + to + "" + "\",\"tokenId\":[" + "\"" + tokenid + "" + "\"],\"amounts\":[" + "\"" + amounts + "" + "\"],\"data\":" + "\"" + data + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}}";
            var stringResult = await PostSecureRequest($"transaction/batch", parameters);

            var result = JsonConvert.DeserializeObject<MultiToken>(stringResult);

            return result;
        }


        public async Task<MultiToken> TransferMultiTokenBatchKMS(string chain, string to, string tokenid, string[] amounts, string data, string contractaddress, int index, string signatureid, string gaslimit, string gasprice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"to\":" + "\"" + to + "" + "\",\"tokenId\":[" + "\"" + tokenid + "" + "\"],\"amounts\":[" + "\"" + amounts + "" + "\"],\"data\":" + "\"" + data + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"index\":" + "\"" + index + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}}";
            var stringResult = await PostSecureRequest($"transaction/batch", parameters);

            var result = JsonConvert.DeserializeObject<MultiToken>(stringResult);

            return result;
        }


        public async Task<MultiToken> TransferMultiTokenBatchCelo(string chain, string to, string tokenid, string[] amounts, string data, string contractaddress, string fromprivatekey, string feecurrency)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"to\":" + "\"" + to + "" + "\",\"tokenId\":[" + "\"" + tokenid + "" + "\"],\"amounts\":[" + "\"" + amounts + "" + "\"],\"data\":" + "\"" + data + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"feeCurrency\":" + "\"" + feecurrency + "" + "\"}";
            var stringResult = await PostSecureRequest($"transaction/batch", parameters);

            var result = JsonConvert.DeserializeObject<MultiToken>(stringResult);

            return result;
        }


        public async Task<MultiToken> TransferMultiTokenBatchKMSCelo(string chain, string to, string tokenid, string[] amounts, string data, string contractaddress, int index, string signatureid, string feecurrency)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"to\":" + "\"" + to + "" + "\",\"tokenId\":[" + "\"" + tokenid + "" + "\"],\"amounts\":[" + "\"" + amounts + "" + "\"],\"data\":" + "\"" + data + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"index\":" + "\"" + index + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"feeCurrency\":" + "\"" + feecurrency + "" + "\"}";
            var stringResult = await PostSecureRequest($"transaction/batch", parameters);

            var result = JsonConvert.DeserializeObject<MultiToken>(stringResult);

            return result;
        }








        public async Task<MultiToken> GetContractAddress(string chain, string hash)
        {

            var stringResult = await GetSecureRequest($"address/{chain}/{hash}");

            var result = JsonConvert.DeserializeObject<MultiToken>(stringResult);

            return result;
        }



        public async Task<MultiToken> GetTransaction(string chain, string hash)
        {

            var stringResult = await GetSecureRequest($"transaction/{chain}/{hash}");

            var result = JsonConvert.DeserializeObject<MultiToken>(stringResult);

            return result;
        }

        public async Task<MultiToken> GetMultiTokenAccountBalance(string chain, string address, string contractaddress, string tokenid)
        {

            var stringResult = await GetSecureRequest($"balance/{chain}/{contractaddress}/{address}/{tokenid}");

            var result = JsonConvert.DeserializeObject<MultiToken>(stringResult);

            return result;
        }



        public async Task<MultiToken> GetMultiTokenAccountBatchBalance(string chain, string contractaddress,string tokenid,string address)
        {

            var stringResult = await GetSecureRequest($"balance/batch/{chain}/{contractaddress}?tokenId="+tokenid +" &address="+address);

            var result = JsonConvert.DeserializeObject<MultiToken>(stringResult);

            return result;
        }



        public async Task<MultiToken> GetMultiTokenMetadata(string chain, string token, string contractaddress)
        {

            var stringResult = await GetSecureRequest($"metadata/{chain}/{contractaddress}/{token}");

            var result = JsonConvert.DeserializeObject<MultiToken>(stringResult);

            return result;
        }



























        private async Task<string> GetSecureRequest(string path, Dictionary<string, string> paramaters = null)
        {
            var baseUrl = "https://api-eu1.tatum.io/v3/multitoken";

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

            var baseUrl = "https://api-eu1.tatum.io/v3/multitoken";

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

            var baseUrl = "https://api-eu1.tatum.io/v3/multitoken";

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
            var baseUrl = "https://api-eu1.tatum.io/v3/multitoken";

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
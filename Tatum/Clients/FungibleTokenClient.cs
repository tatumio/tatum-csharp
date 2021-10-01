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
/// Summary description for FungibleTokenClient
/// </summary>
/// 
namespace Tatum
{
    public class FungibleTokenClient
    {


        private readonly string _privateKey;
        public FungibleTokenClient(string privateKey)
        {
            _privateKey = privateKey;
        }



        public async Task<FungibleToken> ChainDeployErc20(string chain, string symbol, string name, string totalcap, string supply, int digits, string address, string fromprivatekey, string gaslimit, string gasprice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"symbol\":" + "\"" + symbol + "" + "\",\"name\":" + "\"" + name + "" + "\",\"totalCap\"" + "\"" + totalcap + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"digits\":" + "\"" + digits + "" + "\",\"address\":" + "\"" + address + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}}";
            var stringResult = await PostSecureRequest($"deploy", parameters);

            var result = JsonConvert.DeserializeObject<FungibleToken>(stringResult);

            return result;
        }

        public async Task<FungibleToken> ChainDeployErc20KMS(string chain, string symbol, string name, string totalcap, string supply, int digits, string address, string signatureid, string gaslimit, string gasprice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"symbol\":" + "\"" + symbol + "" + "\",\"name\":" + "\"" + name + "" + "\",\"totalCap\"" + "\"" + totalcap + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"digits\":" + "\"" + digits + "" + "\",\"address\":" + "\"" + address + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}}";
            var stringResult = await PostSecureRequest($"deploy", parameters);

            var result = JsonConvert.DeserializeObject<FungibleToken>(stringResult);

            return result;
        }


        public async Task<FungibleToken> ChainDeployCeloErc20(string chain, string symbol, string name, string totalcap, string supply, int digits, string address, string fromprivatekey, string feecurrency)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"symbol\":" + "\"" + symbol + "" + "\",\"name\":" + "\"" + name + "" + "\",\"totalCap\"" + "\"" + totalcap + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"digits\":" + "\"" + digits + "" + "\",\"address\":" + "\"" + address + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"feeCurrency\":" + "\"" + feecurrency + "" + "\"}";
            var stringResult = await PostSecureRequest($"deploy", parameters);

            var result = JsonConvert.DeserializeObject<FungibleToken>(stringResult);

            return result;
        }


        public async Task<FungibleToken> ChainDeployCeloErc20KMS(string chain, string symbol, string name, string totalcap, string supply, int digits, string address, string signatureid, string feecurrency)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"symbol\":" + "\"" + symbol + "" + "\",\"name\":" + "\"" + name + "" + "\",\"totalCap\"" + "\"" + totalcap + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"digits\":" + "\"" + digits + "" + "\",\"address\":" + "\"" + address + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"feeCurrency\":" + "\"" + feecurrency + "" + "\"}";
            var stringResult = await PostSecureRequest($"deploy", parameters);

            var result = JsonConvert.DeserializeObject<FungibleToken>(stringResult);

            return result;
        }










        public async Task<FungibleToken> ChainMintErc20(string chain, string amount, string to, string contractaddress, string fromprivatekey)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"to\":" + "\"" + to + "" + "\",\"contractAddress\"" + "\"" + contractaddress + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\"}";
            var stringResult = await PostSecureRequest($"mint", parameters);

            var result = JsonConvert.DeserializeObject<FungibleToken>(stringResult);

            return result;
        }


        public async Task<FungibleToken> ChainMintErc20KMS(string chain, string amount, string to, string contractaddress, string signatureid)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"to\":" + "\"" + to + "" + "\",\"contractAddress\"" + "\"" + contractaddress + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\"}";
            var stringResult = await PostSecureRequest($"mint", parameters);

            var result = JsonConvert.DeserializeObject<FungibleToken>(stringResult);

            return result;
        }

        public async Task<FungibleToken> ChainMintErc20(string chain, string amount, string to, string contractaddress, string fromprivatekey, string feecurrency)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"to\":" + "\"" + to + "" + "\",\"contractAddress\"" + "\"" + contractaddress + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"feeCurrency\":" + "\"" + feecurrency + "" + "\"}";
            var stringResult = await PostSecureRequest($"mint", parameters);

            var result = JsonConvert.DeserializeObject<FungibleToken>(stringResult);

            return result;
        }

        public async Task<FungibleToken> ChainMintCeloErc20KMS(string chain, string amount, string to, string contractaddress, string signatureid, string feecurrency)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"to\":" + "\"" + to + "" + "\",\"contractAddress\"" + "\"" + contractaddress + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"feeCurrency\":" + "\"" + feecurrency + "" + "\"}";
            var stringResult = await PostSecureRequest($"mint", parameters);

            var result = JsonConvert.DeserializeObject<FungibleToken>(stringResult);

            return result;
        }








        public async Task<FungibleToken> ChainBurnErc20(string chain, string amount, string contractaddress, string fromprivatekey)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"contractAddress\"" + "\"" + contractaddress + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\"}";
            var stringResult = await PostSecureRequest($"burn", parameters);

            var result = JsonConvert.DeserializeObject<FungibleToken>(stringResult);

            return result;
        }


        public async Task<FungibleToken> ChainBurnErc20KMS(string chain, string amount, string contractaddress, string signatureid)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"contractAddress\"" + "\"" + contractaddress + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\"}";
            var stringResult = await PostSecureRequest($"burn", parameters);

            var result = JsonConvert.DeserializeObject<FungibleToken>(stringResult);

            return result;
        }

        public async Task<FungibleToken> ChainBurnCeloErc20(string chain, string amount, string contractaddress, string fromprivatekey, string feecurrency)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"contractAddress\"" + "\"" + contractaddress + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"feeCurrency\":" + "\"" + feecurrency + "" + "\"}";
            var stringResult = await PostSecureRequest($"burn", parameters);

            var result = JsonConvert.DeserializeObject<FungibleToken>(stringResult);

            return result;
        }

        public async Task<FungibleToken> ChainBurnCeloErc20KMS(string chain, string amount, string contractaddress, string signatureid, string feecurrency)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"contractAddress\"" + "\"" + contractaddress + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"feeCurrency\":" + "\"" + feecurrency + "" + "\"}";
            var stringResult = await PostSecureRequest($"burn", parameters);

            var result = JsonConvert.DeserializeObject<FungibleToken>(stringResult);

            return result;
        }





        public async Task<FungibleToken> ApproveErc20(string chain, string amount, string spender, string contractaddress, string fromprivatekey)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"spender\":" + "\"" + spender + "" + "\",\"contractAddress\"" + "\"" + contractaddress + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\"}";
            var stringResult = await PostSecureRequest($"approve", parameters);

            var result = JsonConvert.DeserializeObject<FungibleToken>(stringResult);

            return result;
        }


        public async Task<FungibleToken> ApproveErc20KMS(string chain, string amount, string spender, string contractaddress, string signatureid)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"spender\":" + "\"" + spender + "" + "\",\"contractAddress\"" + "\"" + contractaddress + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\"}";
            var stringResult = await PostSecureRequest($"approve", parameters);

            var result = JsonConvert.DeserializeObject<FungibleToken>(stringResult);

            return result;
        }


        public async Task<FungibleToken> ApproveCeloErc20(string chain, string amount, string spender, string contractaddress, string fromprivatekey, string feecurrency)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"spender\":" + "\"" + spender + "" + "\",\"contractAddress\"" + "\"" + contractaddress + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"feeCurrency\":" + "\"" + feecurrency + "" + "\"}";
            var stringResult = await PostSecureRequest($"approve", parameters);

            var result = JsonConvert.DeserializeObject<FungibleToken>(stringResult);

            return result;
        }


        public async Task<FungibleToken> ApproveCeloErc20KMS(string chain, string amount, string spender, string contractaddress, string signatureid, string feecurrency)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"spender\":" + "\"" + spender + "" + "\",\"contractAddress\"" + "\"" + contractaddress + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"feeCurrency\":" + "\"" + feecurrency + "" + "\"}";
            var stringResult = await PostSecureRequest($"approve", parameters);

            var result = JsonConvert.DeserializeObject<FungibleToken>(stringResult);

            return result;
        }







        public async Task<FungibleToken> ChainTransferEthErc20(string chain, string currency, string to, string amount, string contractaddress, string digits, string fromprivatekey, string gaslimit, string gasprice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"currency\":" + "\"" + currency + "" + "\",\"to\":" + "\"" + to + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"contractAddress\"" + "\"" + contractaddress + "" + "\",\"digits\":" + "\"" + digits + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}";
            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<FungibleToken>(stringResult);

            return result;
        }


        public async Task<FungibleToken> ChainTransferEthErc20KMS(string chain, string currency, string to, string amount, string contractaddress, string digits, string signatureid, string gaslimit, string gasprice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"currency\":" + "\"" + currency + "" + "\",\"to\":" + "\"" + to + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"contractAddress\"" + "\"" + contractaddress + "" + "\",\"digits\":" + "\"" + digits + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}";
            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<FungibleToken>(stringResult);

            return result;
        }

        public async Task<FungibleToken> ChainTransferBscBep20(string chain, string to, string amount, string contractaddress, string digits, string fromprivatekey, string gaslimit, string gasprice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"to\":" + "\"" + to + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"contractAddress\"" + "\"" + contractaddress + "" + "\",\"digits\":" + "\"" + digits + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}";
            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<FungibleToken>(stringResult);

            return result;
        }


        public async Task<FungibleToken> ChainTransferBscBep20KMS(string chain, string currency, string to, string amount, string contractaddress, string digits, string signatureid, string gaslimit, string gasprice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"currency\":" + "\"" + currency + "" + "\",\"to\":" + "\"" + to + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"contractAddress\"" + "\"" + contractaddress + "" + "\",\"digits\":" + "\"" + digits + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}";
            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<FungibleToken>(stringResult);

            return result;
        }


        public async Task<FungibleToken> ChainTransferCeloErc20Token(string chain, string to, string amount, string contractaddress, string digits, string fromprivatekey, string feecurrency)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"to\":" + "\"" + to + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"contractAddress\"" + "\"" + contractaddress + "" + "\",\"digits\":" + "\"" + digits + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"feeCurrency\":" + "\"" + feecurrency + "" + "\"}";
            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<FungibleToken>(stringResult);

            return result;
        }


        public async Task<FungibleToken> ChainTransferCeloErc20TokenKMS(string chain, string to, string amount, string contractaddress, string digits, string signatureid, string feecurrency)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"to\":" + "\"" + to + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"contractAddress\"" + "\"" + contractaddress + "" + "\",\"digits\":" + "\"" + digits + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"feeCurrency\":" + "\"" + feecurrency + "" + "\"}";
            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<FungibleToken>(stringResult);

            return result;
        }






        public async Task<FungibleToken> GetErc20AccountBalance(string chain, string address, string contractaddress)
        {

            var stringResult = await GetSecureRequest($"balance/{chain}/{contractaddress}/{address}");

            var result = JsonConvert.DeserializeObject<FungibleToken>(stringResult);

            return result;
        }























        private async Task<string> GetSecureRequest(string path, Dictionary<string, string> paramaters = null)
        {
            var baseUrl = "https://api-eu1.tatum.io/v3/blockchain/token";

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

            var baseUrl = "https://api-eu1.tatum.io/v3/blockchain/token";

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

            var baseUrl = "https://api-eu1.tatum.io/v3/blockchain/token";

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
            var baseUrl = "https://api-eu1.tatum.io/v3/blockchain/token";

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
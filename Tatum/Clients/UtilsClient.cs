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
/// Summary description for UtilsClient
/// </summary>
/// 
namespace Tatum
{
    public class UtilsClient
    {
        private readonly string _privateKey;
        public UtilsClient(string privateKey)
        {
            _privateKey = privateKey;
        }




        public async Task<Utils> EstimateFee(string chain, string type)
        {

            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"type\":" + "\"" + type + "" + "\"}";


            var stringResult = await PostSecureRequest($"estimate", parameters);

            var result = JsonConvert.DeserializeObject<Utils>(stringResult);

            return result;
        }



        public async Task<Utils> EstimateFeeFromAddress(string chain, string type, string frommAddress, string toAddress, string value)
        {

            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"type\":" + "\"" + type + "" + "\",\"fromAddress\":" + "\"" + frommAddress + "" + "\",\"to\":[{\"Address\":" + "\"" + toAddress + "" + "\",\"value\":" + "\"" + value + "" + "\"}]}";


            var stringResult = await PostSecureRequest($"estimate", parameters);

            var result = JsonConvert.DeserializeObject<Utils>(stringResult);

            return result;
        }



        public async Task<Utils> EstimateFeeFromAddress(string chain, string type, string txhash, int index, string toAddress, string value)
        {

            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"type\":" + "\"" + type + "" + "\",\"fromUTXO\":[{\"txHash\":" + "\"" + txhash + "" + "\",\"index\":" + "\"" + index + "" + "\"}],\"to\":[{\"Address\":" + "\"" + toAddress + "" + "\",\"value\":" + "\"" + value + "" + "\"}]}";


            var stringResult = await PostSecureRequest($"estimate", parameters);

            var result = JsonConvert.DeserializeObject<Utils>(stringResult);

            return result;
        }





        public async Task<Utils> GetContractAddressFromTransaction(string chain, string hash)
        {


            var stringResult = await GetSecureRequest($"sc/address/{chain}/{hash}");

            var result = JsonConvert.DeserializeObject<Utils>(stringResult);

            return result;
        }








        public async Task<Utils> GenerateCustodialWallet(string chain, string fromPrivateKey, bool enableFungibleTokens, bool enableNonFungibleTokens, bool enableSemiFungibleTokens, bool enableBatchTransactions, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"fromPrivateKey\":" + "\"" + fromPrivateKey + "" + "\",\"enableFungibleTokens\":" + "\"" + enableFungibleTokens + "" + "\",\"enableNonFungibleTokens\":" + "\"" + enableNonFungibleTokens + "" + "\",\"enableSemiFungibleTokens\":" + "\"" + enableSemiFungibleTokens + "" + "\",\"enableBatchTransactions\":" + "\"" + enableBatchTransactions + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PostSecureRequest($"sc/custodial", parameters);

            var result = JsonConvert.DeserializeObject<Utils>(stringResult);

            return result;
        }

        public async Task<Utils> GenerateCustodialWalletKMS(string chain, string signatureId, int index, bool enableFungibleTokens, bool enableNonFungibleTokens, bool enableSemiFungibleTokens, bool enableBatchTransactions, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"signatureId\":" + "\"" + signatureId + "" + "\",\"index\":" + "\"" + index + "" + "\",\"enableFungibleTokens\":" + "\"" + enableFungibleTokens + "" + "\",\"enableNonFungibleTokens\":" + "\"" + enableNonFungibleTokens + "" + "\",\"enableSemiFungibleTokens\":" + "\"" + enableSemiFungibleTokens + "" + "\",\"enableBatchTransactions\":" + "\"" + enableBatchTransactions + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PostSecureRequest($"sc/custodial", parameters);

            var result = JsonConvert.DeserializeObject<Utils>(stringResult);

            return result;
        }
        public async Task<Utils> GenerateCustodialWalletCelo(string chain, string feeCurrency, string fromPrivateKey, bool enableFungibleTokens, bool enableNonFungibleTokens, bool enableSemiFungibleTokens, bool enableBatchTransactions, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"feeCurrency\":" + "\"" + feeCurrency + "" + "\",\"fromPrivateKey\":" + "\"" + fromPrivateKey + "" + "\",\"enableFungibleTokens\":" + "\"" + enableFungibleTokens + "" + "\",\"enableNonFungibleTokens\":" + "\"" + enableNonFungibleTokens + "" + "\",\"enableSemiFungibleTokens\":" + "\"" + enableSemiFungibleTokens + "" + "\",\"enableBatchTransactions\":" + "\"" + enableBatchTransactions + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PostSecureRequest($"sc/custodial", parameters);

            var result = JsonConvert.DeserializeObject<Utils>(stringResult);

            return result;
        }
        public async Task<Utils> GenerateCustodialWalletCeloKMS(string chain, string feeCurrency, string signatureId, int index, bool enableFungibleTokens, bool enableNonFungibleTokens, bool enableSemiFungibleTokens, bool enableBatchTransactions, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"signatureId\":" + "\"" + signatureId + "" + "\",\"index\":" + "\"" + index + "" + "\",\"enableFungibleTokens\":" + "\"" + enableFungibleTokens + "" + "\",\"enableNonFungibleTokens\":" + "\"" + enableNonFungibleTokens + "" + "\",\"enableSemiFungibleTokens\":" + "\"" + enableSemiFungibleTokens + "" + "\",\"enableBatchTransactions\":" + "\"" + enableBatchTransactions + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PostSecureRequest($"sc/custodial", parameters);

            var result = JsonConvert.DeserializeObject<Utils>(stringResult);

            return result;
        }
        public async Task<Utils> GenerateCustodialWalletTron(string chain, int feeLimit, string fromPrivateKey, bool enableFungibleTokens, bool enableNonFungibleTokens, bool enableSemiFungibleTokens, bool enableBatchTransactions)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"feeLimit\":" + "\"" + feeLimit + "" + "\",\"fromPrivateKey\":" + "\"" + fromPrivateKey + "" + "\",\"enableFungibleTokens\":" + "\"" + enableFungibleTokens + "" + "\",\"enableNonFungibleTokens\":" + "\"" + enableNonFungibleTokens + "" + "\",\"enableSemiFungibleTokens\":" + "\"" + enableSemiFungibleTokens + "" + "\",\"enableBatchTransactions\":" + "\"" + enableBatchTransactions + "" + "\"}";

            var stringResult = await PostSecureRequest($"sc/custodial", parameters);

            var result = JsonConvert.DeserializeObject<Utils>(stringResult);

            return result;
        }
        public async Task<Utils> GenerateCustodialWalletTronKMS(string chain, int feeLimit, string from, string signatureId, int index, bool enableFungibleTokens, bool enableNonFungibleTokens, bool enableSemiFungibleTokens, bool enableBatchTransactions)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"feeLimit\":" + "\"" + feeLimit + "" + "\",\"signatureId\":" + "\"" + signatureId + "" + "\",\"index\":" + "\"" + index + "" + "\",\"enableFungibleTokens\":" + "\"" + enableFungibleTokens + "" + "\",\"enableNonFungibleTokens\":" + "\"" + enableNonFungibleTokens + "" + "\",\"enableSemiFungibleTokens\":" + "\"" + enableSemiFungibleTokens + "" + "\",\"enableBatchTransactions\":" + "\"" + enableBatchTransactions + "" + "\"}";

            var stringResult = await PostSecureRequest($"sc/custodial", parameters);

            var result = JsonConvert.DeserializeObject<Utils>(stringResult);

            return result;
        }









        public async Task<Utils> TransferCustodialWallet(string chain, string custodialAddress, string tokenAddress, int contractType, string recipient, string amount, string tokenId, string fromPrivateKey, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"custodialAddress\":" + "\"" + custodialAddress + "" + "\",\"tokenAddress\":" + "\"" + tokenAddress + "" + "\",\"contractType\":" + "\"" + contractType + "" + "\",\"recipient\":" + "\"" + recipient + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"tokenId\":" + "\"" + tokenId + "" + "\",\"fromPrivateKey\":" + "\"" + fromPrivateKey + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PostSecureRequest($"sc/custodial/transfer", parameters);

            var result = JsonConvert.DeserializeObject<Utils>(stringResult);

            return result;
        }


        public async Task<Utils> TransferCustodialWalletKMS(string chain, string custodialAddress, string tokenAddress, int contractType, string recipient, string amount, string tokenId, string signatureId, int index, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"custodialAddress\":" + "\"" + custodialAddress + "" + "\",\"tokenAddress\":" + "\"" + tokenAddress + "" + "\",\"contractType\":" + "\"" + contractType + "" + "\",\"recipient\":" + "\"" + recipient + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"tokenId\":" + "\"" + tokenId + "" + "\",\"signatureId\":" + "\"" + signatureId + "" + "\",\"index\":" + "\"" + index + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PostSecureRequest($"sc/custodial/transfer", parameters);

            var result = JsonConvert.DeserializeObject<Utils>(stringResult);

            return result;
        }

        public async Task<Utils> TransferCustodialWalletCelo(string chain, string custodialAddress, string tokenAddress, int contractType, string recipient, string amount, string tokenId, string fromPrivateKey, string feecurrency, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"custodialAddress\":" + "\"" + custodialAddress + "" + "\",\"tokenAddress\":" + "\"" + tokenAddress + "" + "\",\"contractType\":" + "\"" + contractType + "" + "\",\"recipient\":" + "\"" + recipient + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"tokenId\":" + "\"" + tokenId + "" + "\",\"fromPrivateKey\":" + "\"" + fromPrivateKey + "" + "\",\"feeCurrency\":" + "\"" + feecurrency + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PostSecureRequest($"sc/custodial/transfer", parameters);

            var result = JsonConvert.DeserializeObject<Utils>(stringResult);

            return result;
        }

        public async Task<Utils> TransferCustodialWalletCeloKMS(string chain, string custodialAddress, string tokenAddress, int contractType, string recipient, string amount, string tokenId, string signatureId, int index, string feeCurrency, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"custodialAddress\":" + "\"" + custodialAddress + "" + "\",\"tokenAddress\":" + "\"" + tokenAddress + "" + "\",\"contractType\":" + "\"" + contractType + "" + "\",\"recipient\":" + "\"" + recipient + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"tokenId\":" + "\"" + tokenId + "" + "\",\"signatureId\":" + "\"" + signatureId + "" + "\",\"index\":" + "\"" + index + "" + "\",\"feeCurrency\":" + "\"" + feeCurrency + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PostSecureRequest($"sc/custodial/transfer", parameters);

            var result = JsonConvert.DeserializeObject<Utils>(stringResult);

            return result;
        }

        public async Task<Utils> TransferCustodialWalletTron(string chain, string custodialAddress, string tokenAddress, int contractType, string recipient, string amount, string tokenId, string fromPrivateKey, int feeLimit)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"custodialAddress\":" + "\"" + custodialAddress + "" + "\",\"tokenAddress\":" + "\"" + tokenAddress + "" + "\",\"contractType\":" + "\"" + contractType + "" + "\",\"recipient\":" + "\"" + recipient + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"tokenId\":" + "\"" + tokenId + "" + "\",\"fromPrivateKey\":" + "\"" + fromPrivateKey + "" + "\",\"feeLimit\":" + "\"" + feeLimit + "" + "\"}";

            var stringResult = await PostSecureRequest($"sc/custodial/transfer", parameters);

            var result = JsonConvert.DeserializeObject<Utils>(stringResult);

            return result;
        }

        public async Task<Utils> TransferCustodialWalletTronKMS(string chain, string custodialAddress, string tokenAddress, int contractType, string recipient, string amount, string tokenId, string signatureId, int index, int feeLimit, string from)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"custodialAddress\":" + "\"" + custodialAddress + "" + "\",\"tokenAddress\":" + "\"" + tokenAddress + "" + "\",\"contractType\":" + "\"" + contractType + "" + "\",\"recipient\":" + "\"" + recipient + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"tokenId\":" + "\"" + tokenId + "" + "\",\"signatureId\":" + "\"" + signatureId + "" + "\",\"index\":" + "\"" + index + "" + "\",\"feeLimit\":" + "\"" + feeLimit + "" + "\",\"from\":" + "\"" + from + "" + "\"}";

            var stringResult = await PostSecureRequest($"sc/custodial/transfer", parameters);

            var result = JsonConvert.DeserializeObject<Utils>(stringResult);

            return result;
        }













        public async Task<Utils> TransferCustodialWalletBatch(string chain, string custodialAddress, string tokenAddress, int contractType, string recipient, string amount, string tokenId, string fromPrivateKey, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"custodialAddress\":" + "\"" + custodialAddress + "" + "\",\"tokenAddress\":" + "\"" + tokenAddress + "" + "\",\"contractType\":" + "\"" + contractType + "" + "\",\"recipient\":" + "\"" + recipient + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"tokenId\":" + "\"" + tokenId + "" + "\",\"fromPrivateKey\":" + "\"" + fromPrivateKey + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PostSecureRequest($"sc/custodial/transfer/batch", parameters);

            var result = JsonConvert.DeserializeObject<Utils>(stringResult);

            return result;
        }


        public async Task<Utils> TransferCustodialWalletBatchKMS(string chain, string custodialAddress, string tokenAddress, int contractType, string recipient, string amount, string tokenId, string signatureId, int index, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"custodialAddress\":" + "\"" + custodialAddress + "" + "\",\"tokenAddress\":" + "\"" + tokenAddress + "" + "\",\"contractType\":" + "\"" + contractType + "" + "\",\"recipient\":" + "\"" + recipient + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"tokenId\":" + "\"" + tokenId + "" + "\",\"signatureId\":" + "\"" + signatureId + "" + "\",\"index\":" + "\"" + index + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PostSecureRequest($"sc/custodial/transfer/batch", parameters);

            var result = JsonConvert.DeserializeObject<Utils>(stringResult);

            return result;
        }

        public async Task<Utils> TransferCustodialWalletBatchCelo(string chain, string custodialAddress, string tokenAddress, int contractType, string recipient, string amount, string tokenId, string fromPrivateKey, string feecurrency, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"custodialAddress\":" + "\"" + custodialAddress + "" + "\",\"tokenAddress\":" + "\"" + tokenAddress + "" + "\",\"contractType\":" + "\"" + contractType + "" + "\",\"recipient\":" + "\"" + recipient + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"tokenId\":" + "\"" + tokenId + "" + "\",\"fromPrivateKey\":" + "\"" + fromPrivateKey + "" + "\",\"feeCurrency\":" + "\"" + feecurrency + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PostSecureRequest($"sc/custodial/transfer/batch", parameters);

            var result = JsonConvert.DeserializeObject<Utils>(stringResult);

            return result;
        }

        public async Task<Utils> TransferCustodialWalletBatchCeloKMS(string chain, string custodialAddress, string tokenAddress, int contractType, string recipient, string amount, string tokenId, string signatureId, int index, string feeCurrency, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"custodialAddress\":" + "\"" + custodialAddress + "" + "\",\"tokenAddress\":" + "\"" + tokenAddress + "" + "\",\"contractType\":" + "\"" + contractType + "" + "\",\"recipient\":" + "\"" + recipient + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"tokenId\":" + "\"" + tokenId + "" + "\",\"signatureId\":" + "\"" + signatureId + "" + "\",\"index\":" + "\"" + index + "" + "\",\"feeCurrency\":" + "\"" + feeCurrency + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PostSecureRequest($"sc/custodial/transfer/batch", parameters);

            var result = JsonConvert.DeserializeObject<Utils>(stringResult);

            return result;
        }

        public async Task<Utils> TransferCustodialWalletBatchTron(string chain, string custodialAddress, string tokenAddress, int contractType, string recipient, string amount, string tokenId, string fromPrivateKey, int feeLimit)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"custodialAddress\":" + "\"" + custodialAddress + "" + "\",\"tokenAddress\":" + "\"" + tokenAddress + "" + "\",\"contractType\":" + "\"" + contractType + "" + "\",\"recipient\":" + "\"" + recipient + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"tokenId\":" + "\"" + tokenId + "" + "\",\"fromPrivateKey\":" + "\"" + fromPrivateKey + "" + "\",\"feeLimit\":" + "\"" + feeLimit + "" + "\"}";

            var stringResult = await PostSecureRequest($"sc/custodial/transfer/batch", parameters);

            var result = JsonConvert.DeserializeObject<Utils>(stringResult);

            return result;
        }

        public async Task<Utils> TransferCustodialWalletBatchTronKMS(string chain, string custodialAddress, string tokenAddress, int contractType, string recipient, string amount, string tokenId, string signatureId, int index, int feeLimit, string from)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"custodialAddress\":" + "\"" + custodialAddress + "" + "\",\"tokenAddress\":" + "\"" + tokenAddress + "" + "\",\"contractType\":" + "\"" + contractType + "" + "\",\"recipient\":" + "\"" + recipient + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"tokenId\":" + "\"" + tokenId + "" + "\",\"signatureId\":" + "\"" + signatureId + "" + "\",\"index\":" + "\"" + index + "" + "\",\"feeLimit\":" + "\"" + feeLimit + "" + "\",\"from\":" + "\"" + from + "" + "\"}";

            var stringResult = await PostSecureRequest($"sc/custodial/transfer/batch", parameters);

            var result = JsonConvert.DeserializeObject<Utils>(stringResult);

            return result;
        }




















        private async Task<string> GetSecureRequest(string path, Dictionary<string, string> paramaters = null)
        {
            var baseUrl = "https://api-eu1.tatum.io/v3/blockchain";

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

            var baseUrl = "https://api-eu1.tatum.io/v3/blockchain";

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

            var baseUrl = "https://api-eu1.tatum.io/v3/blockchain";

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
            var baseUrl = "https://api-eu1.tatum.io/v3/blockchain";

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
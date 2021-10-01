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
/// Summary description for BitcoinCashClient
/// </summary>
/// 

namespace Tatum
{
    public class MarketplaceClient
    {
        private readonly string _privateKey;
        public MarketplaceClient(string privateKey)
        {
            _privateKey = privateKey;
        }



        public async Task<Marketplace> GenerateMarketplace(string chain, string feeRecipient, string marketplaceFee, string fromPrivateKey, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"feeRecipient\":" + "\"" + feeRecipient + "" + "\",\"marketplaceFee\":" + "\"" + marketplaceFee + "" + "\",\"fromPrivateKey\":" + "\"" + fromPrivateKey + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PostSecureRequest($"listing",parameters);

            var result = JsonConvert.DeserializeObject<Marketplace>(stringResult);

            return result;
        }

        public async Task<Marketplace> GenerateMarketplaceKMS(string chain, string feeRecipient, string marketplaceFee, string signatureId, int index, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"feeRecipient\":" + "\"" + feeRecipient + "" + "\",\"marketplaceFee\":" + "\"" + marketplaceFee + "" + "\",\"signatureId\":" + "\"" + signatureId + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PostSecureRequest($"listing", parameters);

            var result = JsonConvert.DeserializeObject<Marketplace>(stringResult);

            return result;
        }

        public async Task<Marketplace> GenerateMarketplaceCelo(string chain, string feeRecipient, string feeCurrency, string marketplaceFee, string fromPrivateKey, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"feeRecipient\":" + "\"" + feeRecipient + "" + "\",\"feeCurrency\":" + "\"" + feeCurrency + "" + "\",\"marketplaceFee\":" + "\"" + marketplaceFee + "" + "\",\"fromPrivateKey\":" + "\"" + fromPrivateKey + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PostSecureRequest($"listing", parameters);

            var result = JsonConvert.DeserializeObject<Marketplace>(stringResult);

            return result;
        }

        public async Task<Marketplace> GenerateMarketplaceCeloKMS(string chain, string feeRecipient, string feeCurrency, string marketplaceFee, string signatureId, int index, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"feeRecipient\":" + "\"" + feeRecipient + "" + "\",\"feeCurrency\":" + "\"" + feeCurrency + "" + "\",\"marketplaceFee\":" + "\"" + marketplaceFee + "" + "\",\"signatureId\":" + "\"" + signatureId + "" + "\",\"index\":" + "\"" + index + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PostSecureRequest($"listing", parameters);

            var result = JsonConvert.DeserializeObject<Marketplace>(stringResult);

            return result;
        }










        public async Task<Marketplace> SellAssetOnMarketplace(string chain, string contractAddress, string nftAddress, string seller, string erc20Address, string listingId, string amount, string tokenId, string price, bool isErc721, string fromPrivateKey, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"contractAddress\":" + "\"" + contractAddress + "" + "\",\"nftAddress\":" + "\"" + nftAddress + "" + "\",\"seller\":" + "\"" + seller + "" + "\",\"erc20Address\":" + "\"" + erc20Address + "" + "\",\"listingId\":" + "\"" + listingId + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"tokenId\":" + "\"" + tokenId + "" + "\",\"price\":" + "\"" + price + "" + "\",\"isErc721\":" + "\"" + isErc721 + "" + "\",\"fromPrivateKey\":" + "\"" + fromPrivateKey + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PostSecureRequest($"listing/sell", parameters);

            var result = JsonConvert.DeserializeObject<Marketplace>(stringResult);

            return result;
        }

        public async Task<Marketplace> SellAssetOnMarketplaceKMS(string chain, string contractAddress, string nftAddress, string seller, string erc20Address, string listingId, string amount, string tokenId, string price, bool isErc721, string signatureId, int index, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"contractAddress\":" + "\"" + contractAddress + "" + "\",\"nftAddress\":" + "\"" + nftAddress + "" + "\",\"seller\":" + "\"" + seller + "" + "\",\"erc20Address\":" + "\"" + erc20Address + "" + "\",\"listingId\":" + "\"" + listingId + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"tokenId\":" + "\"" + tokenId + "" + "\",\"price\":" + "\"" + price + "" + "\",\"isErc721\":" + "\"" + isErc721 + "" + "\",\"signatureId\":" + "\"" + signatureId + "" + "\",\"index\":" + "\"" + index + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PostSecureRequest($"listing/sell", parameters);

            var result = JsonConvert.DeserializeObject<Marketplace>(stringResult);

            return result;
        }

        public async Task<Marketplace> SellAssetOnMarketplaceCelo(string chain, string feeCurrency, string contractAddress, string nftAddress, string seller, string erc20Address, string listingId, string amount, string tokenId, string price, bool isErc721, string fromPrivateKey, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"feeCurrency\":" + "\"" + feeCurrency + "" + "\",\"contractAddress\":" + "\"" + contractAddress + "" + "\",\"nftAddress\":" + "\"" + nftAddress + "" + "\",\"seller\":" + "\"" + seller + "" + "\",\"erc20Address\":" + "\"" + erc20Address + "" + "\",\"listingId\":" + "\"" + listingId + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"tokenId\":" + "\"" + tokenId + "" + "\",\"price\":" + "\"" + price + "" + "\",\"isErc721\":" + "\"" + isErc721 + "" + "\",\"fromPrivateKey\":" + "\"" + fromPrivateKey + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PostSecureRequest($"listing/sell", parameters);

            var result = JsonConvert.DeserializeObject<Marketplace>(stringResult);

            return result;
        }


        public async Task<Marketplace> SellAssetOnMarketplaceCeloKMS(string chain, string feeCurrency, string contractAddress, string nftAddress, string seller, string erc20Address, string listingId, string amount, string tokenId, string price, bool isErc721, string signatureId, int index, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"feeCurrency\":" + "\"" + feeCurrency + "" + "\",\"contractAddress\":" + "\"" + contractAddress + "" + "\",\"nftAddress\":" + "\"" + nftAddress + "" + "\",\"seller\":" + "\"" + seller + "" + "\",\"erc20Address\":" + "\"" + erc20Address + "" + "\",\"listingId\":" + "\"" + listingId + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"tokenId\":" + "\"" + tokenId + "" + "\",\"price\":" + "\"" + price + "" + "\",\"isErc721\":" + "\"" + isErc721 + "" + "\",\"signatureId\":" + "\"" + signatureId + "" + "\",\"index\":" + "\"" + index + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PostSecureRequest($"listing/sell", parameters);

            var result = JsonConvert.DeserializeObject<Marketplace>(stringResult);

            return result;
        }









        public async Task<Marketplace> BuyAssetOnMarketplace(string chain, string contractAddress, string erc20Address, string listingId, string amount, string fromPrivateKey, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"contractAddress\":" + "\"" + contractAddress + "" + "\",\"erc20Address\":" + "\"" + erc20Address + "" + "\",\"listingId\":" + "\"" + listingId + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"fromPrivateKey\":" + "\"" + fromPrivateKey + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PostSecureRequest($"listing/buy", parameters);

            var result = JsonConvert.DeserializeObject<Marketplace>(stringResult);

            return result;
        }

        public async Task<Marketplace> BuyAssetOnMarketplaceKMS(string chain, string contractAddress, string erc20Address, string listingId, string amount, string signatureId, int index, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"contractAddress\":" + "\"" + contractAddress + "" + "\",\"erc20Address\":" + "\"" + erc20Address + "" + "\",\"listingId\":" + "\"" + listingId + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"signatureId\":" + "\"" + signatureId + "" + "\",\"index\":" + "\"" + index + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PostSecureRequest($"listing/buy", parameters);

            var result = JsonConvert.DeserializeObject<Marketplace>(stringResult);

            return result;
        }

        public async Task<Marketplace> BuyAssetOnMarketplaceCelo(string chain, string feeCurrency, string contractAddress, string erc20Address, string listingId, string amount, string fromPrivateKey, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"feeCurrency\":" + "\"" + feeCurrency + "" + "\",\"contractAddress\":" + "\"" + contractAddress + "" + "\",\"erc20Address\":" + "\"" + erc20Address + "" + "\",\"listingId\":" + "\"" + listingId + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"fromPrivateKey\":" + "\"" + fromPrivateKey + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PostSecureRequest($"listing/buy", parameters);

            var result = JsonConvert.DeserializeObject<Marketplace>(stringResult);

            return result;
        }

        public async Task<Marketplace> BuyAssetOnMarketplaceCeloKMS(string chain, string feeCurrency, string contractAddress, string erc20Address, string listingId, string amount, string signatureId, int index, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"feeCurrency\":" + "\"" + feeCurrency + "" + "\",\"contractAddress\":" + "\"" + contractAddress + "" + "\",\"erc20Address\":" + "\"" + erc20Address + "" + "\",\"listingId\":" + "\"" + listingId + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"signatureId\":" + "\"" + signatureId + "" + "\",\"index\":" + "\"" + index + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PostSecureRequest($"listing/buy", parameters);

            var result = JsonConvert.DeserializeObject<Marketplace>(stringResult);

            return result;
        }









        public async Task<Marketplace> CancelSellAssetOnMarketplace(string chain, string contractAddress, string erc20Address, string listingId, string fromPrivateKey, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"contractAddress\":" + "\"" + contractAddress + "" + "\",\"erc20Address\":" + "\"" + erc20Address + "" + "\",\"listingId\":" + "\"" + listingId + "" + "\",\"fromPrivateKey\":" + "\"" + fromPrivateKey + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PostSecureRequest($"listing/cancel", parameters);

            var result = JsonConvert.DeserializeObject<Marketplace>(stringResult);

            return result;
        }

        public async Task<Marketplace> CancelSellAssetOnMarketplaceKMS(string chain, string erc20Address, string listingId, string signatureId, int index, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"erc20Address\":" + "\"" + erc20Address + "" + "\",\"listingId\":" + "\"" + listingId + "" + "\",\"signatureId\":" + "\"" + signatureId + "" + "\",\"index\":" + "\"" + index + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PostSecureRequest($"listing/cancel", parameters);

            var result = JsonConvert.DeserializeObject<Marketplace>(stringResult);

            return result;
        }

        public async Task<Marketplace> CancelSellAssetOnMarketplaceCelo(string chain, string feeCurrency, string erc20Address, string listingId,string amount, string fromPrivateKey, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"feeCurrency\":" + "\"" + feeCurrency + "" + "\",\"erc20Address\":" + "\"" + erc20Address + "" + "\",\"listingId\":" + "\"" + listingId + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"fromPrivateKey\":" + "\"" + fromPrivateKey + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PostSecureRequest($"listing/cancel", parameters);

            var result = JsonConvert.DeserializeObject<Marketplace>(stringResult);

            return result;
        }

        public async Task<Marketplace> CancelSellAssetOnMarketplaceCeloKMS(string chain, string feeCurrency, string erc20Address, string listingId, string signatureId, int index, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"feeCurrency\":" + "\"" + feeCurrency + "" + "\",\"erc20Address\":" + "\"" + erc20Address + "" + "\",\"listingId\":" + "\"" + listingId + "" + "\",\"signatureId\":" + "\"" + signatureId + "" + "\",\"index\":" + "\"" + index + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PostSecureRequest($"listing/cancel", parameters);

            var result = JsonConvert.DeserializeObject<Marketplace>(stringResult);

            return result;
        }












        public async Task<Marketplace> ApproveErc20MarketplaceSpending(string chain, string marketplaceAddress, string contractAddress, string amount, string fromPrivateKey, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"marketplaceAddress\":" + "\"" + marketplaceAddress + "" + "\",\"contractAddress\":" + "\"" + contractAddress + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"fromPrivateKey\":" + "\"" + fromPrivateKey + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PostSecureRequest($"listing/approve", parameters);

            var result = JsonConvert.DeserializeObject<Marketplace>(stringResult);

            return result;
        }

        public async Task<Marketplace> ApproveErc20MarketplaceSpendingKMS(string chain, string contractAddress, string marketplaceAddress, string amount, string signatureId, int index, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"contractAddress\":" + "\"" + contractAddress + "" + "\",\"marketplaceAddress\":" + "\"" + marketplaceAddress + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"signatureId\":" + "\"" + signatureId + "" + "\",\"index\":" + "\"" + index + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PostSecureRequest($"listing/approve", parameters);

            var result = JsonConvert.DeserializeObject<Marketplace>(stringResult);

            return result;
        }

        public async Task<Marketplace> ApproveErc20MarketplaceSpendingCelo(string chain, string feeCurrency, string contractAddress, string marketplaceAddress, string amount, string fromPrivateKey, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"feeCurrency\":" + "\"" + feeCurrency + "" + "\",\"contractAddress\":" + "\"" + contractAddress + "" + "\",\"marketplaceAddress\":" + "\"" + marketplaceAddress + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"fromPrivateKey\":" + "\"" + fromPrivateKey + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PostSecureRequest($"listing/approve", parameters);

            var result = JsonConvert.DeserializeObject<Marketplace>(stringResult);

            return result;
        }

        public async Task<Marketplace> ApproveErc20MarketplaceSpendingCeloKMS(string chain, string feeCurrency, string contractAddress, string marketplaceAddress, string amount, string signatureId, int index, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"feeCurrency\":" + "\"" + feeCurrency + "" + "\",\"contractAddress\":" + "\"" + contractAddress + "" + "\",\"marketplaceAddress\":" + "\"" + marketplaceAddress + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"signatureId\":" + "\"" + signatureId + "" + "\",\"index\":" + "\"" + index + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PostSecureRequest($"listing/approve", parameters);

            var result = JsonConvert.DeserializeObject<Marketplace>(stringResult);

            return result;
        }







        public async Task<Marketplace> GetListingFromNftMarketplace(string chain, string contractAddress, string id)
        {


            var stringResult = await GetSecureRequest($"listing/{chain}/{contractAddress}/listing/{id}");

            var result = JsonConvert.DeserializeObject<Marketplace>(stringResult);

            return result;
        }


        public async Task<Marketplace> GetNftMarketplaceFee(string chain, string contractAddress)
        {


            var stringResult = await GetSecureRequest($"listing/{chain}/{contractAddress}/fee");

            var result = JsonConvert.DeserializeObject<Marketplace>(stringResult);

            return result;
        }


        public async Task<Marketplace> GetNftMarketplaceRecipient(string chain, string contractAddress)
        {


            var stringResult = await GetSecureRequest($"listing/{chain}/{contractAddress}/recipient");

            var result = JsonConvert.DeserializeObject<Marketplace>(stringResult);

            return result;
        }









        public async Task<Marketplace> UpdateFeeRecipient(string chain, string contractAddress, string feeRecipient, string fromPrivateKey, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"contractAddress\":" + "\"" + contractAddress + "" + "\",\"feeRecipient\":" + "\"" + feeRecipient + "" + "\",\"fromPrivateKey\":" + "\"" + fromPrivateKey + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PUTSecureRequest($"listing/recipient", parameters);

            var result = JsonConvert.DeserializeObject<Marketplace>(stringResult);

            return result;
        }

        public async Task<Marketplace> UpdateFeeRecipientKMS(string chain, string feeRecipient, string signatureId, int index, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"feeRecipient\":" + "\"" + feeRecipient + "" + "\",\"signatureId\":" + "\"" + signatureId + "" + "\",\"index\":" + "\"" + index + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PUTSecureRequest($"listing/recipient", parameters);

            var result = JsonConvert.DeserializeObject<Marketplace>(stringResult);

            return result;
        }

        public async Task<Marketplace> UpdateFeeRecipientCelo(string chain, string feeCurrency, string feeRecipient, string fromPrivateKey, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"feeCurrency\":" + "\"" + feeCurrency + "" + "\",\"feeRecipient\":" + "\"" + feeRecipient + "" + "\",\"fromPrivateKey\":" + "\"" + fromPrivateKey + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PUTSecureRequest($"listing/recipient", parameters);

            var result = JsonConvert.DeserializeObject<Marketplace>(stringResult);

            return result;
        }

        public async Task<Marketplace> UpdateFeeRecipientCeloKMS(string chain, string feeCurrency, string feeRecipient, string signatureId, int index, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"feeCurrency\":" + "\"" + feeCurrency + "" + "\",\"feeRecipient\":" + "\"" + feeRecipient + "" + "\",\"signatureId\":" + "\"" + signatureId + "" + "\",\"index\":" + "\"" + index + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PUTSecureRequest($"listing/recipient", parameters);

            var result = JsonConvert.DeserializeObject<Marketplace>(stringResult);

            return result;
        }









        public async Task<Marketplace> UpdateFee(string chain, string contractAddress, string marketplaceFee, string fromPrivateKey, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"contractAddress\":" + "\"" + contractAddress + "" + "\",\"marketplaceFee\":" + "\"" + marketplaceFee + "" + "\",\"fromPrivateKey\":" + "\"" + fromPrivateKey + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PUTSecureRequest($"listing/fee", parameters);

            var result = JsonConvert.DeserializeObject<Marketplace>(stringResult);

            return result;
        }

        public async Task<Marketplace> UpdateFeeKMS(string chain, string marketplacefee, string signatureId, int index, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"marketplaceFee\":" + "\"" + marketplacefee + "" + "\",\"signatureId\":" + "\"" + signatureId + "" + "\",\"index\":" + "\"" + index + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PUTSecureRequest($"listing/fee", parameters);
                 
            var result = JsonConvert.DeserializeObject<Marketplace>(stringResult);

            return result;
        }

        public async Task<Marketplace> UpdateFeeCelo(string chain, string feeCurrency, string marketplaceFee, string fromPrivateKey, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"feeCurrency\":" + "\"" + feeCurrency + "" + "\",\"marketplaceFee\":" + "\"" + marketplaceFee + "" + "\",\"fromPrivateKey\":" + "\"" + fromPrivateKey + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PUTSecureRequest($"listing/fee", parameters);

            var result = JsonConvert.DeserializeObject<Marketplace>(stringResult);

            return result;
        }

        public async Task<Marketplace> UpdateFeeCeloKMS(string chain, string feeCurrency, string marketplaceFee, string amount, string signatureId, int index, string gasLimit, string gasPrice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"feeCurrency\":" + "\"" + feeCurrency + "" + "\",\"marketplaceFee\":" + "\"" + marketplaceFee + "" + "\",\"signatureId\":" + "\"" + signatureId + "" + "\",\"index\":" + "\"" + index + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}}";

            var stringResult = await PUTSecureRequest($"listing/fee", parameters);

            var result = JsonConvert.DeserializeObject<Marketplace>(stringResult);

            return result;
        }

















        private async Task<string> GetSecureRequest(string path, Dictionary<string, string> paramaters = null)
        {
            var baseUrl = "https://api-eu1.tatum.io/v3/blockchain/marketplace";

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

            var baseUrl = "https://api-eu1.tatum.io/v3/blockchain/marketplace";

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

            var baseUrl = "https://api-eu1.tatum.io/v3/blockchain/marketplace";

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
            var baseUrl = "https://api-eu1.tatum.io/v3/blockchain/marketplace";

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
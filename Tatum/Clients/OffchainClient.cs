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
/// Summary description for OffchainClient
/// </summary>
/// 
namespace Tatum
{
    public partial class OffchainClient:IOffchainClient
    {
        private readonly string _privateKey;
        public OffchainClient(string privateKey)
        {
            _privateKey = privateKey;
        }


        public async Task<Common> GenerateDepositAddress(string id)
        {
            string parameters = "";

            var stringResult = await PostSecureRequest($"account/{id}/address", parameters);

            var result = JsonConvert.DeserializeObject<Common>(stringResult);

            return result;
        }


        public async Task<List<Common>> GetDepositAddresses(string id)
        {
            

            var stringResult = await GetSecureRequest($"account/{id}/address");

            var result = JsonConvert.DeserializeObject<List<Common>>(stringResult);

            return result;
        }

        public async Task<List<Common>> GenerateDepositAddresses(string accountid)
        {

           


            string parameters = "{\"addresses\":[{\"accountId\":" + "\"" + accountid + "" + "\"}]}";

            var stringResult = await PostSecureRequest($"account/address/batch", parameters);

            var result = JsonConvert.DeserializeObject<List<Common>>(stringResult);

            return result;
        }

        public async Task<Common> CheckAddressExists(string currency, string address)
        {

           
            var stringResult = await GetSecureRequest($"account/address/{address}/{currency}");

            var result = JsonConvert.DeserializeObject<Common>(stringResult);

            return result;
        }

        public async Task<Common> RemoveDepositAddress(string id, string address)
        {


            var stringResult = await DeleteSecureRequest($"account/{id}/address/{address}");

            var result = JsonConvert.DeserializeObject<Common>(stringResult);

            return result;
        }

        public async Task<Common> AssignDepositAddress(string id, string address)
        {
            string parameters = "";

            var stringResult = await PostSecureRequest($"account/{id}/address/{address}",parameters);

            var result = JsonConvert.DeserializeObject<Common>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> EstimateBlockchainTransactionFee(string senderAccountId, string address, string amount, string multipleAmounts, string attr, string xpub)
        {
           
            string parameters = "{\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"multipleAmounts\":[" + "\"" + multipleAmounts + "" + "\"],\"attr\":" + "\"" + attr + "" + "\",\"xpub\":" + "\"" + xpub + "" + "\"}";

            var stringResult = await PostSecureRequest($"blockchain/estimate", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }


        // bitcoin
        public async Task<OffBlockchain> SendBitcoinToTatumAddressMnemonic(string senderAccountId, string address, string amount, string fee, string multipleAmounts, string attr, string mnemonic, string xpub, string paymentid, string sendernote)
        {
            string parameters = "{\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":false,\"fee\":" + "\"" + fee + "" + "\",\"multipleAmounts\":[" + "\"" + multipleAmounts + "" + "\"],\"attr\":" + "\"" + attr + "" + "\",\"mnemonic\":" + "\"" + mnemonic + "" + "\",\"xpub\":" + "\"" + xpub + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\"}";
          
            var stringResult = await PostSecureRequest($"bitcoin/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }
        public async Task<OffBlockchain> SendBitcoinToTatumAddressKeyPair(string senderAccountId, string address, string amount, string fee, string multipleAmounts, string accountaddress, string privatekey, string attr, string paymentid, string sendernote)
        {
            string parameters = "{\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":false,\"fee\":" + "\"" + fee + "" + "\",\"multipleAmounts\":[" + "\"" + multipleAmounts + "" + "\"],\"attr\":" + "\"" + attr + "" + "\",\"address\":" + "\"" + accountaddress + "" + "\",\"privatekey\":" + "\"" + privatekey + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\"}";

            var stringResult = await PostSecureRequest($"bitcoin/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> SendBitcoinToTatumAddressKms(string senderAccountId, string address, string amount, string fee, string multipleAmounts, string attr, string signatureid, string xpub, string paymentid, string sendernote)
        {
            string parameters = "{\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":false,\"fee\":" + "\"" + fee + "" + "\",\"multipleAmounts\":[" + "\"" + multipleAmounts + "" + "\"],\"attr\":" + "\"" + attr + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"xpub\":" + "\"" + xpub + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\"}";

            var stringResult = await PostSecureRequest($"bitcoin/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }






        /// <summary>
        /// BitcoinCash
        /// </summary>
        /// <param name="senderAccountId"></param>
        /// <param name="address"></param>
        /// <param name="amount"></param>
        /// <param name="fee"></param>
        /// <param name="multipleAmounts"></param>
        /// <param name="attr"></param>
        /// <param name="mnemonic"></param>
        /// <param name="xpub"></param>
        /// <param name="paymentid"></param>
        /// <param name="sendernote"></param>
        /// <returns></returns>


        public async Task<OffBlockchain> SendBcashToTatumAddressMnemonic(string senderAccountId, string address, string amount, string fee, string multipleAmounts, string attr, string mnemonic, string xpub, string paymentid, string sendernote)
        {
            string parameters = "{\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":false,\"fee\":" + "\"" + fee + "" + "\",\"multipleAmounts\":[" + "\"" + multipleAmounts + "" + "\"],\"attr\":" + "\"" + attr + "" + "\",\"mnemonic\":" + "\"" + mnemonic + "" + "\",\"xpub\":" + "\"" + xpub + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\"}";

            var stringResult = await PostSecureRequest($"bcash/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }
        public async Task<OffBlockchain> SendBcashToTatumAddressKeyPair(string senderAccountId, string address, string amount, string fee, string multipleAmounts, string accountaddress, string privatekey, string attr, string paymentid, string sendernote)
        {
            string parameters = "{\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":false,\"fee\":" + "\"" + fee + "" + "\",\"multipleAmounts\":[" + "\"" + multipleAmounts + "" + "\"],\"attr\":" + "\"" + attr + "" + "\",\"address\":" + "\"" + accountaddress + "" + "\",\"privatekey\":" + "\"" + privatekey + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\"}";

            var stringResult = await PostSecureRequest($"bcash/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> SendBcashToTatumAddressKms(string senderAccountId, string address, string amount, string fee, string multipleAmounts, string attr, string signatureid, string xpub, string paymentid, string sendernote)
        {
            string parameters = "{\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":false,\"fee\":" + "\"" + fee + "" + "\",\"multipleAmounts\":[" + "\"" + multipleAmounts + "" + "\"],\"attr\":" + "\"" + attr + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"xpub\":" + "\"" + xpub + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\"}";

            var stringResult = await PostSecureRequest($"bcash/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }





        /// <summary>
        /// LiteCoin
        /// </summary>
        /// <param name="senderAccountId"></param>
        /// <param name="address"></param>
        /// <param name="amount"></param>
        /// <param name="fee"></param>
        /// <param name="multipleAmounts"></param>
        /// <param name="attr"></param>
        /// <param name="mnemonic"></param>
        /// <param name="xpub"></param>
        /// <param name="paymentid"></param>
        /// <param name="sendernote"></param>
        /// <returns></returns>





        public async Task<OffBlockchain> SendLitecoinToTatumAddressMnemonic(string senderAccountId, string address, string amount, string fee, string multipleAmounts, string attr, string mnemonic, string xpub, string paymentid, string sendernote)
        {
            string parameters = "{\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":false,\"fee\":" + "\"" + fee + "" + "\",\"multipleAmounts\":[" + "\"" + multipleAmounts + "" + "\"],\"attr\":" + "\"" + attr + "" + "\",\"mnemonic\":" + "\"" + mnemonic + "" + "\",\"xpub\":" + "\"" + xpub + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\"}";

            var stringResult = await PostSecureRequest($"litecoin/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }
        public async Task<OffBlockchain> SendLitecoinToTatumAddressKeyPair(string senderAccountId, string address, string amount, string fee, string multipleAmounts, string attr, string addressto, string privatekey, string paymentid, string sendernote)
        {
            string parameters = "{\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":false,\"fee\":" + "\"" + fee + "" + "\",\"multipleAmounts\":[" + "\"" + multipleAmounts + "" + "\"],\"attr\":" + "\"" + attr + "" + "\",\"address\":" + "\"" + addressto + "" + "\",\"privateKey\":" + "\"" + privatekey + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\"}";

            var stringResult = await PostSecureRequest($"litecoin/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> SendLitecoinToTatumAddressKms(string senderAccountId, string address, string amount, string fee, string multipleAmounts, string attr, string signatureid, string xpub, string paymentid, string sendernote)
        {
            string parameters = "{\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":false,\"fee\":" + "\"" + fee + "" + "\",\"multipleAmounts\":[" + "\"" + multipleAmounts + "" + "\"],\"attr\":" + "\"" + attr + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"xpub\":" + "\"" + xpub + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\"}";

            var stringResult = await PostSecureRequest($"litecoin/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }




        /// <summary>
        /// DogeCoin
        /// </summary>
        /// <param name="senderAccountId"></param>
        /// <param name="address"></param>
        /// <param name="amount"></param>
        /// <param name="fee"></param>
        /// <param name="multipleAmounts"></param>
        /// <param name="attr"></param>
        /// <param name="mnemonic"></param>
        /// <param name="xpub"></param>
        /// <param name="paymentid"></param>
        /// <param name="sendernote"></param>
        /// <returns></returns>




        public async Task<OffBlockchain> SendDogecoinToTatumAddressMnemonic(string senderAccountId, string address, string amount, string fee, string multipleAmounts, string attr, string mnemonic, string xpub, string paymentid, string sendernote)
        {
            string parameters = "{\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":false,\"fee\":" + "\"" + fee + "" + "\",\"multipleAmounts\":[" + "\"" + multipleAmounts + "" + "\"],\"attr\":" + "\"" + attr + "" + "\",\"mnemonic\":" + "\"" + mnemonic + "" + "\",\"xpub\":" + "\"" + xpub + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\"}";

            var stringResult = await PostSecureRequest($"dogecoin/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }
        public async Task<OffBlockchain> SendDogecoinToTatumAddressKeyPair(string senderAccountId, string address, string amount, string fee, string multipleAmounts, string attr, string addressto, string privatekey, string paymentid, string sendernote)
        {
            string parameters = "{\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":false,\"fee\":" + "\"" + fee + "" + "\",\"multipleAmounts\":[" + "\"" + multipleAmounts + "" + "\"],\"attr\":" + "\"" + attr + "" + "\",\"address\":" + "\"" + addressto + "" + "\",\"privatekey\":" + "\"" + privatekey + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\"}";

            var stringResult = await PostSecureRequest($"dogecoin/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> SendDogecoinToTatumAddressKms(string senderAccountId, string address, string amount, string fee, string multipleAmounts, string attr, string signatureid, string xpub, string paymentid, string sendernote)
        {
            string parameters = "{\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":false,\"fee\":" + "\"" + fee + "" + "\",\"multipleAmounts\":[" + "\"" + multipleAmounts + "" + "\"],\"attr\":" + "\"" + attr + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"xpub\":" + "\"" + xpub + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\"}";

            var stringResult = await PostSecureRequest($"dogecoin/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }



        /// <summary>
        /// FLOW
        /// </summary>
        /// <param name="senderAccountId"></param>
        /// <param name="account"></param>
        /// <param name="address"></param>
        /// <param name="amount"></param>
        /// <param name="mnemonic"></param>
        /// <param name="index"></param>
        /// <param name="compliant"></param>
        /// <param name="paymentid"></param>
        /// <param name="sendernote"></param>
        /// <returns></returns>



        public async Task<OffBlockchain> SendFlowToTatumAddressMnemonic(string senderAccountId, string account, string address, string amount, string mnemonic, string index, string compliant, string paymentid, string sendernote)
        {
            string parameters = "{\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"account\":" + "\"" + account + "" + "\",\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"mnemonic\":" + "\"" + mnemonic + "" + "\",\"index\":" + "\"" + index + "" + "\",\"compliant\":" + "\"" + compliant + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\"}";
           
            var stringResult = await PostSecureRequest($"dogecoin/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> SendFlowToTatumAddressPK(string senderAccountId, string account, string address, string amount, string privateKey, string compliant, string paymentid, string sendernote)
        {
            string parameters = "{\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"account\":" + "\"" + account + "" + "\",\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"privateKey\":" + "\"" + privateKey + "" + "\",\"compliant\":" + "\"" + compliant + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\"}";

            var stringResult = await PostSecureRequest($"dogecoin/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }
        public async Task<OffBlockchain> SendFlowToTatumAddressKms(string senderAccountId, string account, string address, string amount, string signatureid, string index, string compliant, string paymentid, string sendernote)
        {
            string parameters = "{\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"account\":" + "\"" + account + "" + "\",\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"index\":" + "\"" + index + "" + "\",\"compliant\":" + "\"" + compliant + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\"}";

            var stringResult = await PostSecureRequest($"dogecoin/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }



        /// <summary>
        /// Ethereum
        /// </summary>
        /// <param name="address"></param>
        /// <param name="amount"></param>
        /// <param name="compliant"></param>
        /// <param name="privateKey"></param>
        /// <param name="paymentid"></param>
        /// <param name="senderAccountId"></param>
        /// <param name="sendernote"></param>
        /// <param name="gasLimit"></param>
        /// <param name="gasPrice"></param>
        /// <returns></returns>


        public async Task<OffBlockchain> SendEthereumToTatumAddress(string address, string amount, string compliant, string privateKey, string paymentid, string senderAccountId, string sendernote, string gasLimit, string gasPrice)
        {
            string parameters = "{\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":false,\"privateKey\":" + "\"" + privateKey + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\",\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}";

            var stringResult = await PostSecureRequest($"ethereum/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> SendEthereumToTatumAddressMnemonic(string address, string amount, string compliant, string index, string gasLimit, string gasPrice, string mnemonic, string paymentid, string senderAccountId, string sendernote)
        {
            string parameters = "{\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":false,\"index\":" + "\"" + index + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\",\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}";

            var stringResult = await PostSecureRequest($"ethereum/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }
        public async Task<OffBlockchain> SendEthereumToTatumAddressKms(string address, string amount, string compliant, string signatureid, string paymentid, string senderAccountId, string sendernote, string gasLimit, string gasPrice)
        {
            string parameters = "{\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":false,\"privateKey\":" + "\"" + signatureid + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\",\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}";

            var stringResult = await PostSecureRequest($"ethereum/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }




        /// <summary>
        /// ERC20
        /// </summary>
        /// <param name="address"></param>
        /// <param name="amount"></param>
        /// <param name="compliant"></param>
        /// <param name="privateKey"></param>
        /// <param name="paymentid"></param>
        /// <param name="senderAccountId"></param>
        /// <param name="sendernote"></param>
        /// <param name="gasLimit"></param>
        /// <param name="gasPrice"></param>
        /// <returns></returns>


        public async Task<OffBlockchain> SendErc20ToTatumAddress(string address, string amount, string compliant, string privateKey, string paymentid, string senderAccountId, string sendernote, string gasLimit, string gasPrice)
        {
            string parameters = "{\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":false,\"privateKey\":" + "\"" + privateKey + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\",\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}";

            var stringResult = await PostSecureRequest($"ethereum/erc20/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> SendErc20ToTatumAddressMnemonic(string address, string amount, string compliant, string index, string gasLimit, string gasPrice, string mnemonic, string paymentid, string senderAccountId, string sendernote)
        {
            string parameters = "{\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":false,\"index\":" + "\"" + index + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\",\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}";

            var stringResult = await PostSecureRequest($"ethereum/erc20/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }
        public async Task<OffBlockchain> SendErc20ToTatumAddressKms(string address, string amount, string compliant, string signatureid, string paymentid, string senderAccountId, string sendernote, string gasLimit, string gasPrice)
        {
            string parameters = "{\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":false,\"privateKey\":" + "\"" + signatureid + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\",\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}";

            var stringResult = await PostSecureRequest($"ethereum/erc20/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }



        /// <summary>
        /// RegisterERC20
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="supply"></param>
        /// <param name="decimals"></param>
        /// <param name="description"></param>
        /// <param name="basepair"></param>
        /// <param name="baserate"></param>
        /// <param name="accountingcurrency"></param>
        /// <param name="customercountry"></param>
        /// <param name="externalid"></param>
        /// <param name="providercountry"></param>
        /// <param name="derivationindex"></param>
        /// <param name="xpub"></param>
        /// <returns></returns>



        public async Task<OffBlockchain> RegisterNewErc20(string symbol, string supply, double decimals, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string derivationindex, string xpub)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"decimals\":" + "\"" + decimals + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"derivationIndex\":" + "\"" + derivationindex + "" + "\",\"xpub\":" + "\"" + xpub + "" + "\"}";

            var stringResult = await PostSecureRequest($"ethereum/erc20/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> RegisterNewErc20ByAddress(string symbol, string supply, double decimals, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"decimals\":" + "\"" + decimals + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"address\":" + "\"" + address + "" + "\"}";

            var stringResult = await PostSecureRequest($"ethereum/erc20/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }



        /// <summary>
        /// Deploy Ethereum ERC20
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="supply"></param>
        /// <param name="description"></param>
        /// <param name="basepair"></param>
        /// <param name="baserate"></param>
        /// <param name="accountingcurrency"></param>
        /// <param name="customercountry"></param>
        /// <param name="externalid"></param>
        /// <param name="providercountry"></param>
        /// <param name="address"></param>
        /// <param name="mnemonic"></param>
        /// <param name="index"></param>
        /// <returns></returns>




        public async Task<OffBlockchain> DeployErc20OffchainMnemonicAddress(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address, string mnemonic, int index)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"address\":" + "\"" + address + "" + "\",\"mnemonic\":" + "\"" + symbol + "" + "\",\"index\":" + "\"" + index + "" + "\"}";

            var stringResult = await PostSecureRequest($"ethereum/erc20/deploy", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> DeployErc20OffchainMnemXpub(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string xpub, string derivationindex, string mnemonic, int index)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"xpub\":" + "\"" + xpub + "" + "\",\"derivationIndex\":" + "\"" + derivationindex + "" + "\",\"mnemonic\":" + "\"" + mnemonic + "" + "\",\"index\":" + "\"" + index + "" + "\"}";

            var stringResult = await PostSecureRequest($"ethereum/erc20/deploy", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> DeployErc20OffchainPKAddress(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address, string privatekey)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"address\":" + "\"" + address + "" + "\",\"privateKey\":" + "\"" + privatekey + "" + "\"}";

            var stringResult = await PostSecureRequest($"ethereum/erc20/deploy", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> DeployErc20OffchainPKXpub(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string xpub, string derivationindex, int privatekey)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"xpub\":" + "\"" + xpub + "" + "\",\"derivationIndex\":" + "\"" + derivationindex + "" + "\",\"privateKey\":" + "\"" + privatekey + "" + "\"}";

            var stringResult = await PostSecureRequest($"ethereum/erc20/deploy", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> DeployErc20OffchainKMSAddress(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address, string signatureid)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"address\":" + "\"" + address + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\"}";

            var stringResult = await PostSecureRequest($"ethereum/erc20/deploy", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }


        public async Task<OffBlockchain> DeployErc20OffchainKMSXpub(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string xpub, string derivationindex, string signatureid)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"xpub\":" + "\"" + xpub + "" + "\",\"derivationIndex\":" + "\"" + derivationindex + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\"}";

            var stringResult = await PostSecureRequest($"ethereum/erc20/deploy", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }




        /// <summary>
        /// Transfer Bsc
        /// </summary>
        /// <param name="address"></param>
        /// <param name="amount"></param>
        /// <param name="compliant"></param>
        /// <param name="privatekey"></param>
        /// <param name="paymentid"></param>
        /// <param name="senderaccountid"></param>
        /// <param name="sendernote"></param>
        /// <param name="gaslimit"></param>
        /// <param name="gasprice"></param>
        /// <returns></returns>






        public async Task<OffBlockchain> OffchainTransferBsc(string address, string amount, string compliant, string privatekey, string paymentid, string senderaccountid, string sendernote, string gaslimit, string gasprice)
        {
            string parameters = "{\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":" + "\"" + compliant + "" + "\",\"privateKey\":" + "\"" + privatekey + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderAccountId\":" + "\"" + senderaccountid + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\",\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}";

            var stringResult = await PostSecureRequest($"bsc/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> OffchainTransferBscMnemonic(string address, string amount, string compliant, string index, string gaslimit, string gasprice, string mnemonic, string paymentid, string senderaccountid, string sendernote)
        {
            string parameters = "{\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":" + "\"" + compliant + "" + "\",\"index\":" + "\"" + index + "" + "\",\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\",\"mnemonic\":" + "\"" + mnemonic + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderAccountId\":" + "\"" + senderaccountid + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\"}";

            var stringResult = await PostSecureRequest($"bsc/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }


        public async Task<OffBlockchain> OffchainTransferBscKMS(string address, string amount, string compliant, string signatureid, string index, string paymentid, string senderaccountid, string sendernote, string gaslimit, string gasprice)
        {
            string parameters = "{\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":" + "\"" + compliant + "" + "\",\"index\":" + "\"" + index + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderAccountId\":" + "\"" + senderaccountid + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\",\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}";

            var stringResult = await PostSecureRequest($"bsc/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }



        /// <summary>
        /// Register BEP20
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="supply"></param>
        /// <param name="decimals"></param>
        /// <param name="description"></param>
        /// <param name="basepair"></param>
        /// <param name="baserate"></param>
        /// <param name="accountingcurrency"></param>
        /// <param name="customercountry"></param>
        /// <param name="externalid"></param>
        /// <param name="providercountry"></param>
        /// <param name="derivationindex"></param>
        /// <param name="xpub"></param>
        /// <returns></returns>



        public async Task<OffBlockchain> RegisterNewBEP20Erc20(string symbol, string supply, string decimals, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string derivationindex, string xpub)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"decimals\":" + "\"" + decimals + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"derivationIndex\":" + "\"" + derivationindex + "" + "\",\"xpub\":" + "\"" + xpub + "" + "\"}";

            var stringResult = await PostSecureRequest($"bsc/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }


        public async Task<OffBlockchain> RegisterNewBEP20Erc20Address(string symbol, string supply, string decimals, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"decimals\":" + "\"" + decimals + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"address\":" + "\"" + address + "" + "\"}";

            var stringResult = await PostSecureRequest($"bsc/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }





        /// <summary>
        /// DeployBscBEP20
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="supply"></param>
        /// <param name="description"></param>
        /// <param name="basepair"></param>
        /// <param name="baserate"></param>
        /// <param name="accountingcurrency"></param>
        /// <param name="customercountry"></param>
        /// <param name="externalid"></param>
        /// <param name="providercountry"></param>
        /// <param name="address"></param>
        /// <param name="mnemonic"></param>
        /// <param name="index"></param>
        /// <returns></returns>





        public async Task<OffBlockchain> DeployBscBEP20OffchainMnemonicAddress(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address, string mnemonic, int index)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"address\":" + "\"" + address + "" + "\",\"mnemonic\":" + "\"" + symbol + "" + "\",\"index\":" + "\"" + index + "" + "\"}";

            var stringResult = await PostSecureRequest($"bsc/bep20/deploy", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> DeployBscBEP20OffchainMnemXpub(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string xpub, string derivationindex, string mnemonic, int index)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"xpub\":" + "\"" + xpub + "" + "\",\"derivationIndex\":" + "\"" + derivationindex + "" + "\",\"mnemonic\":" + "\"" + mnemonic + "" + "\",\"index\":" + "\"" + index + "" + "\"}";

            var stringResult = await PostSecureRequest($"bsc/bep20/deploy", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> DeployBscBEP20OffchainPKAddress(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address, string privatekey)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"address\":" + "\"" + address + "" + "\",\"privateKey\":" + "\"" + privatekey + "" + "\"}";

            var stringResult = await PostSecureRequest($"bsc/bep20/deploy", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> DeployBscBEP20OffchainPKXpub(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string xpub, string derivationindex, int privatekey)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"xpub\":" + "\"" + xpub + "" + "\",\"derivationIndex\":" + "\"" + derivationindex + "" + "\",\"privateKey\":" + "\"" + privatekey + "" + "\"}";

            var stringResult = await PostSecureRequest($"bsc/bep20/deploy", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> DeployBscBEP20OffchainKMSAddress(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address, string signatureid)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"address\":" + "\"" + address + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\"}";

            var stringResult = await PostSecureRequest($"bsc/bep20/deploy", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }


        public async Task<OffBlockchain> DeployBscBEP20OffchainKMSXpub(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string xpub, string derivationindex, string signatureid)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"xpub\":" + "\"" + xpub + "" + "\",\"derivationIndex\":" + "\"" + derivationindex + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\"}";

            var stringResult = await PostSecureRequest($"bsc/bep20/deploy", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }




        /// <summary>
        /// Send XDC
        /// </summary>
        /// <param name="address"></param>
        /// <param name="amount"></param>
        /// <param name="compliant"></param>
        /// <param name="privatekey"></param>
        /// <param name="paymentid"></param>
        /// <param name="senderaccountid"></param>
        /// <param name="sendernote"></param>
        /// <param name="gaslimit"></param>
        /// <param name="gasprice"></param>
        /// <returns></returns>





        public async Task<OffBlockchain> SendXDCFromLedgerToBlockchain(string address, string amount, string compliant, string privatekey, string paymentid, string senderaccountid, string sendernote, string gaslimit, string gasprice)
        {
            string parameters = "{\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":" + "\"" + compliant + "" + "\",\"privateKey\":" + "\"" + privatekey + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderAccountId\":" + "\"" + senderaccountid + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\",\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}";

            var stringResult = await PostSecureRequest($"xdc/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> SendXDCFromLedgerToBlockchainMnemonic(string address, string amount, string compliant, string index, string gaslimit, string gasprice, string mnemonic, string paymentid, string senderaccountid, string sendernote)
        {
            string parameters = "{\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":" + "\"" + compliant + "" + "\",\"index\":" + "\"" + index + "" + "\",\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\",\"mnemonic\":" + "\"" + mnemonic + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderAccountId\":" + "\"" + senderaccountid + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\"}";

            var stringResult = await PostSecureRequest($"xdc/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }


        public async Task<OffBlockchain> SendXDCFromLedgerToBlockchainKms(string address, string amount, string compliant, string signatureid, string paymentid, string senderAccountId, string sendernote, string gasLimit, string gasPrice)
        {
            string parameters = "{\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":" + "\"" + compliant + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\",\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}";

            var stringResult = await PostSecureRequest($"xdc/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }




        /// <summary>
        /// Register XDC ERC20
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="supply"></param>
        /// <param name="decimals"></param>
        /// <param name="description"></param>
        /// <param name="basepair"></param>
        /// <param name="baserate"></param>
        /// <param name="accountingcurrency"></param>
        /// <param name="customercountry"></param>
        /// <param name="externalid"></param>
        /// <param name="providercountry"></param>
        /// <param name="derivationindex"></param>
        /// <param name="xpub"></param>
        /// <returns></returns>





        public async Task<OffBlockchain> RegisterNewXDCErc20(string symbol, string supply, string decimals, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string derivationindex, string xpub)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"decimals\":" + "\"" + decimals + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"derivationIndex\":" + "\"" + derivationindex + "" + "\",\"xpub\":" + "\"" + xpub + "" + "\"}";

            var stringResult = await PostSecureRequest($"xdc/erc20", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> RegisterNewXDCErc20Address(string symbol, string supply, string decimals, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"decimals\":" + "\"" + decimals + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"address\":" + "\"" + address + "" + "\"}";

            var stringResult = await PostSecureRequest($"xdc/erc20", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }



        /// <summary>
        /// Deploy XDC ERC20
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="supply"></param>
        /// <param name="description"></param>
        /// <param name="basepair"></param>
        /// <param name="baserate"></param>
        /// <param name="accountingcurrency"></param>
        /// <param name="customercountry"></param>
        /// <param name="externalid"></param>
        /// <param name="providercountry"></param>
        /// <param name="address"></param>
        /// <param name="mnemonic"></param>
        /// <param name="index"></param>
        /// <returns></returns>




        public async Task<OffBlockchain> DeployXDCErc20OffchainMnemonicAddress(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address, string mnemonic, int index)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"address\":" + "\"" + address + "" + "\",\"mnemonic\":" + "\"" + symbol + "" + "\",\"index\":" + "\"" + index + "" + "\"}";

            var stringResult = await PostSecureRequest($"xdc/erc20/deploy", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> DeployXDCErc20OffchainMnemXpub(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string xpub, string derivationindex, string mnemonic, int index)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"xpub\":" + "\"" + xpub + "" + "\",\"derivationIndex\":" + "\"" + derivationindex + "" + "\",\"mnemonic\":" + "\"" + mnemonic + "" + "\",\"index\":" + "\"" + index + "" + "\"}";

            var stringResult = await PostSecureRequest($"xdc/erc20/deploy", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> DeployXDCErc20OffchainPKAddress(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address, string privatekey)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"address\":" + "\"" + address + "" + "\",\"privateKey\":" + "\"" + privatekey + "" + "\"}";

            var stringResult = await PostSecureRequest($"xdc/erc20/deploy", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> DeployXDCErc20OffchainPKXpub(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string xpub, string derivationindex, int privatekey)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"xpub\":" + "\"" + xpub + "" + "\",\"derivationIndex\":" + "\"" + derivationindex + "" + "\",\"privateKey\":" + "\"" + privatekey + "" + "\"}";

            var stringResult = await PostSecureRequest($"xdc/erc20/deploy", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> DeployXDCErc20OffchainKMSAddress(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address, string signatureid)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"address\":" + "\"" + address + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\"}";

            var stringResult = await PostSecureRequest($"xdc/erc20/deploy", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }


        public async Task<OffBlockchain> DeployXDCErc20OffchainKMSXpub(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string xpub, string derivationindex, string signatureid)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"xpub\":" + "\"" + xpub + "" + "\",\"derivationIndex\":" + "\"" + derivationindex + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\"}";

            var stringResult = await PostSecureRequest($"xdc/erc20/deploy", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }




        /// <summary>
        /// Send ONE
        /// </summary>
        /// <param name="address"></param>
        /// <param name="amount"></param>
        /// <param name="compliant"></param>
        /// <param name="privateKey"></param>
        /// <param name="paymentid"></param>
        /// <param name="senderAccountId"></param>
        /// <param name="sendernote"></param>
        /// <param name="gasLimit"></param>
        /// <param name="gasPrice"></param>
        /// <returns></returns>




        public async Task<OffBlockchain> SendONEFromLedgerToBlockchain(string address, string amount, string compliant, string privateKey, string paymentid, string senderAccountId, string sendernote, string gasLimit, string gasPrice)
        {
            string parameters = "{\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":" + "\"" + compliant + "" + "\",\"privateKey\":" + "\"" + privateKey + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\",\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}";

            var stringResult = await PostSecureRequest($"one/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> SendONEFromLedgerToBlockchainMnemonic(string address, string amount, string compliant, string index, string gasLimit, string gasPrice, string mnemonic, string paymentid, string senderAccountId, string sendernote)
        {
            string parameters = "{\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":" + "\"" + compliant + "" + "\",\"index\":" + "\"" + index + "" + "\",\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\",\"mnemonic\":" + "\"" + mnemonic + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\"}";

            var stringResult = await PostSecureRequest($"one/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }


        public async Task<OffBlockchain> SendONEFromLedgerToBlockchainKms(string address, string amount, string compliant, string signatureid, string paymentid, string senderAccountId, string sendernote, string gasLimit, string gasPrice)
        {
            string parameters = "{\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":" + "\"" + compliant + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\",\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}";

            var stringResult = await PostSecureRequest($"one/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }



        /// <summary>
        /// Register ONEerc20
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="supply"></param>
        /// <param name="decimals"></param>
        /// <param name="description"></param>
        /// <param name="basepair"></param>
        /// <param name="baserate"></param>
        /// <param name="accountingcurrency"></param>
        /// <param name="customercountry"></param>
        /// <param name="externalid"></param>
        /// <param name="providercountry"></param>
        /// <param name="derivationindex"></param>
        /// <param name="xpub"></param>
        /// <returns></returns>




        public async Task<OffBlockchain> RegisterNewONEErc20(string symbol, string supply, string decimals, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string derivationindex, string xpub)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"decimals\":" + "\"" + decimals + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"derivationIndex\":" + "\"" + derivationindex + "" + "\",\"xpub\":" + "\"" + xpub + "" + "\"}";

            var stringResult = await PostSecureRequest($"one/hrm20", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> RegisterNewONEErc20Address(string symbol, string supply, string decimals, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"decimals\":" + "\"" + decimals + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"address\":" + "\"" + address + "" + "\"}";

            var stringResult = await PostSecureRequest($"one/hrm20", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }





        /// <summary>
        /// Deploy ONE erc20
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="supply"></param>
        /// <param name="description"></param>
        /// <param name="basepair"></param>
        /// <param name="baserate"></param>
        /// <param name="accountingcurrency"></param>
        /// <param name="customercountry"></param>
        /// <param name="externalid"></param>
        /// <param name="providercountry"></param>
        /// <param name="address"></param>
        /// <param name="mnemonic"></param>
        /// <param name="index"></param>
        /// <returns></returns>





        public async Task<OffBlockchain> DeployONEErc20OffchainMnemonicAddress(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address, string mnemonic, int index)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"address\":" + "\"" + address + "" + "\",\"mnemonic\":" + "\"" + symbol + "" + "\",\"index\":" + "\"" + index + "" + "\"}";

            var stringResult = await PostSecureRequest($"one/hrm20/deploy", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> DeployONEErc20OffchainMnemXpub(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string xpub, string derivationindex, string mnemonic, int index)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"xpub\":" + "\"" + xpub + "" + "\",\"derivationIndex\":" + "\"" + derivationindex + "" + "\",\"mnemonic\":" + "\"" + mnemonic + "" + "\",\"index\":" + "\"" + index + "" + "\"}";

            var stringResult = await PostSecureRequest($"one/hrm20/deploy", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> DeployONEErc20OffchainPKAddress(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address, string privatekey)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"address\":" + "\"" + address + "" + "\",\"privateKey\":" + "\"" + privatekey + "" + "\"}";

            var stringResult = await PostSecureRequest($"one/hrm20/deploy", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> DeployONEErc20OffchainPKXpub(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string xpub, string derivationindex, int privatekey)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"xpub\":" + "\"" + xpub + "" + "\",\"derivationIndex\":" + "\"" + derivationindex + "" + "\",\"privateKey\":" + "\"" + privatekey + "" + "\"}";

            var stringResult = await PostSecureRequest($"one/hrm20/deploy", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> DeployONEErc20OffchainKMSAddress(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address, string signatureid)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"address\":" + "\"" + address + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\"}";

            var stringResult = await PostSecureRequest($"one/hrm20/deploy", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }


        public async Task<OffBlockchain> DeployONEErc20OffchainKMSXpub(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string xpub, string derivationindex, string signatureid)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"xpub\":" + "\"" + xpub + "" + "\",\"derivationIndex\":" + "\"" + derivationindex + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\"}";

            var stringResult = await PostSecureRequest($"one/hrm20/deploy", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }




        /// <summary>
        /// Set Erc20 BEP20 HRM20 TRC20
        /// </summary>
        /// <param name="address"></param>
        /// <param name="name"></param>
        /// <returns></returns>




        public async Task<OffBlockchain> SetErc20BEP20HRM20TRC20Token(string address, string name)
        {
            string parameters = "";

            var stringResult = await PostSecureRequest($"token/{name}/{address}", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }




        /// <summary>
        /// Send Celo cUSD cEUR
        /// </summary>
        /// <param name="address"></param>
        /// <param name="amount"></param>
        /// <param name="compliant"></param>
        /// <param name="privateKey"></param>
        /// <param name="paymentid"></param>
        /// <param name="senderAccountId"></param>
        /// <param name="feecurrency"></param>
        /// <param name="sendernote"></param>
        /// <param name="gasLimit"></param>
        /// <param name="gasPrice"></param>
        /// <returns></returns>



        public async Task<OffBlockchain> SendCeloFromLedgerToBlockchain(string address, string amount, string compliant, string privateKey, string paymentid, string senderAccountId, string feecurrency, string sendernote, string gasLimit, string gasPrice)
        {
            string parameters = "{\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":" + "\"" + compliant + "" + "\",\"privateKey\":" + "\"" + privateKey + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\",\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}";

            var stringResult = await PostSecureRequest($"celo/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> SendCeloFromLedgerToBlockchainMnemonic(string address, string amount, string compliant, string index, string feecurrency, string gasLimit, string gasPrice, string mnemonic, string paymentid, string senderAccountId, string sendernote)
        {
            string parameters = "{\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":" + "\"" + compliant + "" + "\",\"index\":" + "\"" + index + "" + "\",\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\",\"mnemonic\":" + "\"" + mnemonic + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\"}";

            var stringResult = await PostSecureRequest($"celo/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }


        public async Task<OffBlockchain> SendCeloFromLedgerToBlockchainKms(string address, string amount, string compliant, string signatureid, string feecurrency, string paymentid, string senderAccountId, string sendernote, string gasLimit, string gasPrice)
        {
            string parameters = "{\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":" + "\"" + compliant + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\",\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}";

            var stringResult = await PostSecureRequest($"celo/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }





        /// <summary>
        /// Register Celo ERC20
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="supply"></param>
        /// <param name="decimals"></param>
        /// <param name="description"></param>
        /// <param name="basepair"></param>
        /// <param name="baserate"></param>
        /// <param name="accountingcurrency"></param>
        /// <param name="customercountry"></param>
        /// <param name="externalid"></param>
        /// <param name="providercountry"></param>
        /// <param name="derivationindex"></param>
        /// <param name="xpub"></param>
        /// <returns></returns>




        public async Task<OffBlockchain> RegisterNewCeloErc20(string symbol, string supply, string decimals, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string derivationindex, string xpub)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"decimals\":" + "\"" + decimals + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"derivationIndex\":" + "\"" + derivationindex + "" + "\",\"xpub\":" + "\"" + xpub + "" + "\"}";

            var stringResult = await PostSecureRequest($"celo/erc20", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> RegisterNewCeloErc20Address(string symbol, string supply, string decimals, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"decimals\":" + "\"" + decimals + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"address\":" + "\"" + address + "" + "\"}";

            var stringResult = await PostSecureRequest($"celo/erc20", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }





        /// <summary>
        /// Deploy Celo Erc20
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="supply"></param>
        /// <param name="description"></param>
        /// <param name="basepair"></param>
        /// <param name="baserate"></param>
        /// <param name="accountingcurrency"></param>
        /// <param name="customercountry"></param>
        /// <param name="externalid"></param>
        /// <param name="providercountry"></param>
        /// <param name="address"></param>
        /// <param name="mnemonic"></param>
        /// <param name="index"></param>
        /// <param name="feecurrency"></param>
        /// <returns></returns>




        public async Task<OffBlockchain> DeployCeloErc20OffchainMnemonicAddress(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address, string mnemonic, int index, string feecurrency)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"address\":" + "\"" + address + "" + "\",\"mnemonic\":" + "\"" + symbol + "" + "\",\"index\":" + "\"" + index + "" + "\"}";

            var stringResult = await PostSecureRequest($"celo/erc20/deploy", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> DeployCeloErc20OffchainMnemXpub(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string xpub, string derivationindex, string mnemonic, int index, string feecurrency)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"xpub\":" + "\"" + xpub + "" + "\",\"derivationIndex\":" + "\"" + derivationindex + "" + "\",\"mnemonic\":" + "\"" + mnemonic + "" + "\",\"index\":" + "\"" + index + "" + "\"}";

            var stringResult = await PostSecureRequest($"celo/erc20/deploy", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> DeployCeloErc20OffchainPKAddress(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address, string privatekey, string feecurrency)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"address\":" + "\"" + address + "" + "\",\"privateKey\":" + "\"" + privatekey + "" + "\"}";

            var stringResult = await PostSecureRequest($"celo/erc20/deploy", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> DeployCeloErc20OffchainPKXpub(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string xpub, string derivationindex, int privatekey, string feecurrency)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"xpub\":" + "\"" + xpub + "" + "\",\"derivationIndex\":" + "\"" + derivationindex + "" + "\",\"privateKey\":" + "\"" + privatekey + "" + "\"}";

            var stringResult = await PostSecureRequest($"celo/erc20/deploy", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> DeployCeloErc20OffchainKMSAddress(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address, string signatureid, string feecurrency)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"address\":" + "\"" + address + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\"}";

            var stringResult = await PostSecureRequest($"celo/erc20/deploy", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }


        public async Task<OffBlockchain> DeployCeloErc20OffchainKMSXpub(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string xpub, string derivationindex, string signatureid, string feecurrency)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"xpub\":" + "\"" + xpub + "" + "\",\"derivationIndex\":" + "\"" + derivationindex + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\"}";

            var stringResult = await PostSecureRequest($"celo/erc20/deploy", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }





        /// <summary>
        /// Set Celo Token Address
        /// </summary>
        /// <param name="address"></param>
        /// <param name="name"></param>
        /// <returns></returns>




        public async Task<OffBlockchain> SetCeloTokenAddress(string address, string name)
        {
            string parameters = "";

            var stringResult = await PostSecureRequest($"celo/erc20/{name}/{address}", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }




        /// <summary>
        /// Send XLM
        /// </summary>
        /// <param name="senderAccountId"></param>
        /// <param name="fromaccount"></param>
        /// <param name="address"></param>
        /// <param name="amount"></param>
        /// <param name="secret"></param>
        /// <param name="compliant"></param>
        /// <param name="attr"></param>
        /// <param name="paymentid"></param>
        /// <param name="sendernote"></param>
        /// <returns></returns>



        public async Task<OffBlockchain> SendXlmFromLedgerToBlockchain(string senderAccountId, string fromaccount, string address, string amount, string secret, string compliant, string attr, string paymentid, string sendernote)
        {
            string parameters = "{\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"fromAccount\":" + "\"" + fromaccount + "" + "\",\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"secret\":" + "\"" + secret + "" + "\",\"compliant\":" + "\"" + compliant + "" + "\",\"attr\":" + "\"" + attr + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\"}";

            var stringResult = await PostSecureRequest($"xlm/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> SendXlmFromLedgerToBlockchainKms(string senderAccountId, string fromaccount, string address, string amount, string signatureid, string compliant, string attr, string paymentid, string sendernote)
        {
            string parameters = "{\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"fromAccount\":" + "\"" + fromaccount + "" + "\",\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"compliant\":" + "\"" + compliant + "" + "\",\"attr\":" + "\"" + attr + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\"}";

            var stringResult = await PostSecureRequest($"xlm/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }







        /// <summary>
        /// Create XLM Assets
        /// </summary>
        /// <param name="issueraccount"></param>
        /// <param name="token"></param>
        /// <param name="basepair"></param>
        /// <returns></returns>



        public async Task<OffBlockchain> CreateXlmBasedAsset(string issueraccount, string token, string basepair)
        {
            string parameters = "{\"issuerAccount\":" + "\"" + issueraccount + "" + "\",\"token\":" + "\"" + token + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\"}";

            var stringResult = await PostSecureRequest($"xlm/asset", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }




        /// <summary>
        /// XRP Transfer
        /// </summary>
        /// <param name="senderAccountId"></param>
        /// <param name="account"></param>
        /// <param name="address"></param>
        /// <param name="amount"></param>
        /// <param name="compliant"></param>
        /// <param name="attr"></param>
        /// <param name="paymentid"></param>
        /// <param name="secret"></param>
        /// <param name="sendernote"></param>
        /// <returns></returns>




        public async Task<OffBlockchain> SendXRpFromLedgerToBlockchain(string senderAccountId, string account, string address, string amount, string compliant, string attr, string paymentid, string secret, string sendernote)
        {
            string parameters = "{\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"account\":" + "\"" + account + "" + "\",\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":" + "\"" + compliant + "" + "\",\"attr\":" + "\"" + attr + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"secret\":" + "\"" + secret + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\"}";

            var stringResult = await PostSecureRequest($"xrp/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> SendXRpFromLedgerToBlockchainKms(string senderAccountId, string account, string address, string amount, string compliant, string attr, string paymentid, string signatureid, string sendernote)
        {
            string parameters = "{\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"account\":" + "\"" + account + "" + "\",\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":" + "\"" + compliant + "" + "\",\"attr\":" + "\"" + attr + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\"}";

            var stringResult = await PostSecureRequest($"xrp/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }






        /// <summary>
        /// XRP Create
        /// </summary>
        /// <param name="issueraccount"></param>
        /// <param name="token"></param>
        /// <param name="basepair"></param>
        /// <returns></returns>



        public async Task<OffBlockchain> CreateXRPBasedAsset(string issueraccount, string token, string basepair)
        {
            string parameters = "{\"issuerAccount\":" + "\"" + issueraccount + "" + "\",\"token\":" + "\"" + token + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\"}";

            var stringResult = await PostSecureRequest($"xrp/asset", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }





        /// <summary>
        /// Send BnB
        /// </summary>
        /// <param name="senderAccountId"></param>
        /// <param name="account"></param>
        /// <param name="address"></param>
        /// <param name="amount"></param>
        /// <param name="compliant"></param>
        /// <param name="attr"></param>
        /// <param name="paymentid"></param>
        /// <param name="privatekey"></param>
        /// <param name="sendernote"></param>
        /// <returns></returns>






        public async Task<OffBlockchain> SendBnbFromLedgerToBlockchain(string senderAccountId, string address, string amount, string compliant, string attr, string paymentid, string privatekey, string sendernote)
        {
            string parameters = "{\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":" + "\"" + compliant + "" + "\",\"attr\":" + "\"" + attr + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"privateKey\":" + "\"" + privatekey + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\"}";

            var stringResult = await PostSecureRequest($"bnb/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> SendBnbFromLedgerToBlockchainKms(string senderAccountId, string address, string amount, string compliant, string attr, string paymentid, string signatureid, string fromaddress, string sendernote)
        {
            string parameters = "{\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":" + "\"" + compliant + "" + "\",\"attr\":" + "\"" + attr + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"fromAddress\":" + "\"" + fromaddress + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\"}";

            var stringResult = await PostSecureRequest($"bnb/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }




        /// <summary>
        /// Create BnB Asset
        /// </summary>
        /// <param name="token"></param>
        /// <param name="basepair"></param>
        /// <returns></returns>


        public async Task<OffBlockchain> CreateBnbBasedAsset(string token, string basepair)
        {
            string parameters = "{\"token\":" + "\"" + token + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\"}";

            var stringResult = await PostSecureRequest($"bnb/asset", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }




        /// <summary>
        /// Send Ada
        /// </summary>
        /// <param name="senderAccountId"></param>
        /// <param name="address"></param>
        /// <param name="amount"></param>
        /// <param name="compliant"></param>
        /// <param name="fee"></param>
        /// <param name="addressfrom"></param>
        /// <param name="privatekey"></param>
        /// <param name="attr"></param>
        /// <param name="mnemonic"></param>
        /// <param name="signatureid"></param>
        /// <param name="xpub"></param>
        /// <param name="paymentid"></param>
        /// <param name="sendernote"></param>
        /// <returns></returns>




        public async Task<OffBlockchain> SendAdaFromLedgerToBlockchain(string senderAccountId, string address, string amount, string compliant, string fee, string addressfrom, string privatekey, string attr, string mnemonic, string signatureid, string xpub, string paymentid, string sendernote)
        {
            string parameters = "{\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":" + "\"" + compliant + "" + "\",\"fee\":" + "\"" + fee + "" + "\",\"keyPair\":[{\"address\":" + "\"" + addressfrom + "" + "\",\"privateKey\":" + "\"" + privatekey + "" + "\"}],\"attr\":" + "\"" + attr + "" + "\",\"mnemonic\":" + "\"" + mnemonic + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"xpub\":" + "\"" + xpub + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\"}";

            var stringResult = await PostSecureRequest($"ada/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> SendAdaFromLedgerToBlockchainMnemonic(string address, string amount, string compliant, string fee, string index, string mnemonic, string paymentid, string senderAccountId, string sendernote)
        {
            string parameters = "{\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":false,\"fee\":" + "\"" + fee + "" + "\",\"index\":" + "\"" + index + "" + "\",\"mnemonic\":" + "\"" + mnemonic + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\"}";

            var stringResult = await PostSecureRequest($"ada/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }
        public async Task<OffBlockchain> SendAdaFromLedgerToBlockchainKms(string address, string amount, string compliant, string fee, string from, string signatureid, string index, string paymentid, string senderAccountId, string sendernote)
        {
            string parameters = "{\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":false,\"fee\":" + "\"" + fee + "" + "\",\"from\":" + "\"" + from + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"index\":" + "\"" + index + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\"}";

            var stringResult = await PostSecureRequest($"ada/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }





        /// <summary>
        /// Send Tron
        /// </summary>
        /// <param name="address"></param>
        /// <param name="amount"></param>
        /// <param name="compliant"></param>
        /// <param name="privatekey"></param>
        /// <param name="fee"></param>
        /// <param name="paymentid"></param>
        /// <param name="senderAccountId"></param>
        /// <param name="sendernote"></param>
        /// <returns></returns>





        public async Task<OffBlockchain> SendTronFromLedgerToBlockchain(string address, string amount, string compliant, string privatekey, string fee, string paymentid, string senderAccountId, string sendernote)
        {
            string parameters = "{\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":false,\"privateKey\":" + "\"" + privatekey + "" + "\",\"fee\":" + "\"" + fee + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\"}";

            var stringResult = await PostSecureRequest($"tron/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }
        public async Task<OffBlockchain> SendTronFromLedgerToBlockchainMnemonic(string address, string amount, string compliant, string fee, string index, string mnemonic, string paymentid, string senderAccountId, string sendernote)
        {
            string parameters = "{\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":false,\"fee\":" + "\"" + fee + "" + "\",\"index\":" + "\"" + index + "" + "\",\"mnemonic\":" + "\"" + mnemonic + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\"}";

            var stringResult = await PostSecureRequest($"tron/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> SendTronFromLedgerToBlockchainKms(string address, string amount, string compliant, string fee, string from, string signatureid, string index, string paymentid, string senderAccountId, string sendernote)
        {
            string parameters = "{\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"compliant\":false,\"fee\":" + "\"" + fee + "" + "\",\"from\":" + "\"" + from + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"index\":" + "\"" + index + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\"}";

            var stringResult = await PostSecureRequest($"tron/transfer", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }





        /// <summary>
        /// Register Trc1020
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="supply"></param>
        /// <param name="decimals"></param>
        /// <param name="type"></param>
        /// <param name="description"></param>
        /// <param name="url"></param>
        /// <param name="basepair"></param>
        /// <param name="baserate"></param>
        /// <param name="accountingcurrency"></param>
        /// <param name="customercountry"></param>
        /// <param name="externalid"></param>
        /// <param name="providercountry"></param>
        /// <param name="derivationindex"></param>
        /// <param name="xpub"></param>
        /// <param name="address"></param>
        /// <returns></returns>





        public async Task<OffBlockchain> RegisterNewTrc1020InLedger(string symbol, string supply, double decimals, string type, string description, string url, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string derivationindex, string xpub, string address)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"decimals\":" + "\"" + decimals + "" + "\",\"description\":" + "\"" + description + "" + "\",\"url\":" + "\"" + url + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"derivationIndex\":" + "\"" + derivationindex + "" + "\",\"xpub\":" + "\"" + xpub + "" + "\",\"address\":" + "\"" + address + "" + "\"}";

            var stringResult = await PostSecureRequest($"tron/trc", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }







        /// <summary>
        /// Deploy Trc
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="supply"></param>
        /// <param name="description"></param>
        /// <param name="basepair"></param>
        /// <param name="baserate"></param>
        /// <param name="accountingcurrency"></param>
        /// <param name="customercountry"></param>
        /// <param name="externalid"></param>
        /// <param name="providercountry"></param>
        /// <param name="address"></param>
        /// <param name="mnemonic"></param>
        /// <param name="index"></param>
        /// <returns></returns>






        public async Task<OffBlockchain> DeployTrcOffchainMnemonicAddress(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address, string mnemonic, int index)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"address\":" + "\"" + address + "" + "\",\"mnemonic\":" + "\"" + symbol + "" + "\",\"index\":" + "\"" + index + "" + "\"}";

            var stringResult = await PostSecureRequest($"tron/trc/deploy", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> DeployTrcffchainMnemXpub(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string xpub, string derivationindex, string mnemonic, int index)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"xpub\":" + "\"" + xpub + "" + "\",\"derivationIndex\":" + "\"" + derivationindex + "" + "\",\"mnemonic\":" + "\"" + mnemonic + "" + "\",\"index\":" + "\"" + index + "" + "\"}";

            var stringResult = await PostSecureRequest($"tron/trc/deploy", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> DeployTrcOffchainPKAddress(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address, string privatekey)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"address\":" + "\"" + address + "" + "\",\"privateKey\":" + "\"" + privatekey + "" + "\"}";

            var stringResult = await PostSecureRequest($"tron/trc/deploy", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> DeployTrc0OffchainPKXpub(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string xpub, string derivationindex, int privatekey)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"xpub\":" + "\"" + xpub + "" + "\",\"derivationIndex\":" + "\"" + derivationindex + "" + "\",\"privateKey\":" + "\"" + privatekey + "" + "\"}";

            var stringResult = await PostSecureRequest($"tron/trc/deploy", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }

        public async Task<OffBlockchain> DeployTrcOffchainKMSAddress(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address, string signatureid)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"address\":" + "\"" + address + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\"}";

            var stringResult = await PostSecureRequest($"tron/trc/deploy", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }


        public async Task<OffBlockchain> DeployTrcOffchainKMSXpub(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string xpub, string derivationindex, string signatureid)
        {
            string parameters = "{\"symbol\":" + "\"" + symbol + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"description\":" + "\"" + description + "" + "\",\"basePair\":" + "\"" + basepair + "" + "\",\"baseRate\":" + "\"" + baserate + "" + "\",\"customer\":{\"accountingCurrency\":" + "\"" + accountingcurrency + "" + "\",\"customerCountry\":" + "\"" + customercountry + "" + "\",\"externalId\":" + "\"" + externalid + "" + "\",\"providerCountry\":" + "\"" + providercountry + "" + "\"},\"xpub\":" + "\"" + xpub + "" + "\",\"derivationIndex\":" + "\"" + derivationindex + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\"}";

            var stringResult = await PostSecureRequest($"tron/trc/deploy", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }





        /// <summary>
        /// Set TRC contract Address
        /// </summary>
        /// <param name="address"></param>
        /// <param name="name"></param>
        /// <returns></returns>




        public async Task<OffBlockchain> SetTrcContractAddress(string address, string name)
        {
            string parameters = "";

            var stringResult = await PostSecureRequest($"tron/trc/{name}/{address}", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }




        /// <summary>
        /// Store Withdrawal Offchain
        /// </summary>
        /// <param name="senderaccountid"></param>
        /// <param name="address"></param>
        /// <param name="amount"></param>
        /// <param name="attr"></param>
        /// <param name="compliant"></param>
        /// <param name="fee"></param>
        /// <param name="multipleamounts"></param>
        /// <param name="paymentid"></param>
        /// <param name="sendernote"></param>
        /// <returns></returns>



        public async Task<OffBlockchain> StoreWithdrawalOffchain(string senderaccountid, string address, double amount, string attr, string compliant, string fee, string multipleamounts, string paymentid, string sendernote)
        {
            string parameters = "{\"senderAccountId\":" + "\"" + senderaccountid + "" + "\",\"address\":" + "\"" + address + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"attr\":" + "\"" + attr + "" + "\",\"compliant\":" + "\"" + compliant + "" + "\",\"fee\":" + "\"" + fee + "" + "\",\"multipleAmounts\":" + "\"" + multipleamounts + "" + "\",\"paymentId\":" + "\"" + paymentid + "" + "\",\"senderNote\":" + "\"" + sendernote + "" + "\"}";

            var stringResult = await PostSecureRequest($"withdrawal", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }





        /// <summary>
        /// Get Withdrawal Offchain
        /// </summary>
        /// <param name="currency"></param>
        /// <param name="status"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>



        public async Task<OffBlockchain> GetWithdrawalsOffchain(string currency, string status, int pagesize)
        {
           
            var stringResult = await GetSecureRequest($"withdrawal?currency=" + currency +"&status=" + status + "&pageSize=10&offset=0");

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }






        /// <summary>
        /// Complete Withdrawal Offchain
        /// </summary>
        /// <param name="id"></param>
        /// <param name="txid"></param>
        /// <returns></returns>



        public async Task<OffBlockchain> CompleteWithdrawalOffchain(string id, string txid)
        {
            string parameters = "";

            var stringResult = await PUTSecureRequest($"withdrawal/{id}/{txid}",parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }






        /// <summary>
        /// Cancel Withdrawal
        /// </summary>
        /// <param name="id"></param>
        /// <param name="revert"></param>
        /// <returns></returns>


        public async Task<OffBlockchain> CancelWithdrawalOffchain(string id, string revert)
        {
            

            var stringResult = await DeleteSecureRequest($"withdrawal/{id}?revert=true");

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }







        /// <summary>
        /// Broadcast transaction and complete withdrawal
        /// </summary>
        /// <param name="currency"></param>
        /// <param name="txdata"></param>
        /// <param name="withdrawalid"></param>
        /// <param name="signatureid"></param>
        /// <returns></returns>




        public async Task<OffBlockchain> BroadcastSignedTransactionOffchain(string currency, string txdata, string withdrawalid, string signatureid)
        {
            string parameters = "{\"currency\":" + "\"" + currency + "" + "\",\"txData\":" + "\"" + txdata + "" + "\",\"withdrawalId\":" + "\"" + withdrawalid + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\"}";

            var stringResult = await PostSecureRequest($"withdrawal/broadcast", parameters);

            var result = JsonConvert.DeserializeObject<OffBlockchain>(stringResult);

            return result;
        }























        private async Task<string> GetSecureRequest(string path, Dictionary<string, string> paramaters = null)
        {
            var baseUrl = "https://api-eu1.tatum.io/v3/offchain";

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

            var baseUrl = "https://api-eu1.tatum.io/v3/offchain";

            baseUrl = $"{baseUrl}/{path}";


            HttpWebRequest reqc = (HttpWebRequest)WebRequest.Create(baseUrl);

            reqc.Method = "POST";
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


        private async Task<string> PUTSecureRequest(string path, string parameters)
        {

            var baseUrl = "https://api-eu1.tatum.io/v3/offchain";

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
            var baseUrl = "https://api-eu1.tatum.io/v3/offchain";

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
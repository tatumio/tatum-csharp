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
/// Summary description for TatumClient
/// </summary>
namespace Tatum
{
    public partial class LedgerClient: ILedgerClient 
    {
       
        private readonly string _privateKey;
        private readonly string _serverUrl;

        public LedgerClient(string privateKey, string serverUrl)
        {
            _privateKey = privateKey;
            _serverUrl = serverUrl;
        }





        public async Task<Account> CreateAccount(string currency, string xpub, string externalid, bool compliant, string accountCode, string accountingCurrency, string accountNumber)
        {



            string parameters = "{\"currency\":" + "\"" + currency + "" + "\",\"xpub\":" + "\"" + xpub + "" + "\",\"customer\":{\"externalId\":" + "\"" + externalid + "" + "\"},\"compliant\":false,\"accountCode\":" + "\"" + accountCode + "" + "\",\"accountingCurrency\":" + "\"" + accountingCurrency + "" + "\",\"accountNumber\":" + "\"" + accountNumber + "" + "\"}";


            var stringResult = await PostSecureRequest($"account", parameters);

            var result = JsonConvert.DeserializeObject<Account>(stringResult);

            return result;
        }


        public async Task<List<Account>> CreateAccounts(string currency, string xpub, string externalid, bool compliant, string accountCode, string accountingCurrency, string accountNumber)
        {


            string parameters = "{\"accounts\":[{\"currency\":" + "\"" + currency + "" + "\",\"xpub\":" + "\"" + xpub + "" + "\",\"customer\":{\"externalId\":" + "\"" + externalid + "" + "\"},\"compliant\":false,\"accountCode\":" + "\"" + accountCode + "" + "\",\"accountingCurrency\":" + "\"" + accountingCurrency + "" + "\",\"accountNumber\":" + "\"" + accountNumber + "" + "\"}]}";


            var stringResult = await PostSecureRequest($"account/batch", parameters);

            var result = JsonConvert.DeserializeObject<List<Account>>(stringResult);

            return result;
        }


        public async Task<Account> UpdateAccount(string id,string accountCode,string accountNumber)
        {


            string parameters = "{\"accountCode\":" + "\"" + accountCode + "" + "\",\"accountNumber\":" + "\"" + accountNumber + "" + "\"}";

            var stringResult = await PUTSecureRequest($"account/{id}", parameters);

            var result = JsonConvert.DeserializeObject<Account>(stringResult);

            return result;
        }


        public async  Task<List<Account>> GetAllAccounts(int pageSize = 50, int offset = 0)
        {


            var stringResult = await GetSecureRequest($"account?pageSize={pageSize}&offset={offset}");

            var result = JsonConvert.DeserializeObject<List<Account>>(stringResult);

            return result;
        }


        public async Task<List<Account>> GetCustomerAccounts(string id,int pageSize = 50, int offset = 0)
        {


            var stringResult = await GetSecureRequest($"account/customer/{id}?pageSize={pageSize}&offset={offset}");

            var result = JsonConvert.DeserializeObject<List<Account>>(stringResult);

            return result;
        }

        public async Task<Account> GetAccount(string id)
        {


            var stringResult = await GetSecureRequest($"account/{id}");

            var result = JsonConvert.DeserializeObject<Account>(stringResult);

            return result;
        }

        public async Task<AccountBalance> GetAccountBalance(string id)
        {


            var stringResult = await GetSecureRequest($"account/{id}/balance");

            var result = JsonConvert.DeserializeObject<AccountBalance>(stringResult);

            return result;
        }

        public async Task<Account> ActivateAccount(string id)
        {

            string parameters = "";

            var stringResult = await PUTSecureRequest($"account/{id}/activate",parameters);

            var result = JsonConvert.DeserializeObject<Account>(stringResult);

            return result;
        }

        public async Task<Account> FreezeAccount(string id)
        {

            string parameters = "";

            var stringResult = await PUTSecureRequest($"account/{id}/freeze", parameters);

            var result = JsonConvert.DeserializeObject<Account>(stringResult);

            return result;
        }
        public async Task<Account> DeactivateAccount(string id)
        {

            string parameters = "";

            var stringResult = await PUTSecureRequest($"account/{id}/deactivate", parameters);

            var result = JsonConvert.DeserializeObject<Account>(stringResult);

            return result;
        }
        public async Task<Account> UnfreezeAccount(string id)
        {

            string parameters = "";

            var stringResult = await PUTSecureRequest($"account/{id}/unfreeze", parameters);

            var result = JsonConvert.DeserializeObject<Account>(stringResult);

            return result;
        }
        public async Task<List<Blockage>> GetBlockedAmounts(string id, int pageSize = 50, int offset = 0)
        {


            var stringResult = await GetSecureRequest($"account/block/{id}?pageSize={pageSize}&offset={offset}");

            var result = JsonConvert.DeserializeObject<List<Blockage>>(stringResult);

            return result;
        }

        public async Task<Blockage> GetBlockedAmount(string id)
        {


            var stringResult = await GetSecureRequest($"account/block/{id}/detail");

            var result = JsonConvert.DeserializeObject<Blockage>(stringResult);

            return result;
        }

        public async Task<Blockage> BlockAmount(string id,string amount,string type,string description)
        {

             string parameters = "{\"amount\":" + "\"" + amount + "" + "\",\"type\":" + "\"" + type + "" + "\",\"description\":" + "\"" + description + "" + "\"}";

         

            var stringResult = await PostSecureRequest($"account/block/{id}",parameters);

            var result = JsonConvert.DeserializeObject<Blockage>(stringResult);

            return result;
        }

        public async Task<Blockage> UnblockAmounts(string id, string recipientAccountId, string amount, string anonymous, string compliant, string transactionCode, string paymentId, string recipientNote, string baseRate, string senderNote)
        {

            string parameters = "{\"recipientAccountId\":\"5e6645712b55823de7ea82f2\",\"amount\":\"5\",\"anonymous\":false,\"compliant\":false,\"transactionCode\":\"1_01_EXTERNAL_CODE\",\"paymentId\":\"9625\",\"recipientNote\":\"Private note\",\"baseRate\":1,\"senderNote\":\"Sender note\"}";

           // string parameters = "{\"recipientAccountId\":" + "\"" + recipientAccountId + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"anonymous\":false,\"compliant\":false,\"transactionCode\":" + "\"" + transactionCode + "" + "\",\"paymentId\":" + "\"" + paymentId + "" + "\",\"recipientNote\":" + "\"" + recipientNote + "" + "\",\"baseRate\":1,\"senderNote\":" + "\"" + senderNote + "" + "\"}";

            var stringResult = await PUTSecureRequest($"account/block/{id}", parameters);

            var result = JsonConvert.DeserializeObject<Blockage>(stringResult);

            return result;
        }


        public async Task<Blockage> UnblockBlockedAmount(string id)
        {


            var stringResult = await DeleteSecureRequest($"account/block/{id}");

            var result = JsonConvert.DeserializeObject<Blockage>(stringResult);

            return result;
        }

        public async Task<Transaction> StoreTransaction(string senderAccountId, string recipientAccountId, string amount, bool anonymous, bool compliant, string transactionCode, string paymentId, string recipientNote, string baseRate, string senderNote)
        {



            string parameters = "{\"senderAccountId\":\"5e6645712b55823de7ea82f1\",\"recipientAccountId\":\"5e6645712b55823de7ea82f2\",\"amount\":\"5\",\"anonymous\":false,\"compliant\":false,\"transactionCode\":\"1_01_EXTERNAL_CODE\",\"paymentId\":\"9625\",\"recipientNote\":\"Private note\",\"baseRate\":1,\"senderNote\":\"Sender note\"}";

           // string parameters = "{\"senderAccountId\":" + "\"" + senderAccountId + "" + "\",\"recipientAccountId\":" + "\"" + recipientAccountId + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"anonymous\":false,\"compliant\":false,\"transactionCode\":" + "\"" + transactionCode + "" + "\",\"paymentId\":" + "\"" + paymentId + "" + "\",\"recipientNote\":" + "\"" + recipientNote + "" + "\",\"baseRate\":1,\"senderNote\":" + "\"" + senderNote + "" + "\"}";

            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<Transaction>(stringResult);

            return result;
        }

        public async Task<List<Transaction>> GetTransactionsByAccount(string id, string counterAccount, int from, int to, string currency, string op,string gte, string value, string currencies, string transactionType, string transactionTypes, string opType, string transactionCode, string paymentId, string recipientNote, string senderNote)
        {



           
            string parameters = "{\"id\":" + "\"" + id + "" + "\",\"counterAccount\":" + "\"" + counterAccount + "" + "\",\"from\":1571833231000,\"to\":1571833231000,\"currency\":" + "\"" + currency + "" + "\",\"amount\":[{" + "\"" + op + "" + "\":" + "\"" + gte + "" + "\",\"value\":" + "\"" + value + "" + "\"}],\"currencies\":[\"BTC\"],\"transactionType\":" + "\"" + transactionType + "" + "\",\"transactionTypes\":[\"CREDIT_PAYMENT\"],\"opType\":" + "\"" + opType + "" + "\",\"transactionCode\":" + "\"" + transactionCode + "" + "\",\"paymentId\":" + "\"" + paymentId + "" + "\",\"recipientNote\":" + "\"" + recipientNote + "" + "\",\"senderNote\":" + "\"" + senderNote + "" + "\"}";


           
            var stringResult = await PostSecureRequest($"transaction/account?pageSize=10&offset=0", parameters);

            var result = JsonConvert.DeserializeObject<List<Transaction>>(stringResult);

            return result;
        }

        public async Task<List<Transaction>> GetTransactionsByCustomer(string id, string account, string counterAccount, string currency, int from, int to, string op, string gte, string value, string currencies, string transactionType, string transactionTypes, string opType, string transactionCode, string paymentId, string recipientNote, string senderNote)
        {



           
            string parameters = "{\"id\":" + "\"" + id + "" + "\",\"account\":" + "\"" + account + "" + "\",\"counterAccount\":" + "\"" + counterAccount + "" + "\",\"from\":1571833231000,\"to\":1571833231000,\"currency\":" + "\"" + currency + "" + "\",\"amount\":[{" + "\"" + op + "" + "\":" + "\"" + gte + "" + "\",\"value\":" + "\"" + value + "" + "\"}],\"currencies\":[\"BTC\"],\"transactionType\":" + "\"" + transactionType + "" + "\",\"transactionTypes\":[\"CREDIT_PAYMENT\"],\"opType\":" + "\"" + opType + "" + "\",\"transactionCode\":" + "\"" + transactionCode + "" + "\",\"paymentId\":" + "\"" + paymentId + "" + "\",\"recipientNote\":" + "\"" + recipientNote + "" + "\",\"senderNote\":" + "\"" + senderNote + "" + "\"}";



            var stringResult = await PostSecureRequest($"transaction/customer?pageSize=10&offset=0", parameters);

            var result = JsonConvert.DeserializeObject<List<Transaction>>(stringResult);

            return result;
        }
        public async Task<List<Transaction>> GetTransactionsByLedger( string account, string counterAccount, string currency, int from, string op, string gte, string value, string currencies, string transactionType, string transactionTypes, string opType, string transactionCode, string paymentId, string recipientNote, string senderNote,int to)
        {



            string parameters = "{\"account\":" + "\"" + account + "" + "\",\"counterAccount\":" + "\"" + counterAccount + "" + "\",\"currency\":" + "\"" + currency + "" + "\",\"from\":1571833231000,\"amount\":[{" + "\"" + op + "" + "\":" + "\"" + gte + "" + "\",\"value\":" + "\"" + value + "" + "\"}],\"currencies\":[" + "\"" + currencies + "" + "\"],\"transactionType\":" + "\"" + transactionType + "" + "\",\"transactionTypes\":[\"CREDIT_PAYMENT\"],\"opType\":" + "\"" + opType + "" + "\",\"transactionCode\":" + "\"" + transactionCode + "" + "\",\"paymentId\":" + "\"" + paymentId + "" + "\",\"recipientNote\":" + "\"" + recipientNote + "" + "\",\"senderNote\":" + "\"" + senderNote + "" + "\",\"to\":1571833231000}";

           

            var stringResult = await PostSecureRequest($"transaction/customer?pageSize=10&offset=0", parameters);

            var result = JsonConvert.DeserializeObject<List<Transaction>>(stringResult);

            return result;
        }

        public async Task<List<Transaction>> GetTransactionByReference(string reference)
        {


            var stringResult = await GetSecureRequest($"transaction/reference/{reference}");

            var result = JsonConvert.DeserializeObject<List<Transaction>>(stringResult);

            return result;
        }

        public async Task<List<Customer>> GetAllCustomers(int pageSize = 50, int offset = 0)
        {


            var stringResult = await GetSecureRequest($"customer?pageSize={pageSize}&offset={offset}");

            var result = JsonConvert.DeserializeObject<List<Customer>>(stringResult);

            return result;
        }

        public async Task<Customer> GetCustomer(string id)
        {


            var stringResult = await GetSecureRequest($"customer/{id}");

            var result = JsonConvert.DeserializeObject<Customer>(stringResult);

            return result;
        }

        public async Task<Customer> UpdateCustomer(string id, string externalId, string accountingCurrency, string customerCountry, string providerCountry)
        {

            string parameters = "{\"externalId\":" + "\"" + externalId + "" + "\",\"accountingCurrency\":" + "\"" + accountingCurrency + "" + "\",\"customerCountry\":" + "\"" + customerCountry + "" + "\",\"providerCountry\":" + "\"" + providerCountry + "" + "\"}";
         

            var stringResult = await PUTSecureRequest($"customer/{id}", parameters);

            var result = JsonConvert.DeserializeObject<Customer>(stringResult);

            return result;
        }

        public async Task<Customer> ActivateCustomer(string id)
        {

            
            string parameters = "";

            var stringResult = await PUTSecureRequest($"customer/{id}/activate", parameters);

            var result = JsonConvert.DeserializeObject<Customer>(stringResult);

            return result;
        }

        public async Task<Customer> DeactivateCustomer(string id)
        {


            string parameters = "";

            var stringResult = await PUTSecureRequest($"customer/{id}/deactivate", parameters);

            var result = JsonConvert.DeserializeObject<Customer>(stringResult);

            return result;
        }
        public async Task<Customer> EnableCustomer(string id)
        {


            string parameters = "";

            var stringResult = await PUTSecureRequest($"customer/{id}/enable", parameters);

            var result = JsonConvert.DeserializeObject<Customer>(stringResult);

            return result;
        }
        public async Task<Customer> DisableCustomer(string id)
        {


            string parameters = "";

            var stringResult = await PUTSecureRequest($"customer/{id}/disable", parameters);

            var result = JsonConvert.DeserializeObject<Customer>(stringResult);

            return result;
        }



        public async Task<VirtualCurrency> CreateVirtualCurrency(string name, string supply, string basePair, string baseRate, string accountingCurrency, string customerCountry, string externalId, string providerCountry, string description, string accountCode, string accountNumber)
        {

           
            string parameters = "{\"name\":" + "\"" + name + "" + "\",\"supply\":" + "\"" + supply + "" + "\",\"basePair\":" + "\"" + basePair + "" + "\",\"baseRate\":1,\"customer\":{\"accountingCurrency\":" + "\"" + accountingCurrency + "" + "\",\"customerCountry\":" + "\"" + customerCountry + "" + "\",\"externalId\":" + "\"" + externalId + "" + "\",\"providerCountry\":" + "\"" + providerCountry + "" + "\"},\"description\":" + "\"" + description + "" + "\",\"accountCode\":" + "\"" + accountCode + "" + "\",\"accountNumber\":" + "\"" + accountNumber + "" + "\",\"accountingCurrency\":" + "\"" + accountingCurrency + "" + "\"}";

            var stringResult = await PostSecureRequest($"virtualCurrency", parameters);

            var result = JsonConvert.DeserializeObject<VirtualCurrency>(stringResult);

            return result;
        }
        public async Task<VirtualCurrency> UpdateVirtualCurrency(string name, string baseRate, string basePair)
        {


            string parameters = "{\"name\":" + "\"" + name + "" + "\",\"baseRate\":1,\"basePair\":" + "\"" + basePair + "" + "\"}";

            var stringResult = await PUTSecureRequest($"virtualCurrency", parameters);

            var result = JsonConvert.DeserializeObject<VirtualCurrency>(stringResult);

            return result;
        }
        public async Task<VirtualCurrency> GetVirtualCurrency(string name)
        {


            var stringResult = await GetSecureRequest($"virtualCurrency/{name}");

            var result = JsonConvert.DeserializeObject<VirtualCurrency>(stringResult);

            return result;
        }

        public async Task<VirtualCurrency> MintVirtualCurrency(string accountId, string amount, string paymentId, string reference, string transactionCode, string recipientNote, string counterAccount, string senderNote)
        {

            string parameters = "{\"accountId\":" + "\"" + accountId + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"paymentId\":" + "\"" + paymentId + "" + "\",\"reference\":" + "\"" + reference + "" + "\",\"transactionCode\":" + "\"" + transactionCode + "" + "\",\"recipientNote\":" + "\"" + recipientNote + "" + "\",\"counterAccount\":" + "\"" + counterAccount + "" + "\",\"senderNote\":" + "\"" + senderNote + "" + "\"}";
        
            var stringResult = await PUTSecureRequest($"virtualCurrency/mint", parameters);

            var result = JsonConvert.DeserializeObject<VirtualCurrency>(stringResult);

            return result;
        }

        public async Task<VirtualCurrency> RevokeVirtualCurrency(string accountId, string amount, string paymentId, string reference, string transactionCode, string recipientNote, string counterAccount, string senderNote)
        {

            string parameters = "{\"accountId\":" + "\"" + accountId + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"paymentId\":" + "\"" + paymentId + "" + "\",\"reference\":" + "\"" + reference + "" + "\",\"transactionCode\":" + "\"" + transactionCode + "" + "\",\"recipientNote\":" + "\"" + recipientNote + "" + "\",\"counterAccount\":" + "\"" + counterAccount + "" + "\",\"senderNote\":" + "\"" + senderNote + "" + "\"}";

            var stringResult = await PUTSecureRequest($"virtualCurrency/revoke", parameters);

            var result = JsonConvert.DeserializeObject<VirtualCurrency>(stringResult);

            return result;
        }




        public async Task<Subscription> CreateNewSubscription(string type, string id,string url)
        {


            string parameters = "{\"type\":\"ACCOUNT_INCOMING_BLOCKCHAIN_TRANSACTION\",\"attr\":{\"id\":\"5e6be8e9e6aa436299950c41\",\"url\":\"https://webhook.tatum.io/account\"}}";
           // string parameters = "{\"currency\":" + "\"" + currency + "" + "\",\"xpub\":" + "\"" + xpub + "" + "\",\"customer\":{\"externalId\":" + "\"" + externalid + "" + "\"},\"compliant\":false,\"accountCode\":" + "\"" + accountCode + "" + "\",\"accountingCurrency\":" + "\"" + accountingCurrency + "" + "\",\"accountNumber\":" + "\"" + accountNumber + "" + "\"}";


            var stringResult = await PostSecureRequest($"subscription", parameters);

            var result = JsonConvert.DeserializeObject<Subscription>(stringResult);

            return result;
        }
        public async Task<List<Subscription>> GetActiveSubscriptions(int pageSize = 50, int offset = 0)
        {


            var stringResult = await GetSecureRequest($"subscription?pageSize={pageSize}&offset={offset}");

            var result = JsonConvert.DeserializeObject<List<Subscription>>(stringResult);

            return result;
        }
        public async Task<Subscription> EnableHmacWebhook(string hmacsecret)
        {


            string parameters = "{\"hmacSecret\":\"1f7f7c0c-3906-4aa1-9dfe-4b67c43918f6\"}";

            var stringResult = await PUTSecureRequest($"subscription", parameters);

            var result = JsonConvert.DeserializeObject<Subscription>(stringResult);

            return result;
        }
        public async Task<Subscription> CancelExistingSubscription(string id)
        {


            //string parameters = "";

            var stringResult = await DeleteSecureRequest($"subscription/{id}");

            var result = JsonConvert.DeserializeObject<Subscription>(stringResult);

            return result;
        }
        public async Task<List<Account>> ObtainReportForSubscription(string id)
        {


            var stringResult = await GetSecureRequest($"subscription/report/{id}");

            var result = JsonConvert.DeserializeObject<List<Account>>(stringResult);

            return result;
        }





        public async Task<OrderBook> StoreTrade(string type, string price, string amount, string pair, string currency1AccountId, string currency2AccountId, string feeAccountId, double fee, int sealDate, int percentBlock, int percentPenalty)
        {


            string parameters = "{\"type\":\"BUY\",\"price\":\"8650.4\",\"amount\":\"0.0000078\",\"pair\":\"BTC/EUR\",\"currency1AccountId\":\"60aa10194d94359c9cf60fdc\",\"currency2AccountId\":\"611aab6f4470937a0ce14eb1\",\"feeAccountId\":\"	60aa10194d94359c9cf60fdc\",\"fee\":1.5,\"attr\":{\"sealDate\":1572031674384,\"percentBlock\":1.5,\"percentPenalty\":1.5}}";
            // string parameters = "{\"currency\":" + "\"" + currency + "" + "\",\"xpub\":" + "\"" + xpub + "" + "\",\"customer\":{\"externalId\":" + "\"" + externalid + "" + "\"},\"compliant\":false,\"accountCode\":" + "\"" + accountCode + "" + "\",\"accountingCurrency\":" + "\"" + accountingCurrency + "" + "\",\"accountNumber\":" + "\"" + accountNumber + "" + "\"}";


            var stringResult = await PostSecureRequest($"trade", parameters);

            var result = JsonConvert.DeserializeObject<OrderBook>(stringResult);

            return result;
        }

        public async Task<List<OrderBook>> GetHistoricalTrades(string pair, int from, int to, string timeFrame)
        {


            string parameters = "{\"pair\":\"BTC/EUR\",\"from\":1613654998398,\"to\":1613654998398,\"timeFrame\":\"MIN_5\"}";
            // string parameters = "{\"currency\":" + "\"" + currency + "" + "\",\"xpub\":" + "\"" + xpub + "" + "\",\"customer\":{\"externalId\":" + "\"" + externalid + "" + "\"},\"compliant\":false,\"accountCode\":" + "\"" + accountCode + "" + "\",\"accountingCurrency\":" + "\"" + accountingCurrency + "" + "\",\"accountNumber\":" + "\"" + accountNumber + "" + "\"}";


            var stringResult = await PostSecureRequest($"trade/chart", parameters);

            var result = JsonConvert.DeserializeObject<List<OrderBook>>(stringResult);

            return result;
        }











        private async Task<string> GetSecureRequest(string path, Dictionary<string, string> paramaters=null)
        {
            var baseUrl = serverUrl + "/v3/ledger";

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

            var baseUrl = serverUrl + "/v3/ledger";

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

            var baseUrl = serverUrl + "/v3/ledger";

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
            var baseUrl = serverUrl + "/v3/ledger";

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
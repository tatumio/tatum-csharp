using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

/// <summary>
/// Summary description for ITatumClient
/// </summary>
/// 
namespace Tatum
{
        public interface ILedgerClient
        {

        /// <summary>
        /// Accounts
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        Task<Account> CreateAccount(string currency,string xpub,string externalid,bool compliant,string accountCode,string accountingCurrency,string accountNumber);
        Task<List<Account>> CreateAccounts(string currency, string xpub, string externalid, bool compliant, string accountCode, string accountingCurrency, string accountNumber);
        Task<List<Account>> GetAllAccounts(int pageSize = 50, int offset = 0);
        Task<List<Account>> GetCustomerAccounts(string id, int pageSize = 50, int offset = 0);
        Task<Account> GetAccount(string id);
        Task<Account> UpdateAccount(string id, string accountCode, string accountNumber);
        Task<AccountBalance> GetAccountBalance(string id);

        Task<Account> ActivateAccount(string id);
        Task<Account> FreezeAccount(string id);
        Task<Account> DeactivateAccount(string id);
        Task<Account> UnfreezeAccount(string id);
        Task<List<Blockage>> GetBlockedAmounts(string id,int pageSize = 50, int offset = 0);
        Task<Blockage> GetBlockedAmount(string id);
        Task<Blockage> BlockAmount(string id, string amount, string type, string description);
        Task<Blockage> UnblockAmounts(string id, string recipientAccountId, string amount,string anonymous,string compliant,string transactionCode,string paymentId,string recipientNote,string baseRate,string senderNote);
        Task<Blockage> UnblockBlockedAmount(string id);
        Task<Transaction> StoreTransaction(string senderAccountId, string recipientAccountId, string amount, bool anonymous, bool compliant, string transactionCode, string paymentId,string recipientNote,string baseRate,string senderNote);
        Task<List<Transaction>> GetTransactionsByAccount(string id, string counterAccount, int from, int to, string currency, string op,string gte, string value, string currencies, string transactionType, string transactionTypes,string opType,string transactionCode,string paymentId,string recipientNote,string senderNote);
        Task<List<Transaction>> GetTransactionsByCustomer(string id,string account, string counterAccount, string currency, int from, int to,  string op, string gte, string value, string currencies, string transactionType, string transactionTypes, string opType, string transactionCode, string paymentId, string recipientNote, string senderNote);
        Task<List<Transaction>> GetTransactionsByLedger(string account, string counterAccount, string currency, int from, string op, string gte, string value, string currencies, string transactionType, string transactionTypes, string opType, string transactionCode, string paymentId, string recipientNote, string senderNote, int to);
        Task<List<Transaction>> GetTransactionByReference(string reference);

        Task<List<Customer>> GetAllCustomers(int pageSize = 50, int offset = 0);
        Task<Customer> GetCustomer(string id);
        Task<Customer> UpdateCustomer(string id, string externalId, string accountingCurrency,string customerCountry,string providerCountry);
        Task<Customer> ActivateCustomer(string id);
        Task<Customer> DeactivateCustomer(string id);
        Task<Customer> EnableCustomer(string id);
        Task<Customer> DisableCustomer(string id);


        Task<VirtualCurrency> CreateVirtualCurrency(string name,string supply,string basePair,string baseRate,string accountingCurrency,string customerCountry,string externalId,string providerCountry,string description,string accountCode,string accountNumber);
        Task<VirtualCurrency> UpdateVirtualCurrency(string name, string baseRate, string basePair);
        Task<VirtualCurrency> GetVirtualCurrency(string name);
        Task<VirtualCurrency> MintVirtualCurrency(string accountId, string amount, string paymentId,string reference,string transactionCode,string recipientNote,string counterAccount,string senderNote);
        Task<VirtualCurrency> RevokeVirtualCurrency(string accountId, string amount, string paymentId, string reference, string transactionCode, string recipientNote, string counterAccount, string senderNote);



        Task<Subscription> CreateNewSubscription( string type, string id,string url);
        Task<List<Subscription>> GetActiveSubscriptions(int pageSize = 50, int offset = 0);
        Task<Subscription> EnableHmacWebhook(string hmacsecret);
        Task<Subscription> CancelExistingSubscription(string id);
        Task<List<Account>> ObtainReportForSubscription(string id);





        Task<OrderBook> StoreTrade(string type,string price,string amount,string pair,string currency1AccountId,string currency2AccountId,string feeAccountId,double fee,int sealDate,int percentBlock,int percentPenalty);
        Task<List<OrderBook>> GetHistoricalTrades(string pair,int from ,int to,string timeFrame);


    }

}
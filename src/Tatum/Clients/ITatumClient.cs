using System.Collections.Generic;
using System.Threading.Tasks;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

namespace Tatum.Clients
{
    public interface ITatumClient
    {
        Task<Account> GetAccount(string id);
        Task<Account> CreateAccount(CreateAccount createAccount);
        Task<List<Account>> CreateAccounts(List<CreateAccount> createAccounts);
        Task<List<Blockage>> GetBlockedAmounts(string accountId, int pageSize = 50, int offset = 0);
        Task<string> BlockAmount(string accountId, BlockAmount blockAmount);
        Task UnblockBlockedAmount(string blockageId);
        Task UnblockAllBlockedAmounts(string accountId);
        Task ActivateAccount(string accountId);
        Task DeactivateAccount(string accountId);
        Task FreezeAccount(string accountId);
        Task UnfreezeAccount(string accountId);
        Task<List<Account>> GetAccounts(string customerId, int pageSize = 50, int offset = 0);
        Task<List<Account>> GetAccounts(int pageSize = 50, int offset = 0);
        Task<AccountBalance> GetAccountBalance(string accountId);

        Task<Customer> GetCustomer(string customerId);
        Task<List<Customer>> GetCustomers(int pageSize = 50, int offset = 0);
        Task<Customer> UpdateCustomer(string customerInternalId, UpdateCustomer updateCustomer);
        Task ActivateCustomer(string customerInternalId);
        Task DeactivateCustomer(string customerInternalId);
        Task EnableCustomer(string customerInternalId);
        Task DisableCustomer(string customerInternalId);

        Task<List<OrderBook>> GetHistoricalTrades(int pageSizes = 50, int offset = 0);
        Task<List<OrderBook>> GetActiveBuyTrades(string accountId, int pageSize = 50, int offset = 0);
        Task<List<OrderBook>> GetActiveSellTrades(string accountId, int pageSize = 50, int offset = 0);
        Task<string> StoreTrade(OrderBookRequest data);
        Task<OrderBook> GetTrade(string tradeId);
        Task DeleteTrade(string tradeId);
        Task DeleteAccountTrades(string accountId);

        Task<string> CreateSubscription(CreateSubscription data);
        Task<List<Subscription>> GetActiveSubscriptions(int pageSize = 50, int offset = 0);
        Task CancelExistingSubscription(string subscriptionId);
        Task<object> ObtainReport(string subscriptionId);

        Task<List<Transaction>> GetTransactions(string reference);
        Task<string> StoreTransaction(CreateTransaction transaction);
        Task<List<Transaction>> GetTransactionsForAccount(TransactionFilter filter, int pageSize = 50, int offset = 0);
        Task<List<Transaction>> GetTransactionsForCustomer(TransactionFilter filter, int pageSize = 50, int offset = 0);
        Task<List<Transaction>> GetTransactionsForLedger(TransactionFilter filter, int pageSize = 50, int offset = 0);
        Task<int> CountTransactionsForAccount(TransactionFilter filter);
        Task<int> CountTransactionsForCustomer(TransactionFilter filter);
        Task<int> CountTransactionsForLedger(TransactionFilter filter);


    }
}

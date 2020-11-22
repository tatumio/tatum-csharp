using System.Collections.Generic;
using System.Threading.Tasks;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

namespace Tatum.Clients
{
    public interface ITatumClient
    {
        Task<List<CreditUsage>> GetCreditUsageForLastMonth();
        Task<Rate> GetExchangeRate(string currency, string basePair);
        Task<string> GetTatumVersion();

        Task<Address> GenerateDepositAddress(string accountId, int index);
        Task<List<Address>> GenerateDepositAddresses(List<GenerateAddressRequest> addresses);
        Task<Account> CheckAddressExists(string address, string currency, string index);
        Task<Address> AssignDepositAddress(string id, string address);
        Task RemoveDepositAddress(string id, string address);
        Task<List<Address>> GetAddresses(string accountId);
        Task<TxHash> OffchainBroadcast(BroadcastWithdrawal withdrawal);
        Task<WithdrawalResponse> OffchainStoreWithdrawal(CreateWithdrawal withdrawal);
        Task OffchainCancelWithdrawal(string withdrawalId, bool revert = true);
        Task OffchainCompleteWithdrawal(string withdrawalId, string txId);

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
        Task<List<Transaction>> GetTransactionsForAccount(TransactionFilterAccount filter, int pageSize = 50, int offset = 0);
        Task<List<Transaction>> GetTransactionsForCustomer(TransactionFilterCustomer filter, int pageSize = 50, int offset = 0);
        Task<List<Transaction>> GetTransactionsForLedger(TransactionFilterLedger filter, int pageSize = 50, int offset = 0);
        Task<int> CountTransactionsForAccount(TransactionFilterAccount filter);
        Task<int> CountTransactionsForCustomer(TransactionFilterCustomer filter);
        Task<int> CountTransactionsForLedger(TransactionFilterLedger filter);

        Task<VirtualCurrency> GetVirtualCurrency(string virtualCurrencyName);
        Task<Account> CreateVirtualCurrency(CreateVirtualCurrency currency);
        Task UpdateVirtualCurrency(UpdateVirtualCurrency currency);
        Task<string> MintVirtualCurrency(CurrencyOperation operation);
        Task<string> RevokeVirtualCurrency(CurrencyOperation operation);

        Task<string> CheckMaliciousAddress(string address);
        Task<TransactionKms> GetTransactionKms(string transactionId);
        Task DeleteTransactionKms(string transactionId, bool revert = true);
        Task CompletePendingTransactionKms(string transactionId, string txId);
        Task<List<TransactionKms>> GetPendingTransactionsKms(string blockchain);

    }
}

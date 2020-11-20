using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

namespace Tatum.Blockchain
{
    public interface ITatumApi
    {
        [Get("/v3/tatum/usage")]
        Task<List<CreditUsage>> GetCreditUsageForLastMonth();

        [Get("/v3/tatum/rate/{currency}?basePair={basePair}")]
        Task<Rate> GetExchangeRate(string currency, string basePair);

        [Get("/v3/tatum/version")]
        Task<string> GetTatumVersion();

        //Offchain

        [Post("/v3/offchain/account/{accountId}/address?index={index}")]
        Task<Address> GenerateDepositAddress(string accountId, int index);

        [Post("/v3/offchain/account/address/batch")]
        Task<List<Address>> GenerateDepositAddresses(List<GenerateAddressRequest> addresses);

        [Get("/v3/offchain/account/address/{address}/{currency}?index={index}")]
        Task<Account> CheckAddressExists(string address, string currency, string index);

        [Post("/v3/offchain/account/{accountId}/address/{address}")]
        Task<Address> AssignDepositAddress(string accountId, string address);

        [Delete("/v3/offchain/account/{accountId}/address/{address}")]
        Task RemoveDepositAddress(string accountId, string address);

        [Get("/v3/offchain/account/{accountId}/address")]
        Task<List<Address>> GetAddresses(string accountId);

        [Post("/v3/offchain/withdrawal/broadcast")]
        Task<TxHash> OffchainBroadcast(BroadcastWithdrawal withdrawal);

        [Post("/v3/offchain/withdrawal")]
        Task<WithdrawalResponse> OffchainStoreWithdrawal(CreateWithdrawal withdrawal);

        [Delete("/v3/offchain/withdrawal/{withdrawalId}")]
        Task OffchainCancelWithdrawal(string withdrawalId, bool revert = true);

        [Put("/v3/offchain/withdrawal/{withdrawalId}/{txId}")]
        Task OffchainCompleteWithdrawal(string withdrawalId, string txId);

        //Ledger Account

        [Get("/v3/ledger/account/{accountId}")]
        Task<Account> GetAccount(string accountId);

        [Post("/v3/ledger/account")]
        Task<Account> CreateAccount(CreateAccount account);

        [Post("/v3/ledger/account/batch")]
        Task<List<Account>> CreateAccounts(List<CreateAccount> accounts);

        [Get("/v3/ledger/account/block/{accountId}?pageSize={pageSize}&offset={offset}")]
        Task<List<Blockage>> GetBlockedAmounts(string accountId, int pageSize = 50, int offset = 0);

        [Post("/v3/ledger/account/block/{accountId}")]
        Task<string> BlockAmount(string accountId, BlockAmount blockAmount);

        [Delete("/v3/ledger/account/block/{blockageId}")]
        Task UnblockBlockedAmount(string blockageId);

        [Delete("/v3/ledger/account/block/account/{accountId}")]
        Task UnblockAllBlockedAmounts(string accountId);

        [Put("/v3/ledger/account/{accountId}/activate")]
        Task ActivateAccount(string accountId);

        [Put("/v3/ledger/account/{accountId}/deactivate")]
        Task DeactivateAccount(string accountId);

        [Put("/v3/ledger/account/{accountId}/freeze")]
        Task FreezeAccount(string accountId);

        [Put("/v3/ledger/account/{accountId}/unfreeze")]
        Task UnfreezeAccount(string accountId);

        [Get("/v3/ledger/account/customer/{customerId}?pageSize={pageSize}&offset={offset}")]
        Task<List<Account>> GetAccounts(string customerId, int pageSize = 50, int offset = 0);

        [Get("/v3/ledger/account?pageSize={pageSize}&offset={offset}")]
        Task<List<Account>> GetAccounts(int pageSize = 50, int offset = 0);

        [Get("/v3/ledger/account/{accountId}/balance")]
        Task<AccountBalance> GetAccountBalance(string accountId);

        //Ledger Customer

        [Get("/v3/ledger/customer/{customerId}")]
        Task<Customer> GetCustomer(string customerId);

        [Get("/v3/ledger/customer?pageSize={pageSize}&offset={offset}")]
        Task<List<Customer>> GetCustomers(int pageSize = 50, int offset = 0);

        [Put("/v3/ledger/customer/{customerInternalId}")]
        Task<Customer> UpdateCustomer(string customerInternalId, UpdateCustomer customer);

        [Put("/v3/ledger/customer/{customerInternalId}/activate")]
        Task ActivateCustomer(string customerInternalId);

        [Put("/v3/ledger/customer/{customerInternalId}/deactivate")]
        Task DeactivateCustomer(string customerInternalId);

        [Put("/v3/ledger/customer/{customerInternalId}/enable")]
        Task EnableCustomer(string customerInternalId);

        [Put("/v3/ledger/customer/{customerInternalId}/disable")]
        Task DisableCustomer(string customerInternalId);

        //Ledger OrderBook

        [Get("/v3/trade/history?pageSize={pageSize}&offset={offset}")]
        Task<List<OrderBook>> GetHistoricalTrades(int pageSize = 50, int offset = 0);

        [Get("/v3/trade/buy?id={accountId}&pageSize={pageSize}&offset={offset}")]
        Task<List<OrderBook>> GetActiveBuyTrades(string accountId, int pageSize = 50, int offset = 0);

        [Get("/v3/trade/sell?id={accountId}&pageSize={pageSize}&offset={offset}")]
        Task<List<OrderBook>> GetActiveSellTrades(string accountId, int pageSize = 50, int offset = 0);

        [Post("/v3/trade")]
        Task<string> StoreTrade(OrderBookRequest data);

        [Get("/v3/trade/{tradeId}")]
        Task<OrderBook> GetTrade(string tradeId);

        [Delete("/v3/trade/{tradeId}")]
        Task DeleteTrade(string tradeId);

        [Delete("/v3/trade/account/{accountId}")]
        Task DeleteAccountTrades(string accountId);

        //Ledger Subscription

        [Post("/v3/subscription")]
        Task<string> CreateSubscription(CreateSubscription subscription);

        [Get("/v3/subscription?pageSize={pageSize}&offset={offset}")]
        Task<List<Subscription>> GetActiveSubscriptions(int pageSize = 50, int offset = 0);

        [Delete("/v3/subscription/{subscriptionId}")]
        Task CancelExistingSubscription(string subscriptionId);

        [Get("/v3/subscription/report/{subscriptionId}")]
        Task<object> ObtainReport(string subscriptionId);

        //Ledger Transaction

        [Get("/v3/ledger/transaction/reference/{reference}")]
        Task<List<Transaction>> GetTransactions(string reference);

        [Post("/v3/ledger/transaction")]
        Task<string> StoreTransaction(CreateTransaction transaction);

        [Post("/v3/ledger/transaction/account?pageSize={pageSize}&offset={offset}")]
        Task<List<Transaction>> GetTransactionsForAccount(TransactionFilter filter, int pageSize = 50, int offset = 0);

        [Post("/v3/ledger/transaction/customer?pageSize={pageSize}&offset={offset}")]
        Task<List<Transaction>> GetTransactionsForCustomer(TransactionFilter filter, int pageSize = 50, int offset = 0);

        [Post("/v3/ledger/transaction/ledger?pageSize={pageSize}&offset={offset}")]
        Task<List<Transaction>> GetTransactionsForLedger(TransactionFilter filter, int pageSize = 50, int offset = 0);

        [Post("/v3/ledger/transaction/account?count=true")]
        Task<int> CountTransactionsForAccount(TransactionFilter filter);

        [Post("/v3/ledger/transaction/customer?count=true")]
        Task<int> CountTransactionsForCustomer(TransactionFilter filter);

        [Post("/v3/ledger/transaction/ledger?count=true")]
        Task<int> CountTransactionsForLedger(TransactionFilter filter);

        //Ledger Virtual Currency

        [Get("/v3/ledger/virtualCurrency/{virtualCurrencyName}")]
        Task<VirtualCurrency> GetVirtualCurrency(string virtualCurrencyName);

        [Post("/v3/ledger/virtualCurrency")]
        Task<Account> CreateVirtualCurrency(CreateVirtualCurrency currency);

        [Put("/v3/ledger/virtualCurrency")]
        Task UpdateVirtualCurrency(UpdateVirtualCurrency currency);

        [Put("/v3/ledger/virtualCurrency/mint")]
        Task<string> MintVirtualCurrency(CurrencyOperation operation);

        [Put("/v3/ledger/virtualCurrency/revoke")]
        Task<string> RevokeVirtualCurrency(CurrencyOperation operation);

        //Security

        [Get("/v3/security/address/{address}")]
        Task<string> CheckMaliciousAddress(string address);

        [Get("/v3/kms/{transactionId}")]
        Task<TransactionKms> GetTransactionKms(string transactionId);

        [Delete("/v3/kms/{transactionId}?revert={revert}")]
        Task DeleteTransactionKms(string transactionId, bool revert = true);

        [Put("/v3/kms/{transactionId}/{txId}")]
        Task CompletePendingTransactionKms(string transactionId, string txId);

        [Get("/v3/kms/pending/{blockchain}")]
        Task<List<TransactionKms>> GetPendingTransactionsKms(string blockchain);
        

    }
}

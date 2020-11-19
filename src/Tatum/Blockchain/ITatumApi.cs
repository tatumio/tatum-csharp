using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

namespace Tatum.Blockchain
{
    public interface ITatumApi
    {
        //offchain

        [Post("/v3/offchain/account/{id}/address?index={index}")]
        Task<Address> GenerateDepositAddress(string id, int index);

        [Post("/v3/offchain/account/address/batch")]
        Task<List<Address>> GenerateDepositAddresses(List<GenerateAddressRequest> addresses);

        [Get("/v3/offchain/account/address/{address}/{currency}?index={index}")]
        Task<Account> CheckAddressExists(string address, string currency, string index);

        [Post("/v3/offchain/account/{id}/address/{address}")]
        Task<Address> AssignDepositAddress(string id, string address);

        [Delete("/v3/offchain/account/{id}/address/{address}")]
        Task RemoveDepositAddress(string id, string address);

        [Get("/v3/offchain/account/{id}/address")]
        Task<List<Address>> GetAddressesForAccount(string id);

        [Post("/v3/offchain/withdrawal/broadcast")]
        Task<TxHash> OffchainBroadcast(BroadcastWithdrawal data);

        [Post("/v3/offchain/withdrawal")]
        Task<WithdrawalResponse> OffchainStoreWithdrawal(CreateWithdrawal data);

        [Delete("/v3/offchain/withdrawal/{id}")]
        Task OffchainCancelWithdrawal(string id, bool revert = true);

        [Put("/v3/offchain/withdrawal/{id}/{txId}")]
        Task OffchainCompleteWithdrawal(string id, string txId);

        //ledger account

        [Get("/v3/ledger/account/{accountId}")]
        Task<Account> GetAccount(string accountId);

        [Post("/v3/ledger/account")]
        Task<Account> CreateAccount(CreateAccount createAccount);

        [Post("/v3/ledger/account/batch")]
        Task<List<Account>> CreateAccounts(List<CreateAccount> createAccounts);

        [Get("/v3/ledger/account/block/{accountId}?pageSize=${pageSize}&offset=${offset}")]
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

        [Get("/v3/ledger/account/customer/${customerId}?pageSize=${pageSize}&offset=${offset}")]
        Task<List<Account>> GetAccounts(string customerId, int pageSize = 50, int offset = 0);

        [Get("/v3/ledger/account?pageSize=${pageSize}&offset=${offset}")]
        Task<List<Account>> GetAccounts(int pageSize = 50, int offset = 0);

        [Get("/v3/ledger/account/${accountId}/balance")]
        Task<AccountBalance> GetAccountBalance(string accountId);

        //ledger customer

        [Get("/v3/ledger/customer/{customerId}")]
        Task<Customer> GetCustomer(string customerId);

        [Get("/v3/ledger/customer?pageSize=${pageSize}&offset=${offset}")]
        Task<List<Customer>> GetCustomers(int pageSize = 50, int offset = 0);

        [Put("/v3/ledger/customer/${customerInternalId}")]
        Task<Customer> UpdateCustomer(string customerInternalId, UpdateCustomer updateCustomer);

        [Put("/v3/ledger/customer/{customerInternalId}/activate")]
        Task ActivateCustomer(string customerInternalId);

        [Put("/v3/ledger/customer/{customerInternalId}/deactivate")]
        Task DeactivateCustomer(string customerInternalId);

        [Put("/v3/ledger/customer/{customerInternalId}/enable")]
        Task EnableCustomer(string customerInternalId);

        [Put("/v3/ledger/customer/{customerInternalId}/disable")]
        Task DisableCustomer(string customerInternalId);
    }
}

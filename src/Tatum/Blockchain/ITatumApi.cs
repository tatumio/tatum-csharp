using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

namespace Tatum.Blockchain
{
    public interface ITatumApi
    {
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
    }
}

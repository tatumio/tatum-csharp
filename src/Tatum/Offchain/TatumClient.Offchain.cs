using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

namespace Tatum.Clients
{
    public partial class TatumClient : ITatumClient
    {
        Task<Address> ITatumClient.AssignDepositAddress(string accountId, string address)
        {
            return tatumApi.AssignDepositAddress(accountId, address);
        }

        Task<Account> ITatumClient.CheckAddressExists(string address, string currency, string index)
        {
            return tatumApi.CheckAddressExists(address, currency, index);
        }

        Task<Address> ITatumClient.GenerateDepositAddress(string accountId, int index)
        {
            return tatumApi.GenerateDepositAddress(accountId, index);
        }

        Task<List<Address>> ITatumClient.GenerateDepositAddresses(List<GenerateAddressRequest> addresses)
        {
            foreach (GenerateAddressRequest address in addresses)
            {
                var validationContext = new ValidationContext(address);
                Validator.ValidateObject(address, validationContext, validateAllProperties: true);
            }
            return tatumApi.GenerateDepositAddresses(addresses);
        }

        Task<List<Address>> ITatumClient.GetAddresses(string accountId)
        {
            return tatumApi.GetAddresses(accountId);
        }

        Task<TxHash> ITatumClient.OffchainBroadcast(BroadcastWithdrawal withdrawal)
        {
            var validationContext = new ValidationContext(withdrawal);
            Validator.ValidateObject(withdrawal, validationContext, validateAllProperties: true);

            return tatumApi.OffchainBroadcast(withdrawal);
        }

        Task ITatumClient.OffchainCancelWithdrawal(string withdrawalId, bool revert)
        {
            return tatumApi.OffchainCancelWithdrawal(withdrawalId, revert);
        }

        Task ITatumClient.OffchainCompleteWithdrawal(string withdrawalId, string txId)
        {
            return tatumApi.OffchainCompleteWithdrawal(withdrawalId, txId);
        }

        Task<WithdrawalResponse> ITatumClient.OffchainStoreWithdrawal(CreateWithdrawal withdrawal)
        {
            var validationContext = new ValidationContext(withdrawal);
            Validator.ValidateObject(withdrawal, validationContext, validateAllProperties: true);

            return tatumApi.OffchainStoreWithdrawal(withdrawal);
        }

        Task ITatumClient.RemoveDepositAddress(string accountId, string address)
        {
            return tatumApi.RemoveDepositAddress(accountId, address);
        }
    }
}

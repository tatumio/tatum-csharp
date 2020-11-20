using System.Collections.Generic;
using System.Threading.Tasks;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

namespace Tatum.Clients
{
    public partial class TatumClient : ITatumClient
    {
        Task<Account> ITatumClient.GetAccount(string accountId)
        {
            return tatumApi.GetAccount(accountId);
        }

        Task<Account> ITatumClient.CreateAccount(CreateAccount account)
        {
            return tatumApi.CreateAccount(account);
        }

        Task<List<Account>> ITatumClient.CreateAccounts(List<CreateAccount> accounts)
        {
            return tatumApi.CreateAccounts(accounts);
        }

        Task<List<Blockage>> ITatumClient.GetBlockedAmounts(string accountId, int pageSize, int offset)
        {
            return tatumApi.GetBlockedAmounts(accountId, pageSize, offset);
        }

        Task<string> ITatumClient.BlockAmount(string accountId, BlockAmount blockAmount)
        {
            return tatumApi.BlockAmount(accountId, blockAmount);
        }

        Task ITatumClient.UnblockBlockedAmount(string blockageId)
        {
            return tatumApi.UnblockBlockedAmount(blockageId);
        }

        Task ITatumClient.UnblockAllBlockedAmounts(string accountId)
        {
            return tatumApi.UnblockAllBlockedAmounts(accountId);
        }

        Task ITatumClient.ActivateAccount(string accountId)
        {
            return tatumApi.ActivateAccount(accountId);
        }

        Task ITatumClient.DeactivateAccount(string accountId)
        {
            return tatumApi.DeactivateAccount(accountId);
        }

        Task ITatumClient.FreezeAccount(string accountId)
        {
            return tatumApi.FreezeAccount(accountId);
        }

        Task ITatumClient.UnfreezeAccount(string accountId)
        {
            return tatumApi.UnfreezeAccount(accountId);
        }

        Task<List<Account>> ITatumClient.GetAccounts(string customerId, int pageSize, int offset)
        {
            return tatumApi.GetAccounts(customerId, pageSize, offset);
        }

        Task<List<Account>> ITatumClient.GetAccounts(int pageSize, int offset)
        {
            return tatumApi.GetAccounts(pageSize, offset);
        }

        Task<AccountBalance> ITatumClient.GetAccountBalance(string accountId)
        {
            return tatumApi.GetAccountBalance(accountId);
        }
    }
}

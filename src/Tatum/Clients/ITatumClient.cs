using System;
using System.Collections.Generic;
using System.Text;
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
    }
}

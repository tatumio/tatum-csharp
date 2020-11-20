using System.Collections.Generic;
using System.Threading.Tasks;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

namespace Tatum.Clients
{
    public partial class TatumClient : ITatumClient
    {
        Task<List<Transaction>> ITatumClient.GetTransactions(string reference)
        {
            return tatumApi.GetTransactions(reference);
        }

        Task<string> ITatumClient.StoreTransaction(CreateTransaction transaction)
        {
            return tatumApi.StoreTransaction(transaction);
        }

        Task<List<Transaction>> ITatumClient.GetTransactionsForAccount(TransactionFilter filter, int pageSize, int offset)
        {
            return tatumApi.GetTransactionsForAccount(filter, pageSize, offset);
        }

        Task<List<Transaction>> ITatumClient.GetTransactionsForCustomer(TransactionFilter filter, int pageSize, int offset)
        {
            return tatumApi.GetTransactionsForCustomer(filter, pageSize, offset);
        }

        Task<List<Transaction>> ITatumClient.GetTransactionsForLedger(TransactionFilter filter, int pageSize, int offset)
        {
            return tatumApi.GetTransactionsForLedger(filter, pageSize, offset);
        }

        Task<int> ITatumClient.CountTransactionsForAccount(TransactionFilter filter)
        {
            return tatumApi.CountTransactionsForAccount(filter);
        }

        Task<int> ITatumClient.CountTransactionsForCustomer(TransactionFilter filter)
        {
            return tatumApi.CountTransactionsForCustomer(filter);
        }
        Task<int> ITatumClient.CountTransactionsForLedger(TransactionFilter filter)
        {
            return tatumApi.CountTransactionsForLedger(filter);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tatum.Model.Responses;

namespace Tatum.Clients
{
    public partial class TatumClient : ITatumClient
    {
        Task<string> ITatumClient.CheckMaliciousAddress(string address)
        {
            return tatumApi.CheckMaliciousAddress(address);
        }

        Task<TransactionKms> ITatumClient.GetTransactionKms(string transactionId)
        {
            return tatumApi.GetTransactionKms(transactionId);
        }

        Task ITatumClient.DeleteTransactionKms(string transactionId, bool revert)
        {
            return tatumApi.DeleteTransactionKms(transactionId, revert);
        }

        Task ITatumClient.CompletePendingTransactionKms(string transactionId, string txId)
        {
            return tatumApi.CompletePendingTransactionKms(transactionId, txId);
        }

        Task<List<TransactionKms>> ITatumClient.GetPendingTransactionsKms(string blockchain)
        {
            return tatumApi.GetPendingTransactionsKms(blockchain);
        }

    }
}

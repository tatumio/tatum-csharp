using System.Collections.Generic;
using System.Threading.Tasks;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

namespace Tatum.Clients
{
    public interface IXlmClient
    {
        Task<XlmAccountInfo> GetAccountInfo(string accountAddress);
        Task<TransactionHash> Broadcast(BroadcastRequest request);
        Task<XlmInfo> GetBlockchainInfo();
        Task<long> GetFee();
        Task<List<XlmTx>> GetLedger(string sequence);
        Task<XlmTx> GetLedgerTransaction(string sequence);
        Task<XlmTx> GetTransaction(string hash);
        Task<List<XlmTx>> GetAccountTransactions(string address);
    }
}

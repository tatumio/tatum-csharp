using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

namespace Tatum.Blockchain
{
    public interface IXlmApi
    {
        [Get("/v3/xlm/account/{accountAddress}")]
        Task<XlmAccountInfo> GetAccountInfo(string accountAddress);

        [Post("/v3/xlm/broadcast")]
        Task<TransactionHash> Broadcast(BroadcastRequest request);

        [Get("/v3/xlm/info")]
        Task<XlmInfo> GetBlockchainInfo();

        [Get("/v3/xlm/fee")]
        Task<long> GetFee();

        [Get("/v3/xlm/ledger/{sequence}")]
        Task<List<XlmTx>> GetLedger(string sequence);

        [Get("/v3/xlm/ledger/{sequence}/transaction")]
        Task<XlmTx> GetLedgerTransaction(string sequence);

        [Get("/v3/xlm/ledger/transaction/{hash}")]
        Task<XlmTx> GetTransaction(string hash);

        [Get("/v3/xlm/account/tx/{address}")]
        Task<List<XlmTx>> GetAccountTransactions(string address);
    }
}

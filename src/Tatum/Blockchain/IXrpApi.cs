using Refit;
using System.Threading.Tasks;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

namespace Tatum.Blockchain
{
    public interface IXrpApi
    {
        [Get("/v3/xrp/account/{accountAddress}")]
        Task<XrpAccountInfo> GetAccountInfo(string accountAddress);

        [Post("/v3/xrp/broadcast")]
        Task<TransactionHash> Broadcast(BroadcastRequest request);

        [Get("/v3/xrp/info")]
        Task<XrpInfo> GetBlockchainInfo();

        [Get("/v3/xrp/fee")]
        Task<XrpFee> GetFee();

        [Get("/v3/xrp/ledger/{sequence}")]
        Task<XrpLedgerRoot> GetLedger(uint sequence);

        [Get("/v3/xrp/account/{accountAddress}/balance")]
        Task<XrpAccountBalance> GetAccountBalance(string accountAddress);

        [Get("/v3/xrp/transaction/{hash}")]
        Task<XrpTx> GetTransaction(string hash);

        [Get("/v3/xrp/account/tx/{address}?min={min}&marker={marker}")]
        Task<XrpAccountTransactionsRoot> GetAccountTransactions(string address, uint min = 0, string marker = null);
    }
}

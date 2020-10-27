using Refit;
using System.Threading.Tasks;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

namespace Tatum.Blockchain
{
    public interface IBitcoinApi
    {
        [Post("/v3/bitcoin/broadcast")]
        Task<TransactionHash> BroadcastSignedTransaction(BroadcastRequest request);

        [Get("/v3/bitcoin/info")]
        Task<BitcoinInfo> GetBlockchainInfo();

        [Get("/v3/bitcoin/block/{hash}")]
        Task<> GetBlock(string hash);

    }
}

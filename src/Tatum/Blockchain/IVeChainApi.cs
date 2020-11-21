using Refit;
using System.Threading.Tasks;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

namespace Tatum.Blockchain
{
    public interface IVeChainApi
    {
        [Post("/v3/vet/broadcast")]
        Task<TransactionHash> Broadcast(BroadcastRequest request);

        [Post("/v3/vet/transaction/gas")]
        Task<long> EstimateGas(EstimateGasRequest request);

        [Get("/v3/vet/block/current")]
        Task<long> GetCurrentBlock();

        [Get("/v3/vet/block/{hash}")]
        Task<VeChainBlock> GetBlock(string hash);

        [Get("/v3/vet/account/balance/{address}")]
        Task<VeChainAccountBalance> GetAccountBalance(string address);

        [Get("/v3/vet/account/energy/{address}")]
        Task<VeChainAccountEnergy> GetAccountEnergy(string address);

        [Get("/v3/vet/transaction/{hash}")]
        Task<VeChainTx> GetTransaction(string hash);

        [Get("/v3/vet/transaction/{hash}/receipt")]
        Task<VeChainTxReceipt> GetTransactionReceipt(string hash);
    }
}

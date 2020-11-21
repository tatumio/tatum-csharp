using System.Threading.Tasks;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

namespace Tatum.Clients
{
    public interface IVeChainClient
    {
        Task<TransactionHash> Broadcast(BroadcastRequest request);
        Task<long> EstimateGas(EstimateGasRequest request);
        Task<long> GetCurrentBlock();
        Task<VeChainBlock> GetBlock(string hash);
        Task<VeChainAccountBalance> GetAccountBalance(string address);
        Task<VeChainAccountEnergy> GetAccountEnergy(string address);
        Task<VeChainTx> GetTransaction(string hash);
        Task<VeChainTxReceipt> GetTransactionReceipt(string hash);
    }
}

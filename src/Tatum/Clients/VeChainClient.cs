using System.Threading.Tasks;
using Tatum.Blockchain;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

namespace Tatum.Clients
{
    public class VeChainClient : IVeChainClient
    {
        private readonly IVeChainApi veChainApi;

        public VeChainClient(string apiBaseUrl, string xApiKey)
        {
            veChainApi = RestClientFactory.Create<IVeChainApi>(apiBaseUrl, xApiKey);
        }

        Task<TransactionHash> IVeChainClient.Broadcast(BroadcastRequest request)
        {
            return veChainApi.Broadcast(request);
        }

        Task<long> IVeChainClient.EstimateGas(EstimateGasRequest request)
        {
            return veChainApi.EstimateGas(request);
        }

        Task<VeChainAccountBalance> IVeChainClient.GetAccountBalance(string address)
        {
            return veChainApi.GetAccountBalance(address);
        }

        Task<VeChainAccountEnergy> IVeChainClient.GetAccountEnergy(string address)
        {
            return veChainApi.GetAccountEnergy(address);
        }

        Task<VeChainBlock> IVeChainClient.GetBlock(string hash)
        {
            return veChainApi.GetBlock(hash);
        }

        Task<long> IVeChainClient.GetCurrentBlock()
        {
            return veChainApi.GetCurrentBlock();
        }

        Task<VeChainTx> IVeChainClient.GetTransaction(string hash)
        {
            return veChainApi.GetTransaction(hash);
        }

        Task<VeChainTxReceipt> IVeChainClient.GetTransactionReceipt(string hash)
        {
            return veChainApi.GetTransactionReceipt(hash);
        }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Tatum.Blockchain;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

namespace Tatum.Clients
{
    /// <inheritdoc/>
    public partial class EthereumClient : IEthereumClient
    {
        private readonly IEthereumApi ethereumApi;
        private readonly IEthereumGasApi ethereumGasApi;
        private readonly string tatumWeb3DriverUrl;

        internal EthereumClient()
        {
        }

        internal EthereumClient(string apiBaseUrl, string xApiKey)
        {
            ethereumApi = RestClientFactory.Create<IEthereumApi>(apiBaseUrl, xApiKey);
            ethereumGasApi = RestClientFactory.Create<IEthereumGasApi>("https://ethgasstation.info/");
            tatumWeb3DriverUrl = $"{apiBaseUrl}/v3/ethereum/web3/{xApiKey}";
        }

        public static IEthereumClient Create(string apiBaseUrl, string xApiKey)
        {
            return new EthereumClient(apiBaseUrl, xApiKey);
        }

        Task<TransactionHash> IEthereumClient.BroadcastSignedTransaction(BroadcastRequest request)
        {
            var validationContext = new ValidationContext(request);
            Validator.ValidateObject(request, validationContext, validateAllProperties: true);

            return ethereumApi.BroadcastSignedTransaction(request);
        }

        Task<EthereumAccountBalance> IEthereumClient.GetAccountBalance(string address)
        {
            return ethereumApi.GetAccountBalance(address);
        }

        Task<List<EthereumTx>> IEthereumClient.GetAccountTransactions(string address, int pageSize, int offset)
        {
            return ethereumApi.GetAccountTransactions(address, pageSize, offset);
        }

        Task<EthereumBlock> IEthereumClient.GetBlock(string hash)
        {
            return ethereumApi.GetBlock(hash);
        }

        Task<long> IEthereumClient.GetCurrentBlock()
        {
            return ethereumApi.GetCurrentBlock();
        }

        Task<EthereumAccountBalance> IEthereumClient.GetErc20AccountBalance(string address, string currency, string contractAddress)
        {
            return ethereumApi.GetErc20AccountBalance(address, currency, contractAddress);
        }

        Task<EthereumTx> IEthereumClient.GetTransaction(string hash)
        {
            return ethereumApi.GetTransaction(hash);
        }

        Task<int> IEthereumClient.GetTransactionsCount(string address)
        {
            return ethereumApi.GetTransactionsCount(address);
        }
    }
}

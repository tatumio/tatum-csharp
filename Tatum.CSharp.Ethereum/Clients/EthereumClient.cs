using System.Net.Http;
using Tatum.CSharp.Core.Api;
using Tatum.CSharp.Evm.Local;

namespace Tatum.CSharp.Ethereum.Clients
{
    public class EthereumClient : IEthereumClient
    {
        /// <inheritdoc />
        public IEthereumApiAsync EthereumBlockchain { get; }
        
        /// <inheritdoc />
        public IEthereumApiWithHttpInfoAsync EthereumBlockchainWithHttpInfo { get; }
        
        /// <inheritdoc />
        public IEvmLocalService Local { get; }

        /// <summary>
        /// Creates an instance of <see cref="EthereumClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="apiKey">Api key that will be used when calling Tatum API.</param>
        /// <param name="isTestNet">Value indicating weather Local services should generate values for Testnet.</param>
        public EthereumClient(HttpClient httpClient, string apiKey, bool isTestNet)
        {
            var ethereumApi = new EthereumApi(httpClient);
            
            ethereumApi.Configuration.ApiKey.Add("x-api-key", apiKey);
            
            EthereumBlockchain = ethereumApi;
            EthereumBlockchainWithHttpInfo = ethereumApi;

            Local = new EvmLocalService(isTestNet);
        }
        
        /// <summary>
        /// Creates an instance of <see cref="EthereumClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="apiKey">Api key that will be used when calling Tatum API.</param>
        public EthereumClient(HttpClient httpClient, string apiKey)
        {
            var ethereumApi = new EthereumApi(httpClient);
            
            ethereumApi.Configuration.ApiKey.Add("x-api-key", apiKey);
            
            EthereumBlockchain = ethereumApi;
            EthereumBlockchainWithHttpInfo = ethereumApi;

            Local = new EvmLocalService(false);
        }
    }
}
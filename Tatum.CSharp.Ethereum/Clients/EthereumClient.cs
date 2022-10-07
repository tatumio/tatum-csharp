using System.Net.Http;
using Tatum.CSharp.Core.Api;
using Tatum.CSharp.Ethereum.LocalServices;

namespace Tatum.CSharp.Ethereum.Clients
{
    public class EthereumClient : IEthereumClient
    {
        /// <inheritdoc />
        public IEthereumApiAsync EthereumBlockchain { get; }
        
        /// <inheritdoc />
        public IEthereumApiWithHttpInfoAsync EthereumBlockchainWithHttpInfo { get; }
        
        /// <inheritdoc />
        public EthereumLocalService Local { get; }

        public EthereumClient(HttpClient httpClient, string apiKey, bool isTestNet)
        {
            var ethereumApi = new EthereumApi(httpClient);
            
            ethereumApi.Configuration.ApiKey.Add("x-api-key", apiKey);
            
            EthereumBlockchain = ethereumApi;
            EthereumBlockchainWithHttpInfo = ethereumApi;

            Local = new EthereumLocalService(isTestNet);
        }
        
        public EthereumClient(HttpClient httpClient, string apiKey)
        {
            var ethereumApi = new EthereumApi(httpClient);
            
            ethereumApi.Configuration.ApiKey.Add("x-api-key", apiKey);
            
            EthereumBlockchain = ethereumApi;
            EthereumBlockchainWithHttpInfo = ethereumApi;

            Local = new EthereumLocalService(false);
        }
    }
}
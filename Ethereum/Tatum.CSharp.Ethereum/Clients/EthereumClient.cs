using System;
using System.Net.Http;
using Tatum.CSharp.Ethereum.Configuration;
using Tatum.CSharp.Ethereum.Core.Api;
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
        public INFTEthApiAsync EthereumNft { get; }
        
        /// <inheritdoc />
        public INFTEthApiWithHttpInfoAsync EthereumNftWithHttpInfo { get; }
        
        /// <inheritdoc />
        public IFungibleTokensEthApiAsync EthereumFungibleTokens { get; }
        
        /// <inheritdoc />
        public IFungibleTokensEthApiWithHttpInfoAsync EthereumFungibleTokensWithHttpInfo { get; }

        /// <inheritdoc />
        public IEvmLocalService Local { get; }
        
        /// <summary>
        /// Creates an instance of <see cref="EthereumClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="optionsFunc">Configuration options func.</param>
        public EthereumClient(HttpClient httpClient, Func<EthereumClientOptions, EthereumClientOptions> optionsFunc) 
            : this(httpClient, optionsFunc(new EthereumClientOptions()))
        {
        }
        
        /// <summary>
        /// Creates an instance of <see cref="EthereumClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="options">Configuration options.</param>
        public EthereumClient(HttpClient httpClient, EthereumClientOptions options) 
            : this(httpClient, options.ApiKey, options.IsTestnet)
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="EthereumClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="apiKey">Api key that will be used when calling Tatum API.</param>
        public EthereumClient(HttpClient httpClient, string apiKey) 
            : this(httpClient, apiKey, false)
        {
        }

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
            
            var ethereumNftApi = new NFTEthApi(httpClient);
            
            ethereumNftApi.Configuration.ApiKey.Add("x-api-key", apiKey);
            
            EthereumNft = ethereumNftApi;
            EthereumNftWithHttpInfo = ethereumNftApi;
            
            var ethereumFungibleTokensApi = new FungibleTokensEthApi(httpClient);
            
            ethereumFungibleTokensApi.Configuration.ApiKey.Add("x-api-key", apiKey);
            
            EthereumFungibleTokens = ethereumFungibleTokensApi;
            EthereumFungibleTokensWithHttpInfo = ethereumFungibleTokensApi;

            Local = new EvmLocalService(isTestNet);
        }
    }
}
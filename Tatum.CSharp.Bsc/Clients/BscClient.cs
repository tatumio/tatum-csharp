using System;
using System.Net.Http;
using Tatum.CSharp.Core.Api;
using Tatum.CSharp.Bsc.Configuration;
using Tatum.CSharp.Evm.Local;

namespace Tatum.CSharp.Bsc.Clients
{
    public class BSCClient : IBSCClient
    {
        /// <inheritdoc />
        public IBNBSmartChainApiAsync BSCBlockchain { get; }
        
        /// <inheritdoc />
        public IBNBSmartChainApiWithHttpInfoAsync BSCBlockchainWithHttpInfo { get; }

        /// <inheritdoc />
        public INFTBscApiAsync BSCNft { get; }
        
        /// <inheritdoc />
        public INFTBscApiWithHttpInfoAsync BSCNftWithHttpInfo { get; }

        /// <inheritdoc />
        public IEvmLocalService Local { get; }
        
        /// <summary>
        /// Creates an instance of <see cref="BSCClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="optionsFunc">Configuration options func.</param>
        public BSCClient(HttpClient httpClient, Func<BSCClientOptions, BSCClientOptions> optionsFunc) 
            : this(httpClient, optionsFunc(new BSCClientOptions()))
        {
        }
        
        /// <summary>
        /// Creates an instance of <see cref="BSCClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="options">Configuration options.</param>
        public BSCClient(HttpClient httpClient, BSCClientOptions options) 
            : this(httpClient, options.ApiKey, options.IsTestnet)
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="BSCClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="apiKey">Api key that will be used when calling Tatum API.</param>
        public BSCClient(HttpClient httpClient, string apiKey) 
            : this(httpClient, apiKey, false)
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="BSCClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="apiKey">Api key that will be used when calling Tatum API.</param>
        /// <param name="isTestNet">Value indicating weather Local services should generate values for Testnet.</param>
        public BSCClient(HttpClient httpClient, string apiKey, bool isTestNet)
        {
            var bscApi = new BNBSmartChainApi(httpClient);

            bscApi.Configuration.ApiKey.Add("x-api-key", apiKey);

            BSCBlockchain = bscApi;
            BSCBlockchainWithHttpInfo = bscApi;
            
            var bscNftApi = new NFTBscApi(httpClient);
            
            bscNftApi.Configuration.ApiKey.Add("x-api-key", apiKey);
            
            BSCNft = bscNftApi;
            BSCNftWithHttpInfo = bscNftApi;

            Local = new EvmLocalService(isTestNet);
        }
    }
}
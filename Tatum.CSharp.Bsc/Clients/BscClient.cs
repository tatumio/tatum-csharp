using System;
using System.Net.Http;
using Tatum.CSharp.Core.Api;
using Tatum.CSharp.Bsc.Configuration;
using Tatum.CSharp.Evm.Local;

namespace Tatum.CSharp.Bsc.Clients
{
    public class BscClient : IBscClient
    {
        /// <inheritdoc />
        public IBNBSmartChainApiAsync BscBlockchain { get; }
        
        /// <inheritdoc />
        public IBNBSmartChainApiWithHttpInfoAsync BscBlockchainWithHttpInfo { get; }

        /// <inheritdoc />
        public INFTBscApiAsync BscNft { get; }
        
        /// <inheritdoc />
        public INFTBscApiWithHttpInfoAsync BscNftWithHttpInfo { get; }

        /// <inheritdoc />
        public IEvmLocalService Local { get; }
        
        /// <summary>
        /// Creates an instance of <see cref="BscClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="optionsFunc">Configuration options func.</param>
        public BscClient(HttpClient httpClient, Func<BscClientOptions, BscClientOptions> optionsFunc) 
            : this(httpClient, optionsFunc(new BscClientOptions()))
        {
        }
        
        /// <summary>
        /// Creates an instance of <see cref="BscClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="options">Configuration options.</param>
        public BscClient(HttpClient httpClient, BscClientOptions options) 
            : this(httpClient, options.ApiKey, options.IsTestnet)
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="BscClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="apiKey">Api key that will be used when calling Tatum API.</param>
        public BscClient(HttpClient httpClient, string apiKey) 
            : this(httpClient, apiKey, false)
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="BscClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="apiKey">Api key that will be used when calling Tatum API.</param>
        /// <param name="isTestNet">Value indicating weather Local services should generate values for Testnet.</param>
        public BscClient(HttpClient httpClient, string apiKey, bool isTestNet)
        {
            var bscApi = new BNBSmartChainApi(httpClient);

            bscApi.Configuration.ApiKey.Add("x-api-key", apiKey);

            BscBlockchain = bscApi;
            BscBlockchainWithHttpInfo = bscApi;
            
            var bscNftApi = new NFTBscApi(httpClient);
            
            bscNftApi.Configuration.ApiKey.Add("x-api-key", apiKey);
            
            BscNft = bscNftApi;
            BscNftWithHttpInfo = bscNftApi;

            Local = new EvmLocalService(isTestNet);
        }
    }
}
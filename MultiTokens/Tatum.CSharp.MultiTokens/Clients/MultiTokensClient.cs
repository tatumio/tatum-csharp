using System;
using System.Net.Http;
using Tatum.CSharp.Evm.Local;
using Tatum.CSharp.MultiTokens.Configuration;
using Tatum.CSharp.MultiTokens.Core.Api;

namespace Tatum.CSharp.MultiTokens.Clients
{
    public class MultiTokensClient : IMultiTokensClient
    {
        /// <inheritdoc />
        public IMultiTokensEthApiAsync EthereumMultiTokens { get; }
        
        /// <inheritdoc />
        public IMultiTokensEthApiWithHttpInfoAsync EthereumMultiTokensWithHttpInfo { get; }
        
        /// <inheritdoc />
        public IMultiTokensMaticApiAsync PolygonMultiTokens { get; }
        
        /// <inheritdoc />
        public IMultiTokensMaticApiWithHttpInfoAsync PolygonMultiTokensWithHttpInfo { get; }
        
        /// <inheritdoc />
        public IMultiTokensBscApiAsync BscMultiTokens { get; }
        
        /// <inheritdoc />
        public IMultiTokensBscApiWithHttpInfoAsync BscMultiTokensWithHttpInfo { get; }
        
        /// <inheritdoc />
        public IMultiTokensOneApiAsync HarmonyMultiTokens { get; }
        
        /// <inheritdoc />
        public IMultiTokensOneApiWithHttpInfoAsync HarmonyMultiTokensWithHttpInfo { get; }

        /// <inheritdoc />
        public IEvmLocalService Local { get; }
        
        /// <summary>
        /// Creates an instance of <see cref="MultiTokensClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="optionsFunc">Configuration options func.</param>
        public MultiTokensClient(HttpClient httpClient, Func<MultiTokensClientOptions, MultiTokensClientOptions> optionsFunc) 
            : this(httpClient, optionsFunc(new MultiTokensClientOptions()))
        {
        }
        
        /// <summary>
        /// Creates an instance of <see cref="MultiTokensClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="options">Configuration options.</param>
        public MultiTokensClient(HttpClient httpClient, MultiTokensClientOptions options) 
            : this(httpClient, options.ApiKey, options.IsTestnet)
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="MultiTokensClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="apiKey">Api key that will be used when calling Tatum API.</param>
        public MultiTokensClient(HttpClient httpClient, string apiKey) 
            : this(httpClient, apiKey, false)
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="MultiTokensClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="apiKey">Api key that will be used when calling Tatum API.</param>
        /// <param name="isTestNet">Value indicating weather Local services should generate values for Testnet.</param>
        public MultiTokensClient(HttpClient httpClient, string apiKey, bool isTestNet)
        {
            var ethereumMultiTokensApi = new MultiTokensEthApi(httpClient);
            
            ethereumMultiTokensApi.Configuration.ApiKey.Add("x-api-key", apiKey);
            
            EthereumMultiTokens = ethereumMultiTokensApi;
            EthereumMultiTokensWithHttpInfo = ethereumMultiTokensApi;
            
            var polygonMultiTokensApi = new MultiTokensMaticApi(httpClient);
            
            polygonMultiTokensApi.Configuration.ApiKey.Add("x-api-key", apiKey);
            
            PolygonMultiTokens = polygonMultiTokensApi;
            PolygonMultiTokensWithHttpInfo = polygonMultiTokensApi;
            
            var bscMultiTokensApi = new MultiTokensBscApi(httpClient);
            
            bscMultiTokensApi.Configuration.ApiKey.Add("x-api-key", apiKey);
            
            BscMultiTokens = bscMultiTokensApi;
            BscMultiTokensWithHttpInfo = bscMultiTokensApi;
            
            var oneMultiTokensApi = new MultiTokensOneApi(httpClient);
            
            oneMultiTokensApi.Configuration.ApiKey.Add("x-api-key", apiKey);
            
            HarmonyMultiTokens = oneMultiTokensApi;
            HarmonyMultiTokensWithHttpInfo = oneMultiTokensApi;

            Local = new EvmLocalService(isTestNet);
        }
    }
}
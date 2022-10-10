using System;
using System.Net.Http;
using Tatum.CSharp.Bitcoin.Configuration;

namespace Tatum.CSharp.Bitcoin.Clients
{
    public class BitcoinClient : IBitcoinClient
    {
        /// <inheritdoc />
        public IBitcoinApiAsync EthereumBlockchain { get; }
        
        /// <inheritdoc />
        public IBitcoinApiWithHttpInfoAsync EthereumBlockchainWithHttpInfo { get; }
        
        /// <inheritdoc />
        public IBitcoinLocalService Local { get; }
        
        /// <summary>
        /// Creates an instance of <see cref="BitcoinClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="optionsFunc">Configuration options func.</param>
        public BitcoinClient(HttpClient httpClient, Func<BitcoinClientOptions, BitcoinClientOptions> optionsFunc)
        {
            var ethereumApi = new BitcoinApi(httpClient);

            var options = new BitcoinClientOptions();

            optionsFunc(options);
            
            ethereumApi.Configuration.ApiKey.Add("x-api-key", options.ApiKey);
            
            EthereumBlockchain = ethereumApi;
            EthereumBlockchainWithHttpInfo = ethereumApi;

            Local = new BitcoinLocalService(options.IsTestnet);
        }
        
        /// <summary>
        /// Creates an instance of <see cref="BitcoinClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="options">Configuration options.</param>
        public BitcoinClient(HttpClient httpClient, BitcoinClientOptions options)
        {
            var ethereumApi = new BitcoinApi(httpClient);
            
            ethereumApi.Configuration.ApiKey.Add("x-api-key", options.ApiKey);
            
            EthereumBlockchain = ethereumApi;
            EthereumBlockchainWithHttpInfo = ethereumApi;

            Local = new BitcoinLocalService(options.IsTestnet);
        }
        
        /// <summary>
        /// Creates an instance of <see cref="BitcoinClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="apiKey">Api key that will be used when calling Tatum API.</param>
        /// <param name="isTestNet">Value indicating weather Local services should generate values for Testnet.</param>
        public BitcoinClient(HttpClient httpClient, string apiKey, bool isTestNet)
        {
            var ethereumApi = new BitcoinApi(httpClient);
            
            ethereumApi.Configuration.ApiKey.Add("x-api-key", apiKey);
            
            EthereumBlockchain = ethereumApi;
            EthereumBlockchainWithHttpInfo = ethereumApi;

            Local = new BitcoinLocalService(isTestNet);
        }
        
        /// <summary>
        /// Creates an instance of <see cref="BitcoinClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="apiKey">Api key that will be used when calling Tatum API.</param>
        public BitcoinClient(HttpClient httpClient, string apiKey)
        {
            var ethereumApi = new BitcoinApi(httpClient);
            
            ethereumApi.Configuration.ApiKey.Add("x-api-key", apiKey);
            
            EthereumBlockchain = ethereumApi;
            EthereumBlockchainWithHttpInfo = ethereumApi;

            Local = new BitcoinLocalService(false);
        }
    }
}
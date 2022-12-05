using System;
using System.Net.Http;
using Tatum.CSharp.Bitcoin.Configuration;
using Tatum.CSharp.Bitcoin.Core.Api;
using Tatum.CSharp.Bitcoin.Local;

namespace Tatum.CSharp.Bitcoin.Clients
{
    public class BitcoinClient : IBitcoinClient
    {
        /// <inheritdoc />
        public IBitcoinApiAsync BitcoinBlockchain { get; }
        
        /// <inheritdoc />
        public IBitcoinApiWithHttpInfoAsync BitcoinBlockchainWithHttpInfo { get; }
        
        /// <inheritdoc />
        public IBitcoinLocalService Local { get; }
        
        /// <summary>
        /// Creates an instance of <see cref="BitcoinClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="optionsFunc">Configuration options func.</param>
        public BitcoinClient(HttpClient httpClient, Func<BitcoinClientOptions, BitcoinClientOptions> optionsFunc) 
            : this(httpClient, optionsFunc(new BitcoinClientOptions()))
        {
        }
        
        /// <summary>
        /// Creates an instance of <see cref="BitcoinClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="options">Configuration options.</param>
        public BitcoinClient(HttpClient httpClient, BitcoinClientOptions options) 
            : this(httpClient, options.ApiKey, options.IsTestnet)
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="BitcoinClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="apiKey">Api key that will be used when calling Tatum API.</param>
        public BitcoinClient(HttpClient httpClient, string apiKey) 
            : this(httpClient, apiKey, false)
        {
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
            
            BitcoinBlockchain = ethereumApi;
            BitcoinBlockchainWithHttpInfo = ethereumApi;

            Local = new BitcoinLocalService(isTestNet);
        }
    }
}
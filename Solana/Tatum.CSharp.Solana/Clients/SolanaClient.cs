using System;
using System.Net.Http;
using Tatum.CSharp.Solana.Configuration;
using Tatum.CSharp.Solana.Core.Api;

namespace Tatum.CSharp.Solana.Clients
{
    public class SolanaClient : ISolanaClient
    {
        /// <inheritdoc />
        public ISolanaApiAsync SolanaBlockchain { get; }
        
        /// <inheritdoc />
        public ISolanaApiWithHttpInfoAsync SolanaBlockchainWithHttpInfo { get; }

        /// <summary>
        /// Creates an instance of <see cref="SolanaClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="optionsFunc">Configuration options func.</param>
        public SolanaClient(HttpClient httpClient, Func<SolanaClientOptions, SolanaClientOptions> optionsFunc) 
            : this(httpClient, optionsFunc(new SolanaClientOptions()))
        {
        }
        
        /// <summary>
        /// Creates an instance of <see cref="SolanaClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="options">Configuration options.</param>
        public SolanaClient(HttpClient httpClient, SolanaClientOptions options) 
            : this(httpClient, options.ApiKey, options.IsTestnet)
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="SolanaClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="apiKey">Api key that will be used when calling Tatum API.</param>
        public SolanaClient(HttpClient httpClient, string apiKey) 
            : this(httpClient, apiKey, false)
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="SolanaClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="apiKey">Api key that will be used when calling Tatum API.</param>
        /// <param name="isTestNet">Value indicating weather Local services should generate values for Testnet.</param>
        public SolanaClient(HttpClient httpClient, string apiKey, bool isTestNet)
        {
            var configuration = new Core.Client.Configuration();
            configuration.ApiKey.Add("x-api-key", apiKey);
            
            var solanaApi = new SolanaApi(httpClient, configuration);

            SolanaBlockchain = solanaApi;
            SolanaBlockchainWithHttpInfo = solanaApi;
        }
    }
}
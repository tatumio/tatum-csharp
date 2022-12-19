using System;
using System.Net.Http;
using Tatum.CSharp.Evm.Local;
using Tatum.CSharp.BlockchainFees.Configuration;
using Tatum.CSharp.BlockchainFees.Core.Api;

namespace Tatum.CSharp.BlockchainFees.Clients
{
    public class BlockchainFeesClient : IBlockchainFeesClient
    {
        /// <inheritdoc />
        public IBlockchainFeesBtcApiAsync BitcoinBlockchainFees { get; }
        
        /// <inheritdoc />
        public IBlockchainFeesBtcApiWithHttpInfoAsync BitcoinBlockchainFeesWithHttpInfo { get; }

        /// <inheritdoc />
        public IBlockchainFeesEthApiAsync EthereumBlockchainFees { get; }
        
        /// <inheritdoc />
        public IBlockchainFeesEthApiWithHttpInfoAsync EthereumBlockchainFeesWithHttpInfo { get; }
        
        /// <inheritdoc />
        public IBlockchainFeesMaticApiAsync PolygonBlockchainFees { get; }
        
        /// <inheritdoc />
        public IBlockchainFeesMaticApiWithHttpInfoAsync PolygonBlockchainFeesWithHttpInfo { get; }
        
        /// <inheritdoc />
        public IBlockchainFeesBscApiAsync BscBlockchainFees { get; }
        
        /// <inheritdoc />
        public IBlockchainFeesBscApiWithHttpInfoAsync BscBlockchainFeesWithHttpInfo { get; }
        
        /// <inheritdoc />
        public IBlockchainFeesOneApiAsync HarmonyBlockchainFees { get; }
        
        /// <inheritdoc />
        public IBlockchainFeesOneApiWithHttpInfoAsync HarmonyBlockchainFeesWithHttpInfo { get; }

        /// <inheritdoc />
        public IEvmLocalService Local { get; }
        
        /// <summary>
        /// Creates an instance of <see cref="BlockchainFeesClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="optionsFunc">Configuration options func.</param>
        public BlockchainFeesClient(HttpClient httpClient, Func<BlockchainFeesClientOptions, BlockchainFeesClientOptions> optionsFunc) 
            : this(httpClient, optionsFunc(new BlockchainFeesClientOptions()))
        {
        }
        
        /// <summary>
        /// Creates an instance of <see cref="BlockchainFeesClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="options">Configuration options.</param>
        public BlockchainFeesClient(HttpClient httpClient, BlockchainFeesClientOptions options) 
            : this(httpClient, options.ApiKey, options.IsTestnet)
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="BlockchainFeesClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="apiKey">Api key that will be used when calling Tatum API.</param>
        public BlockchainFeesClient(HttpClient httpClient, string apiKey) 
            : this(httpClient, apiKey, false)
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="BlockchainFeesClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="apiKey">Api key that will be used when calling Tatum API.</param>
        /// <param name="isTestNet">Value indicating weather Local services should generate values for Testnet.</param>
        public BlockchainFeesClient(HttpClient httpClient, string apiKey, bool isTestNet)
        {
            var ethereumBlockchainFeesApi = new BlockchainFeesEthApi(httpClient);
            
            ethereumBlockchainFeesApi.Configuration.ApiKey.Add("x-api-key", apiKey);
            
            EthereumBlockchainFees = ethereumBlockchainFeesApi;
            EthereumBlockchainFeesWithHttpInfo = ethereumBlockchainFeesApi;
            
            var polygonBlockchainFeesApi = new BlockchainFeesMaticApi(httpClient);
            
            polygonBlockchainFeesApi.Configuration.ApiKey.Add("x-api-key", apiKey);
            
            PolygonBlockchainFees = polygonBlockchainFeesApi;
            PolygonBlockchainFeesWithHttpInfo = polygonBlockchainFeesApi;
            
            var bscBlockchainFeesApi = new BlockchainFeesBscApi(httpClient);
            
            bscBlockchainFeesApi.Configuration.ApiKey.Add("x-api-key", apiKey);
            
            BscBlockchainFees = bscBlockchainFeesApi;
            BscBlockchainFeesWithHttpInfo = bscBlockchainFeesApi;
            
            var oneBlockchainFeesApi = new BlockchainFeesOneApi(httpClient);
            
            oneBlockchainFeesApi.Configuration.ApiKey.Add("x-api-key", apiKey);
            
            HarmonyBlockchainFees = oneBlockchainFeesApi;
            HarmonyBlockchainFeesWithHttpInfo = oneBlockchainFeesApi;
            
            var btcBlockchainFeesApi = new BlockchainFeesBtcApi(httpClient);
            
            btcBlockchainFeesApi.Configuration.ApiKey.Add("x-api-key", apiKey);
            
            BitcoinBlockchainFees = btcBlockchainFeesApi;
            BitcoinBlockchainFeesWithHttpInfo = btcBlockchainFeesApi;

            Local = new EvmLocalService(isTestNet);
        }
    }
}
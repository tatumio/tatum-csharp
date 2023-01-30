using System;
using System.Net.Http;
using Tatum.CSharp.Evm.Local;
using Tatum.CSharp.Polygon.Configuration;
using Tatum.CSharp.Polygon.Core.Api;
using Tatum.CSharp.Polygon.Core.Model;
using Tatum.CSharp.Polygon.Utils;
using Tatum.CSharp.Utils;

namespace Tatum.CSharp.Polygon.Clients
{
    public class PolygonClient : IPolygonClient
    {
        /// <inheritdoc />
        public IPolygonApiAsync PolygonBlockchain { get; }
        
        /// <inheritdoc />
        public IPolygonApiWithHttpInfoAsync PolygonBlockchainWithHttpInfo { get; }

        /// <inheritdoc />
        public INFTApiAsync PolygonNft { get; }
        
        /// <inheritdoc />
        public INFTApiWithHttpInfoAsync PolygonNftWithHttpInfo { get; }
        
        /// <inheritdoc />
        public IFungibleTokensApiAsync PolygonFungibleTokens { get; }
        
        /// <inheritdoc />
        public IFungibleTokensApiWithHttpInfoAsync PolygonFungibleTokensWithHttpInfo { get; }

        /// <inheritdoc />
        public IMultiTokensApiAsync PolygonMultiTokens { get; }
        
        /// <inheritdoc />
        public IMultiTokensApiWithHttpInfoAsync PolygonMultiTokensWithHttpInfo { get; }

        /// <inheritdoc />
        public IBlockchainFeesApiAsync BlockchainFees { get; }
        
        /// <inheritdoc />
        public IBlockchainFeesApiWithHttpInfoAsync BlockchainFeesWithHttpInfo { get; }

        /// <inheritdoc />
        public INodeRPCApiAsync PolygonNodeRpc { get; }
        
        /// <inheritdoc />
        public INodeRPCApiWithHttpInfoAsync PolygonNodeRpcWithHttpInfo { get; }
        
        /// <inheritdoc />
        public IIPFSApiAsync Ipfs { get; }
        
        /// <inheritdoc />
        public IIPFSApiWithHttpInfoAsync IpfsWithHttpInfo { get; }

        /// <inheritdoc />
        public IEvmLocalService Local { get; }

        /// <inheritdoc />
        public ITatumUtils Utils { get; }

        /// <summary>
        /// Creates an instance of <see cref="PolygonClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="optionsFunc">Configuration options func.</param>
        public PolygonClient(HttpClient httpClient, Func<PolygonClientOptions, PolygonClientOptions> optionsFunc) 
            : this(httpClient, optionsFunc(new PolygonClientOptions()))
        {
        }
        
        /// <summary>
        /// Creates an instance of <see cref="PolygonClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="options">Configuration options.</param>
        public PolygonClient(HttpClient httpClient, PolygonClientOptions options) 
            : this(httpClient, options.ApiKey, options.IsTestnet)
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="PolygonClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="apiKey">Api key that will be used when calling Tatum API.</param>
        public PolygonClient(HttpClient httpClient, string apiKey) 
            : this(httpClient, apiKey, false)
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="PolygonClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="apiKey">Api key that will be used when calling Tatum API.</param>
        /// <param name="isTestNet">Value indicating weather Local services should generate values for Testnet.</param>
        public PolygonClient(HttpClient httpClient, string apiKey, bool isTestNet)
        {
            var configuration = new Core.Client.Configuration();
            configuration.ApiKey.Add("x-api-key", apiKey);
            
            var polygonApi = new PolygonApi(httpClient, configuration);



            PolygonBlockchain = polygonApi;
            PolygonBlockchainWithHttpInfo = polygonApi;
            
            var polygonNftApi = new NFTApi(httpClient, configuration);
            

            
            PolygonNft = polygonNftApi;
            PolygonNftWithHttpInfo = polygonNftApi;
            
            var polygonFungibleTokensApi = new FungibleTokensApi(httpClient, configuration);
            

            
            PolygonFungibleTokens = polygonFungibleTokensApi;
            PolygonFungibleTokensWithHttpInfo = polygonFungibleTokensApi;
            
            var polygonMultiTokensApi = new MultiTokensApi(httpClient, configuration);
            

            
            PolygonMultiTokens = polygonMultiTokensApi;
            PolygonMultiTokensWithHttpInfo = polygonMultiTokensApi;

            var feeApi = new BlockchainFeesApi(httpClient, configuration);
            

            
            BlockchainFees = feeApi;
            BlockchainFeesWithHttpInfo = feeApi;
            
            var polygonNodeRpcApi = new NodeRPCApi(httpClient, configuration);
            

            
            PolygonNodeRpc = polygonNodeRpcApi;
            PolygonNodeRpcWithHttpInfo = polygonNodeRpcApi;
            
            var ipfsApi = new IPFSApi(httpClient, configuration);
            

            
            Ipfs = ipfsApi;
            IpfsWithHttpInfo = ipfsApi;
            
            Local = new EvmLocalService(isTestNet);
            
            Utils = new TatumUtils<PolygonTx>(new PolygonTransactionWaiter(this));
        }
    }
}
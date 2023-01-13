using System;
using System.Net.Http;
using Tatum.CSharp.Bsc.Configuration;
using Tatum.CSharp.Bsc.Core.Api;
using Tatum.CSharp.Bsc.Core.Model;
using Tatum.CSharp.Bsc.Utils;
using Tatum.CSharp.Evm.Local;
using Tatum.CSharp.Utils;

namespace Tatum.CSharp.Bsc.Clients
{
    public class BscClient : IBscClient
    {
        /// <inheritdoc />
        public IBNBSmartChainApiAsync BscBlockchain { get; }
        
        /// <inheritdoc />
        public IBNBSmartChainApiWithHttpInfoAsync BscBlockchainWithHttpInfo { get; }

        /// <inheritdoc />
        public INFTApiAsync BscNft { get; }
        
        /// <inheritdoc />
        public INFTApiWithHttpInfoAsync BscNftWithHttpInfo { get; }
        
        /// <inheritdoc />
        public IFungibleTokensApiAsync BscFungibleTokens { get; }
        
        /// <inheritdoc />
        public IFungibleTokensApiWithHttpInfoAsync BscFungibleTokensWithHttpInfo { get; }

        /// <inheritdoc />
        public IMultiTokensApiAsync BscMultiTokens { get; }
        
        /// <inheritdoc />
        public IMultiTokensApiWithHttpInfoAsync BscMultiTokensWithHttpInfo { get; }

        /// <inheritdoc />
        public IBlockchainFeesApiAsync BlockchainFees { get; }
        
        /// <inheritdoc />
        public IBlockchainFeesApiWithHttpInfoAsync BlockchainFeesWithHttpInfo { get; }

        /// <inheritdoc />
        public INodeRPCApiAsync BscNodeRpc { get; }
        
        /// <inheritdoc />
        public INodeRPCApiWithHttpInfoAsync BscNodeRpcWithHttpInfo { get; }
        
        /// <inheritdoc />
        public IIPFSApiAsync Ipfs { get; }
        
        /// <inheritdoc />
        public IIPFSApiWithHttpInfoAsync IpfsWithHttpInfo { get; }

        /// <inheritdoc />
        public IEvmLocalService Local { get; }

        /// <inheritdoc />
        public ITatumUtils Utils { get; }

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
            var configuration = new Core.Client.Configuration();
            configuration.ApiKey.Add("x-api-key", apiKey);
            
            var bscApi = new BNBSmartChainApi(httpClient, configuration);

            BscBlockchain = bscApi;
            BscBlockchainWithHttpInfo = bscApi;
            
            var bscNftApi = new NFTApi(httpClient, configuration);

            BscNft = bscNftApi;
            BscNftWithHttpInfo = bscNftApi;
            
            var bscFungibleTokensApi = new FungibleTokensApi(httpClient, configuration);
            
            BscFungibleTokens = bscFungibleTokensApi;
            BscFungibleTokensWithHttpInfo = bscFungibleTokensApi;
            
            var bscMultiTokensApi = new MultiTokensApi(httpClient, configuration);
            
            BscMultiTokens = bscMultiTokensApi;
            BscMultiTokensWithHttpInfo = bscMultiTokensApi;

            var feeApi = new BlockchainFeesApi(httpClient, configuration);
            
            BlockchainFees = feeApi;
            BlockchainFeesWithHttpInfo = feeApi;
            
            var bscNodeRpcApi = new NodeRPCApi(httpClient, configuration);
            
            BscNodeRpc = bscNodeRpcApi;
            BscNodeRpcWithHttpInfo = bscNodeRpcApi;
            
            var ipfsApi = new IPFSApi(httpClient, configuration);
            
            Ipfs = ipfsApi;
            IpfsWithHttpInfo = ipfsApi;
            
            Local = new EvmLocalService(isTestNet);
            
            Utils = new TatumUtils<BscTx>(new BscTransactionWaiter(this));
        }
    }
}
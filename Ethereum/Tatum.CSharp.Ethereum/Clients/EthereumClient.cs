using System;
using System.Net.Http;
using Tatum.CSharp.Ethereum.Configuration;
using Tatum.CSharp.Ethereum.Core.Api;
using Tatum.CSharp.Ethereum.Core.Model;
using Tatum.CSharp.Ethereum.Utils;
using Tatum.CSharp.Evm.Local;
using Tatum.CSharp.Utils;

namespace Tatum.CSharp.Ethereum.Clients
{
    public class EthereumClient : IEthereumClient
    {
        /// <inheritdoc />
        public IEthereumApiAsync EthereumBlockchain { get; }
        
        /// <inheritdoc />
        public IEthereumApiWithHttpInfoAsync EthereumBlockchainWithHttpInfo { get; }

        /// <inheritdoc />
        public INFTApiAsync EthereumNft { get; }
        
        /// <inheritdoc />
        public INFTApiWithHttpInfoAsync EthereumNftWithHttpInfo { get; }
        
        /// <inheritdoc />
        public IFungibleTokensApiAsync EthereumFungibleTokens { get; }
        
        /// <inheritdoc />
        public IFungibleTokensApiWithHttpInfoAsync EthereumFungibleTokensWithHttpInfo { get; }

        /// <inheritdoc />
        public IMultiTokensApiAsync EthereumMultiTokens { get; }
        
        /// <inheritdoc />
        public IMultiTokensApiWithHttpInfoAsync EthereumMultiTokensWithHttpInfo { get; }

        /// <inheritdoc />
        public IBlockchainFeesApiAsync BlockchainFees { get; }
        
        /// <inheritdoc />
        public IBlockchainFeesApiWithHttpInfoAsync BlockchainFeesWithHttpInfo { get; }

        /// <inheritdoc />
        public INodeRPCApiAsync EthereumNodeRpc { get; }
        
        /// <inheritdoc />
        public INodeRPCApiWithHttpInfoAsync EthereumNodeRpcWithHttpInfo { get; }

        /// <inheritdoc />
        public IIPFSApiAsync Ipfs { get; }
        
        /// <inheritdoc />
        public IIPFSApiWithHttpInfoAsync IpfsWithHttpInfo { get; }
        
        /// <inheritdoc />
        public IEvmLocalService Local { get; }
        
        /// <inheritdoc />
        public ITatumUtils Utils { get; }
        
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
            var configuration = new Core.Client.Configuration();
            configuration.ApiKey.Add("x-api-key", apiKey);
            
            var ethereumApi = new EthereumApi(httpClient, configuration);

            EthereumBlockchain = ethereumApi;
            EthereumBlockchainWithHttpInfo = ethereumApi;
            
            var ethereumNftApi = new NFTApi(httpClient, configuration);

            EthereumNft = ethereumNftApi;
            EthereumNftWithHttpInfo = ethereumNftApi;
            
            var ethereumFungibleTokensApi = new FungibleTokensApi(httpClient, configuration);

            EthereumFungibleTokens = ethereumFungibleTokensApi;
            EthereumFungibleTokensWithHttpInfo = ethereumFungibleTokensApi;
            
            var ethereumMultiTokensApi = new MultiTokensApi(httpClient, configuration);

            EthereumMultiTokens = ethereumMultiTokensApi;
            EthereumMultiTokensWithHttpInfo = ethereumMultiTokensApi;

            var feeApi = new BlockchainFeesApi(httpClient, configuration);

            BlockchainFees = feeApi;
            BlockchainFeesWithHttpInfo = feeApi;
            
            var ethereumNodeRpcApi = new NodeRPCApi(httpClient, configuration);

            EthereumNodeRpc = ethereumNodeRpcApi;
            EthereumNodeRpcWithHttpInfo = ethereumNodeRpcApi;
            
            var ipfsApi = new IPFSApi(httpClient, configuration);

            Ipfs = ipfsApi;
            IpfsWithHttpInfo = ipfsApi;
            
            Local = new EvmLocalService(isTestNet);
            
            Utils = new TatumUtils<EthTx>(new EthereumTransactionWaiter(this));
        }
    }
}
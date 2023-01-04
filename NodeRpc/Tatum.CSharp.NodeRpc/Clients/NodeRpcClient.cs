using System;
using System.Net.Http;
using Tatum.CSharp.Evm.Local;
using Tatum.CSharp.NodeRpc.Configuration;
using Tatum.CSharp.NodeRpc.Core.Api;

namespace Tatum.CSharp.NodeRpc.Clients
{
    public class NodeRpcClient : INodeRpcClient
    {
        /// <inheritdoc />
        public INodeRpcBtcApiAsync BitcoinNodeRpc { get; }
        
        /// <inheritdoc />
        public INodeRpcBtcApiWithHttpInfoAsync BitcoinNodeRpcWithHttpInfo { get; }

        /// <inheritdoc />
        public INodeRpcEthApiAsync EthereumNodeRpc { get; }
        
        /// <inheritdoc />
        public INodeRpcEthApiWithHttpInfoAsync EthereumNodeRpcWithHttpInfo { get; }
        
        /// <inheritdoc />
        public INodeRpcMaticApiAsync PolygonNodeRpc { get; }
        
        /// <inheritdoc />
        public INodeRpcMaticApiWithHttpInfoAsync PolygonNodeRpcWithHttpInfo { get; }
        
        /// <inheritdoc />
        public INodeRpcBscApiAsync BscNodeRpc { get; }
        
        /// <inheritdoc />
        public INodeRpcBscApiWithHttpInfoAsync BscNodeRpcWithHttpInfo { get; }
        
        /// <inheritdoc />
        public INodeRpcOneApiAsync HarmonyNodeRpc { get; }
        
        /// <inheritdoc />
        public INodeRpcOneApiWithHttpInfoAsync HarmonyNodeRpcWithHttpInfo { get; }

        /// <inheritdoc />
        public IEvmLocalService Local { get; }
        
        /// <summary>
        /// Creates an instance of <see cref="NodeRpcClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="optionsFunc">Configuration options func.</param>
        public NodeRpcClient(HttpClient httpClient, Func<NodeRpcClientOptions, NodeRpcClientOptions> optionsFunc) 
            : this(httpClient, optionsFunc(new NodeRpcClientOptions()))
        {
        }
        
        /// <summary>
        /// Creates an instance of <see cref="NodeRpcClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="options">Configuration options.</param>
        public NodeRpcClient(HttpClient httpClient, NodeRpcClientOptions options) 
            : this(httpClient, options.ApiKey, options.IsTestnet)
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="NodeRpcClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="apiKey">Api key that will be used when calling Tatum API.</param>
        public NodeRpcClient(HttpClient httpClient, string apiKey) 
            : this(httpClient, apiKey, false)
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="NodeRpcClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="apiKey">Api key that will be used when calling Tatum API.</param>
        /// <param name="isTestNet">Value indicating weather Local services should generate values for Testnet.</param>
        public NodeRpcClient(HttpClient httpClient, string apiKey, bool isTestNet)
        {
            var ethereumNodeRpcApi = new NodeRpcEthApi(httpClient);
            
            ethereumNodeRpcApi.Configuration.ApiKey.Add("x-api-key", apiKey);
            
            EthereumNodeRpc = ethereumNodeRpcApi;
            EthereumNodeRpcWithHttpInfo = ethereumNodeRpcApi;
            
            var polygonNodeRpcApi = new NodeRpcMaticApi(httpClient);
            
            polygonNodeRpcApi.Configuration.ApiKey.Add("x-api-key", apiKey);
            
            PolygonNodeRpc = polygonNodeRpcApi;
            PolygonNodeRpcWithHttpInfo = polygonNodeRpcApi;
            
            var bscNodeRpcApi = new NodeRpcBscApi(httpClient);
            
            bscNodeRpcApi.Configuration.ApiKey.Add("x-api-key", apiKey);
            
            BscNodeRpc = bscNodeRpcApi;
            BscNodeRpcWithHttpInfo = bscNodeRpcApi;
            
            var oneNodeRpcApi = new NodeRpcOneApi(httpClient);
            
            oneNodeRpcApi.Configuration.ApiKey.Add("x-api-key", apiKey);
            
            HarmonyNodeRpc = oneNodeRpcApi;
            HarmonyNodeRpcWithHttpInfo = oneNodeRpcApi;
            
            var btcNodeRpcApi = new NodeRpcBtcApi(httpClient);
            
            btcNodeRpcApi.Configuration.ApiKey.Add("x-api-key", apiKey);
            
            BitcoinNodeRpc = btcNodeRpcApi;
            BitcoinNodeRpcWithHttpInfo = btcNodeRpcApi;

            Local = new EvmLocalService(isTestNet);
        }
    }
}
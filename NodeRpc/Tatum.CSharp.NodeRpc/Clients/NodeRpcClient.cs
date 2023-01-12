using System;
using System.Net.Http;
using Tatum.CSharp.NodeRpc.Configuration;
using Tatum.CSharp.NodeRpc.Core.Api;

namespace Tatum.CSharp.NodeRpc.Clients
{
    public class NodeRpcClient : INodeRpcClient
    {
        /// <inheritdoc />
        public INodeRPCBtcApiAsync BitcoinNodeRpc { get; }
        /// <inheritdoc />
        public INodeRPCBtcApiWithHttpInfoAsync BitcoinNodeRpcWithHttpInfo { get; }
        /// <inheritdoc />
        public INodeRPCEthApiAsync EthereumNodeRpc { get; }
        /// <inheritdoc />
        public INodeRPCEthApiWithHttpInfoAsync EthereumNodeRpcWithHttpInfo { get; }
        /// <inheritdoc />
        public INodeRPCMaticApiAsync PolygonNodeRpc { get; }
        /// <inheritdoc />
        public INodeRPCMaticApiWithHttpInfoAsync PolygonNodeRpcWithHttpInfo { get; }
        /// <inheritdoc />
        public INodeRPCBscApiAsync BscNodeRpc { get; }
        /// <inheritdoc />
        public INodeRPCBscApiWithHttpInfoAsync BscNodeRpcWithHttpInfo { get; }
        /// <inheritdoc />
        public INodeRPCOneApiAsync HarmonyNodeRpc { get; }
        /// <inheritdoc />
        public INodeRPCOneApiWithHttpInfoAsync HarmonyNodeRpcWithHttpInfo { get; }

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
            var configuration = new Core.Client.Configuration();
            configuration.ApiKey.Add("x-api-key", apiKey);
            
            var ethereumNodeRpcApi = new NodeRPCEthApi(httpClient, configuration);
            
            EthereumNodeRpc = ethereumNodeRpcApi;
            EthereumNodeRpcWithHttpInfo = ethereumNodeRpcApi;
            
            var polygonNodeRpcApi = new NodeRPCMaticApi(httpClient, configuration);
            
            PolygonNodeRpc = polygonNodeRpcApi;
            PolygonNodeRpcWithHttpInfo = polygonNodeRpcApi;
            
            var bscNodeRpcApi = new NodeRPCBscApi(httpClient, configuration);
            
            BscNodeRpc = bscNodeRpcApi;
            BscNodeRpcWithHttpInfo = bscNodeRpcApi;
            
            var oneNodeRpcApi = new NodeRPCOneApi(httpClient, configuration);
            
            HarmonyNodeRpc = oneNodeRpcApi;
            HarmonyNodeRpcWithHttpInfo = oneNodeRpcApi;
            
            var btcNodeRpcApi = new NodeRPCBtcApi(httpClient, configuration);
            
            BitcoinNodeRpc = btcNodeRpcApi;
            BitcoinNodeRpcWithHttpInfo = btcNodeRpcApi;
        }
    }
}
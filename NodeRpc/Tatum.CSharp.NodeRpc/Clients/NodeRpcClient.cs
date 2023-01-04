using System;
using System.Net.Http;
using Tatum.CSharp.NodeRpc.Configuration;
using Tatum.CSharp.NodeRpc.Core.Api;

namespace Tatum.CSharp.NodeRpc.Clients
{
    public class NodeRpcClient : INodeRpcClient
    {
        /// <inheritdoc />
        public INodeRPCApiAsync NodeRpc { get; }
        
        /// <inheritdoc />
        public INodeRPCApiWithHttpInfoAsync NodeRpcWithHttpInfo { get; }

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
            var nodeRpcApi = new NodeRPCApi(httpClient);
            
            nodeRpcApi.Configuration.ApiKey.Add("x-api-key", apiKey);
            
            NodeRpc = nodeRpcApi;
            NodeRpcWithHttpInfo = nodeRpcApi;
        }
    }
}
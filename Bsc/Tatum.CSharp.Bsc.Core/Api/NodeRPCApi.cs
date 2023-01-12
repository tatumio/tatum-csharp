/*
 * Tatum API Reference
 *
 * # Welcome to the Tatum API Reference!  ## What is Tatum?  Tatum offers a flexible framework to build, run, and scale blockchain apps fast. To learn more about the Tatum blockchain development framework, visit [our website](https://tatum.io/framework).  The Tatum API features powerful endpoints that simplify a complex blockchain into single API requests. Code for all supported blockchains using unified API calls.  ## Supported blockchains  Tatum supports multiple blockchains and various blockchain features.  Because not all blockchains function identically, Tatum supports a different set of features on each blockchain.  To see all the blockchains that Tatum supports, please refer to [this article](https://docs.tatum.io/introduction/supported-blockchains).  ## Need help?  To chat with other developers, get help from the Support team, and engage with the thriving Tatum community, join  our [Discord server](https://discord.com/invite/tatum). For more information about how to work with Tatum, review the [online documentation](https://docs.tatum.io/).  # Authentication  When using the Tatum API, you authenticate yourself with an **API key**. <SecurityDefinitions /> 
 *
 * The version of the OpenAPI document: 3.17.2
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using Tatum.CSharp.Bsc.Core.Client;

namespace Tatum.CSharp.Bsc.Core.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface INodeRPCApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Connect to the blockchain node through an RPC driver
        /// </summary>
        /// <remarks>
        /// The number of credits consumed depends on the number of methods submitted in an API call: * 50 credits per debug*_/trace* method (for EVM-based blockchains) * 50 credits per EOS Trace API methods * 5 credits per eth_call method (for EVM-based blockchains) * 2 credits per any other RPC method Connect directly to the blockchain node provided by Tatum. The POST method is used. The API endpoint URL acts as an HTTP-based RPC driver. In the request body, provide valid Web3 RPC method content, for example:  {   \&quot;jsonrpc\&quot;: \&quot;2.0\&quot;,   \&quot;id\&quot;: 1,   \&quot;method\&quot;: \&quot;method_name\&quot;,   \&quot;params\&quot;: [] } For the blockchains using the JSON-RPC 2.0 specification, you can submit multiple RPC methods in one API call:  [   {     \&quot;jsonrpc\&quot;: \&quot;2.0\&quot;,     \&quot;id\&quot;: 1,     \&quot;method\&quot;: \&quot;method_1_name\&quot;,     \&quot;params\&quot;: []   },   {     \&quot;jsonrpc\&quot;: \&quot;2.0\&quot;,     \&quot;id\&quot;: 2,     \&quot;method\&quot;: \&quot;method_2_name\&quot;,     \&quot;params\&quot;: []   },   ... ] This API is supported for the following blockchains: Algorand Arbitrum Aurora Avalanche C-Chain Avalanche P-Chain Avalanche X-Chain Bitcoin Bitcoin Cash BNB Beacon Chain BNB Smart Chain Cardano Celo Cronos Dogecoin Elrond EOSIO Ethereum Fantom Flow Gnosis Harmony Klaytn KuCoin Community Chain Kusama Lisk Litecoin NEAR Neo Oasis Network Optimism Palm Polkadot Polygon RSK Solana Stellar Tezos TRON VeChain XinFin XRP ZCash Zilliqa
        /// </remarks>
        /// <exception cref="Tatum.CSharp.Bsc.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="nodeType">Type of the node to access for Algorand. (optional)</param>
        /// <param name="testnetType">Type of Ethereum testnet. Defaults to ethereum-sepolia. (optional, default to ethereum-sepolia)</param>
        /// <param name="chainType">Type of Avalanche network. Defaults to Avalanche C-Chain. (optional, default to avax-c)</param>
        /// <returns>Object</returns>
        Object NodeJsonPostRpcDriver(Object body, string nodeType = default(string), string testnetType = default(string), string chainType = default(string));
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface INodeRPCApiWithHttpInfoSync : IApiAccessor
    {
        #region Synchronous Operations With Http Info
        /// <summary>
        /// Connect to the blockchain node through an RPC driver
        /// </summary>
        /// <remarks>
        /// The number of credits consumed depends on the number of methods submitted in an API call: * 50 credits per debug*_/trace* method (for EVM-based blockchains) * 50 credits per EOS Trace API methods * 5 credits per eth_call method (for EVM-based blockchains) * 2 credits per any other RPC method Connect directly to the blockchain node provided by Tatum. The POST method is used. The API endpoint URL acts as an HTTP-based RPC driver. In the request body, provide valid Web3 RPC method content, for example:  {   \&quot;jsonrpc\&quot;: \&quot;2.0\&quot;,   \&quot;id\&quot;: 1,   \&quot;method\&quot;: \&quot;method_name\&quot;,   \&quot;params\&quot;: [] } For the blockchains using the JSON-RPC 2.0 specification, you can submit multiple RPC methods in one API call:  [   {     \&quot;jsonrpc\&quot;: \&quot;2.0\&quot;,     \&quot;id\&quot;: 1,     \&quot;method\&quot;: \&quot;method_1_name\&quot;,     \&quot;params\&quot;: []   },   {     \&quot;jsonrpc\&quot;: \&quot;2.0\&quot;,     \&quot;id\&quot;: 2,     \&quot;method\&quot;: \&quot;method_2_name\&quot;,     \&quot;params\&quot;: []   },   ... ] This API is supported for the following blockchains: Algorand Arbitrum Aurora Avalanche C-Chain Avalanche P-Chain Avalanche X-Chain Bitcoin Bitcoin Cash BNB Beacon Chain BNB Smart Chain Cardano Celo Cronos Dogecoin Elrond EOSIO Ethereum Fantom Flow Gnosis Harmony Klaytn KuCoin Community Chain Kusama Lisk Litecoin NEAR Neo Oasis Network Optimism Palm Polkadot Polygon RSK Solana Stellar Tezos TRON VeChain XinFin XRP ZCash Zilliqa
        /// </remarks>
        /// <exception cref="Tatum.CSharp.Bsc.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="nodeType">Type of the node to access for Algorand. (optional)</param>
        /// <param name="testnetType">Type of Ethereum testnet. Defaults to ethereum-sepolia. (optional, default to ethereum-sepolia)</param>
        /// <param name="chainType">Type of Avalanche network. Defaults to Avalanche C-Chain. (optional, default to avax-c)</param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> NodeJsonPostRpcDriverWithHttpInfo(Object body, string nodeType = default(string), string testnetType = default(string), string chainType = default(string));
        #endregion Synchronous Operations With Http Info
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface INodeRPCApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Connect to the blockchain node through an RPC driver
        /// </summary>
        /// <remarks>
        /// The number of credits consumed depends on the number of methods submitted in an API call: * 50 credits per debug*_/trace* method (for EVM-based blockchains) * 50 credits per EOS Trace API methods * 5 credits per eth_call method (for EVM-based blockchains) * 2 credits per any other RPC method Connect directly to the blockchain node provided by Tatum. The POST method is used. The API endpoint URL acts as an HTTP-based RPC driver. In the request body, provide valid Web3 RPC method content, for example:  {   \&quot;jsonrpc\&quot;: \&quot;2.0\&quot;,   \&quot;id\&quot;: 1,   \&quot;method\&quot;: \&quot;method_name\&quot;,   \&quot;params\&quot;: [] } For the blockchains using the JSON-RPC 2.0 specification, you can submit multiple RPC methods in one API call:  [   {     \&quot;jsonrpc\&quot;: \&quot;2.0\&quot;,     \&quot;id\&quot;: 1,     \&quot;method\&quot;: \&quot;method_1_name\&quot;,     \&quot;params\&quot;: []   },   {     \&quot;jsonrpc\&quot;: \&quot;2.0\&quot;,     \&quot;id\&quot;: 2,     \&quot;method\&quot;: \&quot;method_2_name\&quot;,     \&quot;params\&quot;: []   },   ... ] This API is supported for the following blockchains: Algorand Arbitrum Aurora Avalanche C-Chain Avalanche P-Chain Avalanche X-Chain Bitcoin Bitcoin Cash BNB Beacon Chain BNB Smart Chain Cardano Celo Cronos Dogecoin Elrond EOSIO Ethereum Fantom Flow Gnosis Harmony Klaytn KuCoin Community Chain Kusama Lisk Litecoin NEAR Neo Oasis Network Optimism Palm Polkadot Polygon RSK Solana Stellar Tezos TRON VeChain XinFin XRP ZCash Zilliqa
        /// </remarks>
        /// <exception cref="Tatum.CSharp.Bsc.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="nodeType">Type of the node to access for Algorand. (optional)</param>
        /// <param name="testnetType">Type of Ethereum testnet. Defaults to ethereum-sepolia. (optional, default to ethereum-sepolia)</param>
        /// <param name="chainType">Type of Avalanche network. Defaults to Avalanche C-Chain. (optional, default to avax-c)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Object</returns>
        System.Threading.Tasks.Task<Object> NodeJsonPostRpcDriverAsync(Object body, string nodeType = default(string), string testnetType = default(string), string chainType = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface INodeRPCApiWithHttpInfoAsync : IApiAccessor
    {
        #region Asynchronous Operations With Http Info
        /// <summary>
        /// Connect to the blockchain node through an RPC driver
        /// </summary>
        /// <remarks>
        /// The number of credits consumed depends on the number of methods submitted in an API call: * 50 credits per debug*_/trace* method (for EVM-based blockchains) * 50 credits per EOS Trace API methods * 5 credits per eth_call method (for EVM-based blockchains) * 2 credits per any other RPC method Connect directly to the blockchain node provided by Tatum. The POST method is used. The API endpoint URL acts as an HTTP-based RPC driver. In the request body, provide valid Web3 RPC method content, for example:  {   \&quot;jsonrpc\&quot;: \&quot;2.0\&quot;,   \&quot;id\&quot;: 1,   \&quot;method\&quot;: \&quot;method_name\&quot;,   \&quot;params\&quot;: [] } For the blockchains using the JSON-RPC 2.0 specification, you can submit multiple RPC methods in one API call:  [   {     \&quot;jsonrpc\&quot;: \&quot;2.0\&quot;,     \&quot;id\&quot;: 1,     \&quot;method\&quot;: \&quot;method_1_name\&quot;,     \&quot;params\&quot;: []   },   {     \&quot;jsonrpc\&quot;: \&quot;2.0\&quot;,     \&quot;id\&quot;: 2,     \&quot;method\&quot;: \&quot;method_2_name\&quot;,     \&quot;params\&quot;: []   },   ... ] This API is supported for the following blockchains: Algorand Arbitrum Aurora Avalanche C-Chain Avalanche P-Chain Avalanche X-Chain Bitcoin Bitcoin Cash BNB Beacon Chain BNB Smart Chain Cardano Celo Cronos Dogecoin Elrond EOSIO Ethereum Fantom Flow Gnosis Harmony Klaytn KuCoin Community Chain Kusama Lisk Litecoin NEAR Neo Oasis Network Optimism Palm Polkadot Polygon RSK Solana Stellar Tezos TRON VeChain XinFin XRP ZCash Zilliqa
        /// </remarks>
        /// <exception cref="Tatum.CSharp.Bsc.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="nodeType">Type of the node to access for Algorand. (optional)</param>
        /// <param name="testnetType">Type of Ethereum testnet. Defaults to ethereum-sepolia. (optional, default to ethereum-sepolia)</param>
        /// <param name="chainType">Type of Avalanche network. Defaults to Avalanche C-Chain. (optional, default to avax-c)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Object)</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> NodeJsonPostRpcDriverWithHttpInfoAsync(Object body, string nodeType = default(string), string testnetType = default(string), string chainType = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations With Http Info
    }


    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface INodeRPCApi : INodeRPCApiSync, INodeRPCApiWithHttpInfoSync, INodeRPCApiAsync, INodeRPCApiWithHttpInfoAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class NodeRPCApi : INodeRPCApi
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeRPCApi"/> class.
        /// </summary>
        /// <param name="client">An instance of HttpClient.</param>
        /// <param name="handler">An optional instance of HttpClientHandler that is used by HttpClient.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        /// <remarks>
        /// Some configuration settings will not be applied without passing an HttpClientHandler.
        /// The features affected are: Setting and Retrieving Cookies, Client Certificates, Proxy settings.
        /// </remarks>
        public NodeRPCApi(HttpClient client, HttpClientHandler handler = null) : this(client, (string)null, handler)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeRPCApi"/> class.
        /// </summary>
        /// <param name="client">An instance of HttpClient.</param>
        /// <param name="basePath">The target service's base path in URL format.</param>
        /// <param name="handler">An optional instance of HttpClientHandler that is used by HttpClient.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <returns></returns>
        /// <remarks>
        /// Some configuration settings will not be applied without passing an HttpClientHandler.
        /// The features affected are: Setting and Retrieving Cookies, Client Certificates, Proxy settings.
        /// </remarks>
        public NodeRPCApi(HttpClient client, string basePath, HttpClientHandler handler = null)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));

            Configuration = Tatum.CSharp.Bsc.Core.Client.Configuration.MergeConfigurations(
                GlobalConfiguration.Instance,
                new Configuration { BasePath = basePath }
            );
            ApiClient = new ApiClient(client, Configuration.BasePath, handler);
            Client =  ApiClient;
            AsynchronousClient = ApiClient;
            ExceptionFactory = Tatum.CSharp.Bsc.Core.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeRPCApi"/> class using Configuration object.
        /// </summary>
        /// <param name="client">An instance of HttpClient.</param>
        /// <param name="configuration">An instance of Configuration.</param>
        /// <param name="handler">An optional instance of HttpClientHandler that is used by HttpClient.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        /// <remarks>
        /// Some configuration settings will not be applied without passing an HttpClientHandler.
        /// The features affected are: Setting and Retrieving Cookies, Client Certificates, Proxy settings.
        /// </remarks>
        public NodeRPCApi(HttpClient client, Configuration configuration, HttpClientHandler handler = null)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
            if (client == null) throw new ArgumentNullException(nameof(client));

            Configuration = Tatum.CSharp.Bsc.Core.Client.Configuration.MergeConfigurations(
                GlobalConfiguration.Instance,
                configuration
            );
            ApiClient = new ApiClient(client, Configuration.BasePath, handler);
            Client = ApiClient;
            AsynchronousClient = ApiClient;
            ExceptionFactory = Tatum.CSharp.Bsc.Core.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeRPCApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public NodeRPCApi(ISynchronousClient client, IAsynchronousClient asyncClient, IReadableConfiguration configuration)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
            AsynchronousClient = asyncClient ?? throw new ArgumentNullException(nameof(asyncClient));
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            ExceptionFactory = Tatum.CSharp.Bsc.Core.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Holds the ApiClient if created
        /// </summary>
        public ApiClient ApiClient { get; set; }

        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public IAsynchronousClient AsynchronousClient { get; set; }

        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public ISynchronousClient Client { get; set; }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public string GetBasePath()
        {
            return Configuration.BasePath;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public IReadableConfiguration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set => _exceptionFactory = value;
        }

        /// <summary>
        /// Connect to the blockchain node through an RPC driver The number of credits consumed depends on the number of methods submitted in an API call: * 50 credits per debug*_/trace* method (for EVM-based blockchains) * 50 credits per EOS Trace API methods * 5 credits per eth_call method (for EVM-based blockchains) * 2 credits per any other RPC method Connect directly to the blockchain node provided by Tatum. The POST method is used. The API endpoint URL acts as an HTTP-based RPC driver. In the request body, provide valid Web3 RPC method content, for example:  {   \&quot;jsonrpc\&quot;: \&quot;2.0\&quot;,   \&quot;id\&quot;: 1,   \&quot;method\&quot;: \&quot;method_name\&quot;,   \&quot;params\&quot;: [] } For the blockchains using the JSON-RPC 2.0 specification, you can submit multiple RPC methods in one API call:  [   {     \&quot;jsonrpc\&quot;: \&quot;2.0\&quot;,     \&quot;id\&quot;: 1,     \&quot;method\&quot;: \&quot;method_1_name\&quot;,     \&quot;params\&quot;: []   },   {     \&quot;jsonrpc\&quot;: \&quot;2.0\&quot;,     \&quot;id\&quot;: 2,     \&quot;method\&quot;: \&quot;method_2_name\&quot;,     \&quot;params\&quot;: []   },   ... ] This API is supported for the following blockchains: Algorand Arbitrum Aurora Avalanche C-Chain Avalanche P-Chain Avalanche X-Chain Bitcoin Bitcoin Cash BNB Beacon Chain BNB Smart Chain Cardano Celo Cronos Dogecoin Elrond EOSIO Ethereum Fantom Flow Gnosis Harmony Klaytn KuCoin Community Chain Kusama Lisk Litecoin NEAR Neo Oasis Network Optimism Palm Polkadot Polygon RSK Solana Stellar Tezos TRON VeChain XinFin XRP ZCash Zilliqa
        /// </summary>
        /// <exception cref="Tatum.CSharp.Bsc.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="nodeType">Type of the node to access for Algorand. (optional)</param>
        /// <param name="testnetType">Type of Ethereum testnet. Defaults to ethereum-sepolia. (optional, default to ethereum-sepolia)</param>
        /// <param name="chainType">Type of Avalanche network. Defaults to Avalanche C-Chain. (optional, default to avax-c)</param>
        /// <returns>Object</returns>
        public Object NodeJsonPostRpcDriver(Object body, string nodeType = default(string), string testnetType = default(string), string chainType = default(string))
        {
            var localVarResponse = NodeJsonPostRpcDriverWithHttpInfo(body, nodeType, testnetType, chainType);

            var exception = ExceptionFactory?.Invoke("NodeJsonPostRpcDriver", localVarResponse);
            if (exception != null) throw exception;

            return localVarResponse.Data;
        }

        /// <summary>
        /// Connect to the blockchain node through an RPC driver The number of credits consumed depends on the number of methods submitted in an API call: * 50 credits per debug*_/trace* method (for EVM-based blockchains) * 50 credits per EOS Trace API methods * 5 credits per eth_call method (for EVM-based blockchains) * 2 credits per any other RPC method Connect directly to the blockchain node provided by Tatum. The POST method is used. The API endpoint URL acts as an HTTP-based RPC driver. In the request body, provide valid Web3 RPC method content, for example:  {   \&quot;jsonrpc\&quot;: \&quot;2.0\&quot;,   \&quot;id\&quot;: 1,   \&quot;method\&quot;: \&quot;method_name\&quot;,   \&quot;params\&quot;: [] } For the blockchains using the JSON-RPC 2.0 specification, you can submit multiple RPC methods in one API call:  [   {     \&quot;jsonrpc\&quot;: \&quot;2.0\&quot;,     \&quot;id\&quot;: 1,     \&quot;method\&quot;: \&quot;method_1_name\&quot;,     \&quot;params\&quot;: []   },   {     \&quot;jsonrpc\&quot;: \&quot;2.0\&quot;,     \&quot;id\&quot;: 2,     \&quot;method\&quot;: \&quot;method_2_name\&quot;,     \&quot;params\&quot;: []   },   ... ] This API is supported for the following blockchains: Algorand Arbitrum Aurora Avalanche C-Chain Avalanche P-Chain Avalanche X-Chain Bitcoin Bitcoin Cash BNB Beacon Chain BNB Smart Chain Cardano Celo Cronos Dogecoin Elrond EOSIO Ethereum Fantom Flow Gnosis Harmony Klaytn KuCoin Community Chain Kusama Lisk Litecoin NEAR Neo Oasis Network Optimism Palm Polkadot Polygon RSK Solana Stellar Tezos TRON VeChain XinFin XRP ZCash Zilliqa
        /// </summary>
        /// <exception cref="Tatum.CSharp.Bsc.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="nodeType">Type of the node to access for Algorand. (optional)</param>
        /// <param name="testnetType">Type of Ethereum testnet. Defaults to ethereum-sepolia. (optional, default to ethereum-sepolia)</param>
        /// <param name="chainType">Type of Avalanche network. Defaults to Avalanche C-Chain. (optional, default to avax-c)</param>
        /// <returns>ApiResponse of Object</returns>
        public ApiResponse<Object> NodeJsonPostRpcDriverWithHttpInfo(Object body, string nodeType = default(string), string testnetType = default(string), string chainType = default(string))
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling NodeRPCApi->NodeJsonPostRpcDriver");

            var localVarRequestOptions = new RequestOptions();

            var contentTypes = new string[]{
                "application/json"
            };

            // to determine the Accept header
            var accepts = new string[]{
                "application/json"
            };

            var localVarContentType = ClientUtils.SelectHeaderContentType(contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            if (nodeType != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "nodeType", nodeType));
            }
            if (testnetType != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "testnetType", testnetType));
            }
            if (chainType != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "chainType", chainType));
            }
            localVarRequestOptions.Data = body;

            // authentication (X-API-Key) required
            if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("x-api-key")))
            {
                localVarRequestOptions.HeaderParameters.Add("x-api-key", Configuration.GetApiKeyWithPrefix("x-api-key"));
            }

            // make the HTTP request
            var localVarResponse = Client.Post<Object>("/v3/blockchain/node/BSC", localVarRequestOptions, Configuration);

            return localVarResponse;
        }

        /// <summary>
        /// Connect to the blockchain node through an RPC driver The number of credits consumed depends on the number of methods submitted in an API call: * 50 credits per debug*_/trace* method (for EVM-based blockchains) * 50 credits per EOS Trace API methods * 5 credits per eth_call method (for EVM-based blockchains) * 2 credits per any other RPC method Connect directly to the blockchain node provided by Tatum. The POST method is used. The API endpoint URL acts as an HTTP-based RPC driver. In the request body, provide valid Web3 RPC method content, for example:  {   \&quot;jsonrpc\&quot;: \&quot;2.0\&quot;,   \&quot;id\&quot;: 1,   \&quot;method\&quot;: \&quot;method_name\&quot;,   \&quot;params\&quot;: [] } For the blockchains using the JSON-RPC 2.0 specification, you can submit multiple RPC methods in one API call:  [   {     \&quot;jsonrpc\&quot;: \&quot;2.0\&quot;,     \&quot;id\&quot;: 1,     \&quot;method\&quot;: \&quot;method_1_name\&quot;,     \&quot;params\&quot;: []   },   {     \&quot;jsonrpc\&quot;: \&quot;2.0\&quot;,     \&quot;id\&quot;: 2,     \&quot;method\&quot;: \&quot;method_2_name\&quot;,     \&quot;params\&quot;: []   },   ... ] This API is supported for the following blockchains: Algorand Arbitrum Aurora Avalanche C-Chain Avalanche P-Chain Avalanche X-Chain Bitcoin Bitcoin Cash BNB Beacon Chain BNB Smart Chain Cardano Celo Cronos Dogecoin Elrond EOSIO Ethereum Fantom Flow Gnosis Harmony Klaytn KuCoin Community Chain Kusama Lisk Litecoin NEAR Neo Oasis Network Optimism Palm Polkadot Polygon RSK Solana Stellar Tezos TRON VeChain XinFin XRP ZCash Zilliqa
        /// </summary>
        /// <exception cref="Tatum.CSharp.Bsc.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="nodeType">Type of the node to access for Algorand. (optional)</param>
        /// <param name="testnetType">Type of Ethereum testnet. Defaults to ethereum-sepolia. (optional, default to ethereum-sepolia)</param>
        /// <param name="chainType">Type of Avalanche network. Defaults to Avalanche C-Chain. (optional, default to avax-c)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Object</returns>
        public async System.Threading.Tasks.Task<Object> NodeJsonPostRpcDriverAsync(Object body, string nodeType = default(string), string testnetType = default(string), string chainType = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            var localVarResponse = await NodeJsonPostRpcDriverWithHttpInfoAsync(body, nodeType, testnetType, chainType, cancellationToken).ConfigureAwait(false);
            
            var exception = ExceptionFactory?.Invoke("NodeJsonPostRpcDriver", localVarResponse);
            if (exception != null) throw exception;

            return localVarResponse.Data;
        }

        /// <summary>
        /// Connect to the blockchain node through an RPC driver The number of credits consumed depends on the number of methods submitted in an API call: * 50 credits per debug*_/trace* method (for EVM-based blockchains) * 50 credits per EOS Trace API methods * 5 credits per eth_call method (for EVM-based blockchains) * 2 credits per any other RPC method Connect directly to the blockchain node provided by Tatum. The POST method is used. The API endpoint URL acts as an HTTP-based RPC driver. In the request body, provide valid Web3 RPC method content, for example:  {   \&quot;jsonrpc\&quot;: \&quot;2.0\&quot;,   \&quot;id\&quot;: 1,   \&quot;method\&quot;: \&quot;method_name\&quot;,   \&quot;params\&quot;: [] } For the blockchains using the JSON-RPC 2.0 specification, you can submit multiple RPC methods in one API call:  [   {     \&quot;jsonrpc\&quot;: \&quot;2.0\&quot;,     \&quot;id\&quot;: 1,     \&quot;method\&quot;: \&quot;method_1_name\&quot;,     \&quot;params\&quot;: []   },   {     \&quot;jsonrpc\&quot;: \&quot;2.0\&quot;,     \&quot;id\&quot;: 2,     \&quot;method\&quot;: \&quot;method_2_name\&quot;,     \&quot;params\&quot;: []   },   ... ] This API is supported for the following blockchains: Algorand Arbitrum Aurora Avalanche C-Chain Avalanche P-Chain Avalanche X-Chain Bitcoin Bitcoin Cash BNB Beacon Chain BNB Smart Chain Cardano Celo Cronos Dogecoin Elrond EOSIO Ethereum Fantom Flow Gnosis Harmony Klaytn KuCoin Community Chain Kusama Lisk Litecoin NEAR Neo Oasis Network Optimism Palm Polkadot Polygon RSK Solana Stellar Tezos TRON VeChain XinFin XRP ZCash Zilliqa
        /// </summary>
        /// <exception cref="Tatum.CSharp.Bsc.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="nodeType">Type of the node to access for Algorand. (optional)</param>
        /// <param name="testnetType">Type of Ethereum testnet. Defaults to ethereum-sepolia. (optional, default to ethereum-sepolia)</param>
        /// <param name="chainType">Type of Avalanche network. Defaults to Avalanche C-Chain. (optional, default to avax-c)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Object)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> NodeJsonPostRpcDriverWithHttpInfoAsync(Object body, string nodeType = default(string), string testnetType = default(string), string chainType = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling NodeRPCApi->NodeJsonPostRpcDriver");

            var localVarRequestOptions = new RequestOptions();

            var contentTypes = new string[]{
                "application/json"
            };

            // to determine the Accept header
            var accepts = new string[]{
                "application/json"
            };


            var localVarContentType = ClientUtils.SelectHeaderContentType(contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            if (nodeType != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "nodeType", nodeType));
            }
            if (testnetType != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "testnetType", testnetType));
            }
            if (chainType != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "chainType", chainType));
            }
            localVarRequestOptions.Data = body;

            // authentication (X-API-Key) required
            if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("x-api-key")))
            {
                localVarRequestOptions.HeaderParameters.Add("x-api-key", Configuration.GetApiKeyWithPrefix("x-api-key"));
            }

            // make the HTTP request

            var localVarResponse = await AsynchronousClient.PostAsync<Object>("/v3/blockchain/node/BSC", localVarRequestOptions, Configuration, cancellationToken).ConfigureAwait(false);

            return localVarResponse;
        }

    }
}

/*
 * Tatum API Reference
 *
 * # Welcome to the Tatum API Reference!  ## What is Tatum?  Tatum offers a flexible framework to build, run, and scale blockchain apps fast. To learn more about the Tatum blockchain development framework, visit [our website](https://tatum.io/framework).  The Tatum API features powerful endpoints that simplify a complex blockchain into single API requests. Code for all supported blockchains using unified API calls.  ## Need help?  To chat with other developers, get help from the Support team, and engage with the thriving Tatum community, join  our [Discord server](https://discord.com/invite/tatum). For more information about how to work with Tatum, review the [online documentation](https://docs.tatum.io/).  ## About this API Reference  The Tatum API Reference is based on OpenAPI Specification v3.1.0 with a few [vendor extensions](https://github.com/Redocly/redoc/blob/master/docs/redoc-vendor-extensions.md) applied.  # Authentication  When using the Tatum API, you authenticate yourself with an **API key**. <SecurityDefinitions /> 
 *
 * The version of the OpenAPI document: 3.17.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using Tatum.CSharp.Core.Client;
using Tatum.CSharp.Core.Model;

namespace Tatum.CSharp.Core.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IBlockchainFeesApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Estimate Ethereum transaction fees
        /// </summary>
        /// <remarks>
        /// 10 credits per API call. Estimate gasLimit and gasPrice of the Ethereum transaction. Gas price is obtained from multiple sources + calculated based on the latest N blocks and the current mempool state. The fast one is used by default.
        /// </remarks>
        /// <exception cref="Tatum.CSharp.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="ethEstimateGas"></param>
        /// <param name="xTestnetType">Type of Ethereum testnet. Defaults to ethereum-sepolia. (optional, default to ethereum-sepolia)</param>
        /// <returns>EthGasEstimation</returns>
        EthGasEstimation EthEstimateGas(EthEstimateGas ethEstimateGas, string xTestnetType = default(string));
        /// <summary>
        /// Estimate multiple Ethereum transaction fees
        /// </summary>
        /// <remarks>
        /// 10 credits per API call + 10 credits per each gas estimation. Estimate gasLimit and gasPrice of the Ethereum transaction. Gas price is obtained from multiple sources + calculated based on the latest N blocks and the current mempool state. The fast one is used by default. Result is calculated in the order of the request array items.
        /// </remarks>
        /// <exception cref="Tatum.CSharp.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="ethEstimateGasArray"></param>
        /// <param name="xTestnetType">Type of Ethereum testnet. Defaults to ethereum-sepolia. (optional, default to ethereum-sepolia)</param>
        /// <returns>EthGasEstimationBatch</returns>
        EthGasEstimationBatch EthEstimateGasBatch(EthEstimateGasArray ethEstimateGasArray, string xTestnetType = default(string));
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IBlockchainFeesApiWithHttpInfoSync : IApiAccessor
    {
        #region Synchronous Operations With Http Info
        /// <summary>
        /// Estimate Ethereum transaction fees
        /// </summary>
        /// <remarks>
        /// 10 credits per API call. Estimate gasLimit and gasPrice of the Ethereum transaction. Gas price is obtained from multiple sources + calculated based on the latest N blocks and the current mempool state. The fast one is used by default.
        /// </remarks>
        /// <exception cref="Tatum.CSharp.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="ethEstimateGas"></param>
        /// <param name="xTestnetType">Type of Ethereum testnet. Defaults to ethereum-sepolia. (optional, default to ethereum-sepolia)</param>
        /// <returns>ApiResponse of EthGasEstimation</returns>
        ApiResponse<EthGasEstimation> EthEstimateGasWithHttpInfo(EthEstimateGas ethEstimateGas, string xTestnetType = default(string));
        /// <summary>
        /// Estimate multiple Ethereum transaction fees
        /// </summary>
        /// <remarks>
        /// 10 credits per API call + 10 credits per each gas estimation. Estimate gasLimit and gasPrice of the Ethereum transaction. Gas price is obtained from multiple sources + calculated based on the latest N blocks and the current mempool state. The fast one is used by default. Result is calculated in the order of the request array items.
        /// </remarks>
        /// <exception cref="Tatum.CSharp.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="ethEstimateGasArray"></param>
        /// <param name="xTestnetType">Type of Ethereum testnet. Defaults to ethereum-sepolia. (optional, default to ethereum-sepolia)</param>
        /// <returns>ApiResponse of EthGasEstimationBatch</returns>
        ApiResponse<EthGasEstimationBatch> EthEstimateGasBatchWithHttpInfo(EthEstimateGasArray ethEstimateGasArray, string xTestnetType = default(string));
        #endregion Synchronous Operations With Http Info
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IBlockchainFeesApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Estimate Ethereum transaction fees
        /// </summary>
        /// <remarks>
        /// 10 credits per API call. Estimate gasLimit and gasPrice of the Ethereum transaction. Gas price is obtained from multiple sources + calculated based on the latest N blocks and the current mempool state. The fast one is used by default.
        /// </remarks>
        /// <exception cref="Tatum.CSharp.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="ethEstimateGas"></param>
        /// <param name="xTestnetType">Type of Ethereum testnet. Defaults to ethereum-sepolia. (optional, default to ethereum-sepolia)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of EthGasEstimation</returns>
        System.Threading.Tasks.Task<EthGasEstimation> EthEstimateGasAsync(EthEstimateGas ethEstimateGas, string xTestnetType = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Estimate multiple Ethereum transaction fees
        /// </summary>
        /// <remarks>
        /// 10 credits per API call + 10 credits per each gas estimation. Estimate gasLimit and gasPrice of the Ethereum transaction. Gas price is obtained from multiple sources + calculated based on the latest N blocks and the current mempool state. The fast one is used by default. Result is calculated in the order of the request array items.
        /// </remarks>
        /// <exception cref="Tatum.CSharp.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="ethEstimateGasArray"></param>
        /// <param name="xTestnetType">Type of Ethereum testnet. Defaults to ethereum-sepolia. (optional, default to ethereum-sepolia)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of EthGasEstimationBatch</returns>
        System.Threading.Tasks.Task<EthGasEstimationBatch> EthEstimateGasBatchAsync(EthEstimateGasArray ethEstimateGasArray, string xTestnetType = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IBlockchainFeesApiWithHttpInfoAsync : IApiAccessor
    {
        #region Asynchronous Operations With Http Info
        /// <summary>
        /// Estimate Ethereum transaction fees
        /// </summary>
        /// <remarks>
        /// 10 credits per API call. Estimate gasLimit and gasPrice of the Ethereum transaction. Gas price is obtained from multiple sources + calculated based on the latest N blocks and the current mempool state. The fast one is used by default.
        /// </remarks>
        /// <exception cref="Tatum.CSharp.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="ethEstimateGas"></param>
        /// <param name="xTestnetType">Type of Ethereum testnet. Defaults to ethereum-sepolia. (optional, default to ethereum-sepolia)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (EthGasEstimation)</returns>
        System.Threading.Tasks.Task<ApiResponse<EthGasEstimation>> EthEstimateGasWithHttpInfoAsync(EthEstimateGas ethEstimateGas, string xTestnetType = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Estimate multiple Ethereum transaction fees
        /// </summary>
        /// <remarks>
        /// 10 credits per API call + 10 credits per each gas estimation. Estimate gasLimit and gasPrice of the Ethereum transaction. Gas price is obtained from multiple sources + calculated based on the latest N blocks and the current mempool state. The fast one is used by default. Result is calculated in the order of the request array items.
        /// </remarks>
        /// <exception cref="Tatum.CSharp.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="ethEstimateGasArray"></param>
        /// <param name="xTestnetType">Type of Ethereum testnet. Defaults to ethereum-sepolia. (optional, default to ethereum-sepolia)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (EthGasEstimationBatch)</returns>
        System.Threading.Tasks.Task<ApiResponse<EthGasEstimationBatch>> EthEstimateGasBatchWithHttpInfoAsync(EthEstimateGasArray ethEstimateGasArray, string xTestnetType = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations With Http Info
    }


    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IBlockchainFeesApi : IBlockchainFeesApiSync, IBlockchainFeesApiWithHttpInfoSync, IBlockchainFeesApiAsync, IBlockchainFeesApiWithHttpInfoAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class BlockchainFeesApi : IBlockchainFeesApi
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockchainFeesApi"/> class.
        /// </summary>
        /// <param name="client">An instance of HttpClient.</param>
        /// <param name="handler">An optional instance of HttpClientHandler that is used by HttpClient.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        /// <remarks>
        /// Some configuration settings will not be applied without passing an HttpClientHandler.
        /// The features affected are: Setting and Retrieving Cookies, Client Certificates, Proxy settings.
        /// </remarks>
        public BlockchainFeesApi(HttpClient client, HttpClientHandler handler = null) : this(client, (string)null, handler)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockchainFeesApi"/> class.
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
        public BlockchainFeesApi(HttpClient client, string basePath, HttpClientHandler handler = null)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));

            Configuration = Tatum.CSharp.Core.Client.Configuration.MergeConfigurations(
                GlobalConfiguration.Instance,
                new Configuration { BasePath = basePath }
            );
            ApiClient = new ApiClient(client, Configuration.BasePath, handler);
            Client =  ApiClient;
            AsynchronousClient = ApiClient;
            ExceptionFactory = Tatum.CSharp.Core.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockchainFeesApi"/> class using Configuration object.
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
        public BlockchainFeesApi(HttpClient client, Configuration configuration, HttpClientHandler handler = null)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
            if (client == null) throw new ArgumentNullException(nameof(client));

            Configuration = Tatum.CSharp.Core.Client.Configuration.MergeConfigurations(
                GlobalConfiguration.Instance,
                configuration
            );
            ApiClient = new ApiClient(client, Configuration.BasePath, handler);
            Client = ApiClient;
            AsynchronousClient = ApiClient;
            ExceptionFactory = Tatum.CSharp.Core.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockchainFeesApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public BlockchainFeesApi(ISynchronousClient client, IAsynchronousClient asyncClient, IReadableConfiguration configuration)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
            AsynchronousClient = asyncClient ?? throw new ArgumentNullException(nameof(asyncClient));
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            ExceptionFactory = Tatum.CSharp.Core.Client.Configuration.DefaultExceptionFactory;
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
        /// Estimate Ethereum transaction fees 10 credits per API call. Estimate gasLimit and gasPrice of the Ethereum transaction. Gas price is obtained from multiple sources + calculated based on the latest N blocks and the current mempool state. The fast one is used by default.
        /// </summary>
        /// <exception cref="Tatum.CSharp.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="ethEstimateGas"></param>
        /// <param name="xTestnetType">Type of Ethereum testnet. Defaults to ethereum-sepolia. (optional, default to ethereum-sepolia)</param>
        /// <returns>EthGasEstimation</returns>
        public EthGasEstimation EthEstimateGas(EthEstimateGas ethEstimateGas, string xTestnetType = default(string))
        {
            var localVarResponse = EthEstimateGasWithHttpInfo(ethEstimateGas, xTestnetType);

            var exception = ExceptionFactory?.Invoke("EthEstimateGas", localVarResponse);
            if (exception != null) throw exception;

            return localVarResponse.Data;
        }

        /// <summary>
        /// Estimate Ethereum transaction fees 10 credits per API call. Estimate gasLimit and gasPrice of the Ethereum transaction. Gas price is obtained from multiple sources + calculated based on the latest N blocks and the current mempool state. The fast one is used by default.
        /// </summary>
        /// <exception cref="Tatum.CSharp.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="ethEstimateGas"></param>
        /// <param name="xTestnetType">Type of Ethereum testnet. Defaults to ethereum-sepolia. (optional, default to ethereum-sepolia)</param>
        /// <returns>ApiResponse of EthGasEstimation</returns>
        public ApiResponse<EthGasEstimation> EthEstimateGasWithHttpInfo(EthEstimateGas ethEstimateGas, string xTestnetType = default(string))
        {
            // verify the required parameter 'ethEstimateGas' is set
            if (ethEstimateGas == null)
                throw new ApiException(400, "Missing required parameter 'ethEstimateGas' when calling BlockchainFeesApi->EthEstimateGas");

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

            if (xTestnetType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("x-testnet-type", ClientUtils.ParameterToString(xTestnetType)); // header parameter
            }
            localVarRequestOptions.Data = ethEstimateGas;

            // authentication (X-API-Key) required
            if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("x-api-key")))
            {
                localVarRequestOptions.HeaderParameters.Add("x-api-key", Configuration.GetApiKeyWithPrefix("x-api-key"));
            }

            // make the HTTP request
            var localVarResponse = Client.Post<EthGasEstimation>("/v3/ethereum/gas", localVarRequestOptions, Configuration);

            return localVarResponse;
        }

        /// <summary>
        /// Estimate Ethereum transaction fees 10 credits per API call. Estimate gasLimit and gasPrice of the Ethereum transaction. Gas price is obtained from multiple sources + calculated based on the latest N blocks and the current mempool state. The fast one is used by default.
        /// </summary>
        /// <exception cref="Tatum.CSharp.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="ethEstimateGas"></param>
        /// <param name="xTestnetType">Type of Ethereum testnet. Defaults to ethereum-sepolia. (optional, default to ethereum-sepolia)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of EthGasEstimation</returns>
        public async System.Threading.Tasks.Task<EthGasEstimation> EthEstimateGasAsync(EthEstimateGas ethEstimateGas, string xTestnetType = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            var localVarResponse = await EthEstimateGasWithHttpInfoAsync(ethEstimateGas, xTestnetType, cancellationToken).ConfigureAwait(false);
            
            var exception = ExceptionFactory?.Invoke("EthEstimateGas", localVarResponse);
            if (exception != null) throw exception;

            return localVarResponse.Data;
        }

        /// <summary>
        /// Estimate Ethereum transaction fees 10 credits per API call. Estimate gasLimit and gasPrice of the Ethereum transaction. Gas price is obtained from multiple sources + calculated based on the latest N blocks and the current mempool state. The fast one is used by default.
        /// </summary>
        /// <exception cref="Tatum.CSharp.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="ethEstimateGas"></param>
        /// <param name="xTestnetType">Type of Ethereum testnet. Defaults to ethereum-sepolia. (optional, default to ethereum-sepolia)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (EthGasEstimation)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<EthGasEstimation>> EthEstimateGasWithHttpInfoAsync(EthEstimateGas ethEstimateGas, string xTestnetType = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'ethEstimateGas' is set
            if (ethEstimateGas == null)
                throw new ApiException(400, "Missing required parameter 'ethEstimateGas' when calling BlockchainFeesApi->EthEstimateGas");


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

            if (xTestnetType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("x-testnet-type", ClientUtils.ParameterToString(xTestnetType)); // header parameter
            }
            localVarRequestOptions.Data = ethEstimateGas;

            // authentication (X-API-Key) required
            if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("x-api-key")))
            {
                localVarRequestOptions.HeaderParameters.Add("x-api-key", Configuration.GetApiKeyWithPrefix("x-api-key"));
            }

            // make the HTTP request

            var localVarResponse = await AsynchronousClient.PostAsync<EthGasEstimation>("/v3/ethereum/gas", localVarRequestOptions, Configuration, cancellationToken).ConfigureAwait(false);

            return localVarResponse;
        }

        /// <summary>
        /// Estimate multiple Ethereum transaction fees 10 credits per API call + 10 credits per each gas estimation. Estimate gasLimit and gasPrice of the Ethereum transaction. Gas price is obtained from multiple sources + calculated based on the latest N blocks and the current mempool state. The fast one is used by default. Result is calculated in the order of the request array items.
        /// </summary>
        /// <exception cref="Tatum.CSharp.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="ethEstimateGasArray"></param>
        /// <param name="xTestnetType">Type of Ethereum testnet. Defaults to ethereum-sepolia. (optional, default to ethereum-sepolia)</param>
        /// <returns>EthGasEstimationBatch</returns>
        public EthGasEstimationBatch EthEstimateGasBatch(EthEstimateGasArray ethEstimateGasArray, string xTestnetType = default(string))
        {
            var localVarResponse = EthEstimateGasBatchWithHttpInfo(ethEstimateGasArray, xTestnetType);

            var exception = ExceptionFactory?.Invoke("EthEstimateGasBatch", localVarResponse);
            if (exception != null) throw exception;

            return localVarResponse.Data;
        }

        /// <summary>
        /// Estimate multiple Ethereum transaction fees 10 credits per API call + 10 credits per each gas estimation. Estimate gasLimit and gasPrice of the Ethereum transaction. Gas price is obtained from multiple sources + calculated based on the latest N blocks and the current mempool state. The fast one is used by default. Result is calculated in the order of the request array items.
        /// </summary>
        /// <exception cref="Tatum.CSharp.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="ethEstimateGasArray"></param>
        /// <param name="xTestnetType">Type of Ethereum testnet. Defaults to ethereum-sepolia. (optional, default to ethereum-sepolia)</param>
        /// <returns>ApiResponse of EthGasEstimationBatch</returns>
        public ApiResponse<EthGasEstimationBatch> EthEstimateGasBatchWithHttpInfo(EthEstimateGasArray ethEstimateGasArray, string xTestnetType = default(string))
        {
            // verify the required parameter 'ethEstimateGasArray' is set
            if (ethEstimateGasArray == null)
                throw new ApiException(400, "Missing required parameter 'ethEstimateGasArray' when calling BlockchainFeesApi->EthEstimateGasBatch");

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

            if (xTestnetType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("x-testnet-type", ClientUtils.ParameterToString(xTestnetType)); // header parameter
            }
            localVarRequestOptions.Data = ethEstimateGasArray;

            // authentication (X-API-Key) required
            if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("x-api-key")))
            {
                localVarRequestOptions.HeaderParameters.Add("x-api-key", Configuration.GetApiKeyWithPrefix("x-api-key"));
            }

            // make the HTTP request
            var localVarResponse = Client.Post<EthGasEstimationBatch>("/v3/ethereum/gas/batch", localVarRequestOptions, Configuration);

            return localVarResponse;
        }

        /// <summary>
        /// Estimate multiple Ethereum transaction fees 10 credits per API call + 10 credits per each gas estimation. Estimate gasLimit and gasPrice of the Ethereum transaction. Gas price is obtained from multiple sources + calculated based on the latest N blocks and the current mempool state. The fast one is used by default. Result is calculated in the order of the request array items.
        /// </summary>
        /// <exception cref="Tatum.CSharp.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="ethEstimateGasArray"></param>
        /// <param name="xTestnetType">Type of Ethereum testnet. Defaults to ethereum-sepolia. (optional, default to ethereum-sepolia)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of EthGasEstimationBatch</returns>
        public async System.Threading.Tasks.Task<EthGasEstimationBatch> EthEstimateGasBatchAsync(EthEstimateGasArray ethEstimateGasArray, string xTestnetType = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            var localVarResponse = await EthEstimateGasBatchWithHttpInfoAsync(ethEstimateGasArray, xTestnetType, cancellationToken).ConfigureAwait(false);
            
            var exception = ExceptionFactory?.Invoke("EthEstimateGasBatch", localVarResponse);
            if (exception != null) throw exception;

            return localVarResponse.Data;
        }

        /// <summary>
        /// Estimate multiple Ethereum transaction fees 10 credits per API call + 10 credits per each gas estimation. Estimate gasLimit and gasPrice of the Ethereum transaction. Gas price is obtained from multiple sources + calculated based on the latest N blocks and the current mempool state. The fast one is used by default. Result is calculated in the order of the request array items.
        /// </summary>
        /// <exception cref="Tatum.CSharp.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="ethEstimateGasArray"></param>
        /// <param name="xTestnetType">Type of Ethereum testnet. Defaults to ethereum-sepolia. (optional, default to ethereum-sepolia)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (EthGasEstimationBatch)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<EthGasEstimationBatch>> EthEstimateGasBatchWithHttpInfoAsync(EthEstimateGasArray ethEstimateGasArray, string xTestnetType = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'ethEstimateGasArray' is set
            if (ethEstimateGasArray == null)
                throw new ApiException(400, "Missing required parameter 'ethEstimateGasArray' when calling BlockchainFeesApi->EthEstimateGasBatch");


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

            if (xTestnetType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("x-testnet-type", ClientUtils.ParameterToString(xTestnetType)); // header parameter
            }
            localVarRequestOptions.Data = ethEstimateGasArray;

            // authentication (X-API-Key) required
            if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("x-api-key")))
            {
                localVarRequestOptions.HeaderParameters.Add("x-api-key", Configuration.GetApiKeyWithPrefix("x-api-key"));
            }

            // make the HTTP request

            var localVarResponse = await AsynchronousClient.PostAsync<EthGasEstimationBatch>("/v3/ethereum/gas/batch", localVarRequestOptions, Configuration, cancellationToken).ConfigureAwait(false);

            return localVarResponse;
        }

    }
}

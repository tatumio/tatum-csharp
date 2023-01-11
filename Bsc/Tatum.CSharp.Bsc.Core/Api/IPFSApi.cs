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
using Tatum.CSharp.Bsc.Core.Model;

namespace Tatum.CSharp.Bsc.Core.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IIPFSApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Get file from IPFS
        /// </summary>
        /// <remarks>
        /// 1 credit per API call. Gets data from the IPFS.
        /// </remarks>
        /// <exception cref="Tatum.CSharp.Bsc.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">IPFS CID of the file</param>
        /// <returns>FileParameter</returns>
        FileParameter GetIPFSData(string id);
        /// <summary>
        /// Store data to IPFS
        /// </summary>
        /// <remarks>
        /// 2 credits per API call. Only files up to 50MB are available for storing. Stores file on the IPFS. We are leveraging nft.storage from Protocol Labs for free storage on the IPFS.
        /// </remarks>
        /// <exception cref="Tatum.CSharp.Bsc.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="file">Your file to store (optional)</param>
        /// <returns>IpfsResponse</returns>
        IpfsResponse StoreIPFS(FileParameter file = default(FileParameter));
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IIPFSApiWithHttpInfoSync : IApiAccessor
    {
        #region Synchronous Operations With Http Info
        /// <summary>
        /// Get file from IPFS
        /// </summary>
        /// <remarks>
        /// 1 credit per API call. Gets data from the IPFS.
        /// </remarks>
        /// <exception cref="Tatum.CSharp.Bsc.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">IPFS CID of the file</param>
        /// <returns>ApiResponse of FileParameter</returns>
        ApiResponse<FileParameter> GetIPFSDataWithHttpInfo(string id);
        /// <summary>
        /// Store data to IPFS
        /// </summary>
        /// <remarks>
        /// 2 credits per API call. Only files up to 50MB are available for storing. Stores file on the IPFS. We are leveraging nft.storage from Protocol Labs for free storage on the IPFS.
        /// </remarks>
        /// <exception cref="Tatum.CSharp.Bsc.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="file">Your file to store (optional)</param>
        /// <returns>ApiResponse of IpfsResponse</returns>
        ApiResponse<IpfsResponse> StoreIPFSWithHttpInfo(FileParameter file = default(FileParameter));
        #endregion Synchronous Operations With Http Info
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IIPFSApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Get file from IPFS
        /// </summary>
        /// <remarks>
        /// 1 credit per API call. Gets data from the IPFS.
        /// </remarks>
        /// <exception cref="Tatum.CSharp.Bsc.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">IPFS CID of the file</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of FileParameter</returns>
        System.Threading.Tasks.Task<FileParameter> GetIPFSDataAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Store data to IPFS
        /// </summary>
        /// <remarks>
        /// 2 credits per API call. Only files up to 50MB are available for storing. Stores file on the IPFS. We are leveraging nft.storage from Protocol Labs for free storage on the IPFS.
        /// </remarks>
        /// <exception cref="Tatum.CSharp.Bsc.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="file">Your file to store (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of IpfsResponse</returns>
        System.Threading.Tasks.Task<IpfsResponse> StoreIPFSAsync(FileParameter file = default(FileParameter), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IIPFSApiWithHttpInfoAsync : IApiAccessor
    {
        #region Asynchronous Operations With Http Info
        /// <summary>
        /// Get file from IPFS
        /// </summary>
        /// <remarks>
        /// 1 credit per API call. Gets data from the IPFS.
        /// </remarks>
        /// <exception cref="Tatum.CSharp.Bsc.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">IPFS CID of the file</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (FileParameter)</returns>
        System.Threading.Tasks.Task<ApiResponse<FileParameter>> GetIPFSDataWithHttpInfoAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Store data to IPFS
        /// </summary>
        /// <remarks>
        /// 2 credits per API call. Only files up to 50MB are available for storing. Stores file on the IPFS. We are leveraging nft.storage from Protocol Labs for free storage on the IPFS.
        /// </remarks>
        /// <exception cref="Tatum.CSharp.Bsc.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="file">Your file to store (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (IpfsResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<IpfsResponse>> StoreIPFSWithHttpInfoAsync(FileParameter file = default(FileParameter), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations With Http Info
    }


    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IIPFSApi : IIPFSApiSync, IIPFSApiWithHttpInfoSync, IIPFSApiAsync, IIPFSApiWithHttpInfoAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class IPFSApi : IIPFSApi
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="IPFSApi"/> class.
        /// </summary>
        /// <param name="client">An instance of HttpClient.</param>
        /// <param name="handler">An optional instance of HttpClientHandler that is used by HttpClient.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        /// <remarks>
        /// Some configuration settings will not be applied without passing an HttpClientHandler.
        /// The features affected are: Setting and Retrieving Cookies, Client Certificates, Proxy settings.
        /// </remarks>
        public IPFSApi(HttpClient client, HttpClientHandler handler = null) : this(client, (string)null, handler)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IPFSApi"/> class.
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
        public IPFSApi(HttpClient client, string basePath, HttpClientHandler handler = null)
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
        /// Initializes a new instance of the <see cref="IPFSApi"/> class using Configuration object.
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
        public IPFSApi(HttpClient client, Configuration configuration, HttpClientHandler handler = null)
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
        /// Initializes a new instance of the <see cref="IPFSApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public IPFSApi(ISynchronousClient client, IAsynchronousClient asyncClient, IReadableConfiguration configuration)
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
        /// Get file from IPFS 1 credit per API call. Gets data from the IPFS.
        /// </summary>
        /// <exception cref="Tatum.CSharp.Bsc.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">IPFS CID of the file</param>
        /// <returns>FileParameter</returns>
        public FileParameter GetIPFSData(string id)
        {
            var localVarResponse = GetIPFSDataWithHttpInfo(id);

            var exception = ExceptionFactory?.Invoke("GetIPFSData", localVarResponse);
            if (exception != null) throw exception;

            return localVarResponse.Data;
        }

        /// <summary>
        /// Get file from IPFS 1 credit per API call. Gets data from the IPFS.
        /// </summary>
        /// <exception cref="Tatum.CSharp.Bsc.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">IPFS CID of the file</param>
        /// <returns>ApiResponse of FileParameter</returns>
        public ApiResponse<FileParameter> GetIPFSDataWithHttpInfo(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling IPFSApi->GetIPFSData");

            var localVarRequestOptions = new RequestOptions();

            var contentTypes = new string[]{
            };

            // to determine the Accept header
            var accepts = new string[]{
                "*"
            };

            var localVarContentType = ClientUtils.SelectHeaderContentType(contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("id", ClientUtils.ParameterToString(id)); // path parameter

            // authentication (X-API-Key) required
            if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("x-api-key")))
            {
                localVarRequestOptions.HeaderParameters.Add("x-api-key", Configuration.GetApiKeyWithPrefix("x-api-key"));
            }

            // make the HTTP request
            var localVarResponse = Client.Get<FileParameter>("/v3/ipfs/{id}", localVarRequestOptions, Configuration);

            return localVarResponse;
        }

        /// <summary>
        /// Get file from IPFS 1 credit per API call. Gets data from the IPFS.
        /// </summary>
        /// <exception cref="Tatum.CSharp.Bsc.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">IPFS CID of the file</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of FileParameter</returns>
        public async System.Threading.Tasks.Task<FileParameter> GetIPFSDataAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            var localVarResponse = await GetIPFSDataWithHttpInfoAsync(id, cancellationToken).ConfigureAwait(false);
            
            var exception = ExceptionFactory?.Invoke("GetIPFSData", localVarResponse);
            if (exception != null) throw exception;

            return localVarResponse.Data;
        }

        /// <summary>
        /// Get file from IPFS 1 credit per API call. Gets data from the IPFS.
        /// </summary>
        /// <exception cref="Tatum.CSharp.Bsc.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">IPFS CID of the file</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (FileParameter)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<FileParameter>> GetIPFSDataWithHttpInfoAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling IPFSApi->GetIPFSData");

            var localVarRequestOptions = new RequestOptions();

            var contentTypes = new string[]{
            };

            // to determine the Accept header
            var accepts = new string[]{
                "*"
            };


            var localVarContentType = ClientUtils.SelectHeaderContentType(contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("id", ClientUtils.ParameterToString(id)); // path parameter

            // authentication (X-API-Key) required
            if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("x-api-key")))
            {
                localVarRequestOptions.HeaderParameters.Add("x-api-key", Configuration.GetApiKeyWithPrefix("x-api-key"));
            }

            // make the HTTP request

            var localVarResponse = await AsynchronousClient.GetAsync<FileParameter>("/v3/ipfs/{id}", localVarRequestOptions, Configuration, cancellationToken).ConfigureAwait(false);

            return localVarResponse;
        }

        /// <summary>
        /// Store data to IPFS 2 credits per API call. Only files up to 50MB are available for storing. Stores file on the IPFS. We are leveraging nft.storage from Protocol Labs for free storage on the IPFS.
        /// </summary>
        /// <exception cref="Tatum.CSharp.Bsc.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="file">Your file to store (optional)</param>
        /// <returns>IpfsResponse</returns>
        public IpfsResponse StoreIPFS(FileParameter file = default(FileParameter))
        {
            var localVarResponse = StoreIPFSWithHttpInfo(file);

            var exception = ExceptionFactory?.Invoke("StoreIPFS", localVarResponse);
            if (exception != null) throw exception;

            return localVarResponse.Data;
        }

        /// <summary>
        /// Store data to IPFS 2 credits per API call. Only files up to 50MB are available for storing. Stores file on the IPFS. We are leveraging nft.storage from Protocol Labs for free storage on the IPFS.
        /// </summary>
        /// <exception cref="Tatum.CSharp.Bsc.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="file">Your file to store (optional)</param>
        /// <returns>ApiResponse of IpfsResponse</returns>
        public ApiResponse<IpfsResponse> StoreIPFSWithHttpInfo(FileParameter file = default(FileParameter))
        {
            var localVarRequestOptions = new RequestOptions();

            var contentTypes = new string[]{
                "multipart/form-data"
            };

            // to determine the Accept header
            var accepts = new string[]{
                "application/json"
            };

            var localVarContentType = ClientUtils.SelectHeaderContentType(contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            if (file != null)
            {
                localVarRequestOptions.FileParameters.Add("file", file);
            }

            // authentication (X-API-Key) required
            if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("x-api-key")))
            {
                localVarRequestOptions.HeaderParameters.Add("x-api-key", Configuration.GetApiKeyWithPrefix("x-api-key"));
            }

            // make the HTTP request
            var localVarResponse = Client.Post<IpfsResponse>("/v3/ipfs", localVarRequestOptions, Configuration);

            return localVarResponse;
        }

        /// <summary>
        /// Store data to IPFS 2 credits per API call. Only files up to 50MB are available for storing. Stores file on the IPFS. We are leveraging nft.storage from Protocol Labs for free storage on the IPFS.
        /// </summary>
        /// <exception cref="Tatum.CSharp.Bsc.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="file">Your file to store (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of IpfsResponse</returns>
        public async System.Threading.Tasks.Task<IpfsResponse> StoreIPFSAsync(FileParameter file = default(FileParameter), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            var localVarResponse = await StoreIPFSWithHttpInfoAsync(file, cancellationToken).ConfigureAwait(false);
            
            var exception = ExceptionFactory?.Invoke("StoreIPFS", localVarResponse);
            if (exception != null) throw exception;

            return localVarResponse.Data;
        }

        /// <summary>
        /// Store data to IPFS 2 credits per API call. Only files up to 50MB are available for storing. Stores file on the IPFS. We are leveraging nft.storage from Protocol Labs for free storage on the IPFS.
        /// </summary>
        /// <exception cref="Tatum.CSharp.Bsc.Core.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="file">Your file to store (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (IpfsResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<IpfsResponse>> StoreIPFSWithHttpInfoAsync(FileParameter file = default(FileParameter), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            var localVarRequestOptions = new RequestOptions();

            var contentTypes = new string[]{
                "multipart/form-data"
            };

            // to determine the Accept header
            var accepts = new string[]{
                "application/json"
            };


            var localVarContentType = ClientUtils.SelectHeaderContentType(contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            if (file != null)
            {
                localVarRequestOptions.FileParameters.Add("file", file);
            }

            // authentication (X-API-Key) required
            if (!string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("x-api-key")))
            {
                localVarRequestOptions.HeaderParameters.Add("x-api-key", Configuration.GetApiKeyWithPrefix("x-api-key"));
            }

            // make the HTTP request

            var localVarResponse = await AsynchronousClient.PostAsync<IpfsResponse>("/v3/ipfs", localVarRequestOptions, Configuration, cancellationToken).ConfigureAwait(false);

            return localVarResponse;
        }

    }
}

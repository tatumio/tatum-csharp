using System;
using System.Net.Http;
using Tatum.CSharp.Ipfs.Configuration;
using Tatum.CSharp.Ipfs.Core.Api;

namespace Tatum.CSharp.Ipfs.Clients
{
    public class IpfsClient : IIpfsClient
    {
        /// <inheritdoc />
        public IIPFSApiAsync Ipfs { get; }
        
        /// <inheritdoc />
        public IIPFSApiWithHttpInfoAsync IpfsWithHttpInfo { get; }
        
        /// <summary>
        /// Creates an instance of <see cref="IpfsClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="optionsFunc">Configuration options func.</param>
        public IpfsClient(HttpClient httpClient, Func<IpfsClientOptions, IpfsClientOptions> optionsFunc) 
            : this(httpClient, optionsFunc(new IpfsClientOptions()))
        {
        }
        
        /// <summary>
        /// Creates an instance of <see cref="IpfsClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="options">Configuration options.</param>
        public IpfsClient(HttpClient httpClient, IpfsClientOptions options) 
            : this(httpClient, options.ApiKey, options.IsTestnet)
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="IpfsClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="apiKey">Api key that will be used when calling Tatum API.</param>
        public IpfsClient(HttpClient httpClient, string apiKey) 
            : this(httpClient, apiKey, false)
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="IpfsClient"/>.
        /// </summary>
        /// <param name="httpClient"><see cref="HttpClient"/> Instance that should preferably be managed by HttpClient Factory.</param>
        /// <param name="apiKey">Api key that will be used when calling Tatum API.</param>
        /// <param name="isTestNet">Value indicating weather Local services should generate values for Testnet.</param>
        public IpfsClient(HttpClient httpClient, string apiKey, bool isTestNet)
        {
            var configuration = new Core.Client.Configuration();
            configuration.ApiKey.Add("x-api-key", apiKey);
            
            var ipfsApi = new IPFSApi(httpClient, configuration);
            
            
            Ipfs = ipfsApi;
            IpfsWithHttpInfo = ipfsApi;
        }
    }
}
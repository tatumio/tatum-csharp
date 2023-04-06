using System.Collections.Generic;
using System.Net.Http;
using Polly.Retry;
using Tatum.Core.Models;

namespace Tatum.Core.Configuration
{
    public interface ITatumSdkConfiguration
    {
        Network Network { get; set; }
        string BaseUrl { get; set; }
        string ApiKey { get; set; }
        string Version { get; set; }
        bool EnableDebugMode { get; set; }
        AsyncRetryPolicy<HttpResponseMessage> RetryPolicy { get; set; }

        IRpcConfiguration Rpc { get; set; }
    }

    public interface IRpcConfiguration
    {
        /// <summary>
        /// How many blocks behind the head of the blockchain to tolerate before considering the node to be unhealthy. Defaults to `0`.
        /// </summary>
        int AllowedBlocksBehind { get; set; }

        /// <summary>
        /// In case this is set to `true`, the SDK will use list of provided URL addresses from the configuration instead of OpenRCP ones. Defaults to `false`.
        /// </summary>
        bool UseStaticUrls { get; set; }

        /// <summary>
        /// In case this is set to `true`, the SDK will not automatically load balance and failover between available nodes and will use fixed first available URL. Defaults to `false`.
        /// </summary>
        bool IgnoreLoadBalancing { get; set; }

        /// <summary>
        /// Wait for the load balance check to find the nearest node during the initialization. Defaults to `false`.
        /// </summary>
        bool WaitForFastestNode { get; set; }

        /// <summary>
        /// If this is set to `true`, the SDK will not automatically load balance and failover between the available OpenRPC nodes and will use the fastest URL fetched during the startup. Defaults to `false`.
        /// </summary>
        bool OneTimeLoadBalancing { get; set; }

        /// <summary>
        /// In case this url is set, all the requests to Bitcoin will be proxied to this url without automatic load balancing and failover. For now, only first elements of the array is used as a default URL.
        /// </summary>
        IBlockchainConfig Bitcoin { get; set; }

        /// <summary>
        /// In case this url is set, all the requests to Litecoin will be proxied to this url without automatic load balancing and failover. For now, only first elements of the array is used as a default URL.
        /// </summary>
        IBlockchainConfig Litecoin { get; set; }

        /// <summary>
        /// In case this url is set, all the requests to Ethereum will be proxied to this url without automatic load balancing and failover. For now, only first elements of the array is used as a default URL.
        /// </summary>
        IBlockchainConfig Ethereum { get; set; }

        /// <summary>
        /// In case this url is set, all the requests to Polygon will be proxied to this url without automatic load balancing and failover. For now, only first elements of the array is used as a default URL.
        /// </summary>
        IBlockchainConfig Polygon { get; set; }

        /// <summary>
        /// In case this url is set, all the requests to Monero will be proxied to this url without automatic load balancing and failover. For now, only first elements of the array is used as a default URL.
        /// </summary>
        IBlockchainConfig Monero { get; set; }
    }

    public interface IBlockchainConfig
    {
        /// <summary>
        /// URL(s) for the specific blockchain.
        /// </summary>
        List<string> Url { get; set; }
    }
}
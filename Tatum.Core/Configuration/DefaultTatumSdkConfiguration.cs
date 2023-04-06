using System;
using System.Collections.Generic;
using System.Net.Http;
using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Extensions.Http;
using Polly.Retry;
using Tatum.Core.Models;

namespace Tatum.Core.Configuration
{
    public class DefaultTatumSdkConfiguration : ITatumSdkConfiguration
    {
        public DefaultTatumSdkConfiguration()
        {
            Network = Network.Mainnet;
            BaseUrl = TatumConstants.BaseUrl;
            ApiKey = null;
            EnableDebugMode = false;
            RetryPolicy = Policy<HttpResponseMessage>.Handle<HttpRequestException>().OrTransientHttpStatusCode().WaitAndRetryAsync(Backoff.DecorrelatedJitterBackoffV2(TimeSpan.FromSeconds(1), 3));
            Rpc = new DefaultRpcConfiguration();
        }

        public Network Network { get; set; }
        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }
        public string Version { get; set; }
        public bool EnableDebugMode { get; set; }
        public AsyncRetryPolicy<HttpResponseMessage> RetryPolicy { get; set; }
        public IRpcConfiguration Rpc { get; set; }
    }

    public class DefaultRpcConfiguration : IRpcConfiguration
    {
        public int AllowedBlocksBehind { get; set; } = 0;
        public bool UseStaticUrls { get; set; } = false;
        public bool IgnoreLoadBalancing { get; set; } = false;
        public bool WaitForFastestNode { get; set; } = false;
        public bool OneTimeLoadBalancing { get; set; } = false;
        public IBlockchainConfig Bitcoin { get; set; } = new DefaultBitcoinConfig();
        public IBlockchainConfig Litecoin { get; set; } = new DefaultBitcoinConfig();
        public IBlockchainConfig Ethereum { get; set; } = new DefaultBitcoinConfig();
        public IBlockchainConfig Polygon { get; set; } = new DefaultBitcoinConfig();
        public IBlockchainConfig Monero { get; set; } = new DefaultBitcoinConfig();
    }

    public class DefaultBitcoinConfig : IBlockchainConfig
    {
        public List<string> Url { get; set; } = new List<string>();
    }
}
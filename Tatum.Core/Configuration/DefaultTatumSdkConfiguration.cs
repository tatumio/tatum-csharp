using System;
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
        }

        public Network Network { get; set; }
        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }
        public string Version { get; set; }
        public bool EnableDebugMode { get; set; }
        public AsyncRetryPolicy<HttpResponseMessage> RetryPolicy { get; set; }
    }
}
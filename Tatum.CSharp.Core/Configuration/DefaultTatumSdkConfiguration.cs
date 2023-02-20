using System;
using System.Net.Http;
using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Extensions.Http;
using Tatum.CSharp.Core.Models;

namespace Tatum.CSharp.Core.Configuration
{
    public class DefaultTatumSdkConfiguration : TatumSdkConfiguration
    {
        public DefaultTatumSdkConfiguration()
        {
            Network = Network.Mainnet;
            BaseUrl = TatumConstants.BaseUrl;
            ApiKey = null;
            RetryPolicy = Policy<HttpResponseMessage>.Handle<HttpRequestException>().OrTransientHttpStatusCode().WaitAndRetryAsync(Backoff.DecorrelatedJitterBackoffV2(TimeSpan.FromSeconds(1), 3));
        }
    }
}
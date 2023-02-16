using System;
using System.Net.Http;
using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Extensions.Http;

namespace Tatum.CSharp.Core.Configuration
{
    public class DefaultTatumSdkConfiguration : TatumSdkConfiguration
    {
        public DefaultTatumSdkConfiguration()
        {
            IsTestnet = false;
            BaseUrl = TatumConstants.BaseUrl;
            ApiKey = null;
            RetryPolicy = Policy<HttpResponseMessage>.Handle<HttpRequestException>().OrTransientHttpStatusCode().WaitAndRetryAsync(Backoff.DecorrelatedJitterBackoffV2(TimeSpan.FromSeconds(1), 3));
        }
    }
}
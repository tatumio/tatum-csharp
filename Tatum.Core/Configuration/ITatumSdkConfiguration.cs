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
    }
}
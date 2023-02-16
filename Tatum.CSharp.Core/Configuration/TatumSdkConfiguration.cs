using System.Net.Http;
using Polly.Retry;

namespace Tatum.CSharp.Core.Configuration
{
    public class TatumSdkConfiguration
    {
        public bool IsTestnet { get; set; }
        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }
        
        public AsyncRetryPolicy<HttpResponseMessage> RetryPolicy { get; set; }

    }
}
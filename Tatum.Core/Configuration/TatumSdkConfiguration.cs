using System.Net.Http;
using Polly.Retry;
using Tatum.Core.Models;

namespace Tatum.Core.Configuration
{
    public class TatumSdkConfiguration
    {
        public Network Network { get; set; }
        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }
        public string Version { get; set; }
        
        public AsyncRetryPolicy<HttpResponseMessage> RetryPolicy { get; set; }

    }
}
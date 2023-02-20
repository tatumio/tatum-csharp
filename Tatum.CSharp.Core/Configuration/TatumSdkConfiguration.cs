using System.Net.Http;
using Polly.Retry;
using Tatum.CSharp.Core.Models;

namespace Tatum.CSharp.Core.Configuration
{
    public class TatumSdkConfiguration
    {
        public Network Network { get; set; }
        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }
        
        public AsyncRetryPolicy<HttpResponseMessage> RetryPolicy { get; set; }

    }
}
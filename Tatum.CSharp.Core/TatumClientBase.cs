using System.Net.Http;
using Tatum.CSharp.Core.Configuration;

namespace Tatum.CSharp.Core
{
    public abstract class TatumClientBase
    {
        private readonly HttpClient _httpClient;
        private readonly TatumSdkConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        protected TatumClientBase(HttpClient httpClient, TatumSdkConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        protected TatumClientBase(IHttpClientFactory httpClientFactory, TatumSdkConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        protected HttpClient GetClient()
        {
            if (_httpClientFactory == null)
            {
                return _httpClient;
            }
            
            var client = _httpClientFactory.CreateClient(TatumConstants.TatumHttpClientName);

            _configuration.ConfigureHttpClient(client);
                
            return client;
        }
    }
}
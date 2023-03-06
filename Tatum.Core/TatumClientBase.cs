using System.Net.Http;
using Tatum.Core.Configuration;

namespace Tatum.Core
{
    public abstract class TatumClientBase
    {
        private readonly HttpClient _httpClient;
        private readonly ITatumSdkConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        protected TatumClientBase(HttpClient httpClient, ITatumSdkConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        protected TatumClientBase(IHttpClientFactory httpClientFactory, ITatumSdkConfiguration configuration)
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
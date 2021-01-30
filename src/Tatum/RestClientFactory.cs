using Refit;
using System;
using System.Net.Http;
using System.Text.Json;

namespace Tatum
{
    public static class RestClientFactory
    {
        public static TInterface Create<TInterface>(string apiBaseUrl, string xApiKey)
        {
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                IgnoreNullValues = true
            };

            var refitSettings = new RefitSettings(new SystemTextJsonContentSerializer(jsonSerializerOptions));

            var httpClient = new HttpClient(new TatumHttpClientHandler(xApiKey))
            {
                BaseAddress = new Uri(apiBaseUrl)
            };

            return RestService.For<TInterface>(httpClient, refitSettings);
        }

        public static TInterface Create<TInterface>(string apiBaseUrl)
        {
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                IgnoreNullValues = true
            };

            var refitSettings = new RefitSettings(new SystemTextJsonContentSerializer(jsonSerializerOptions));

            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(apiBaseUrl)
            };

            return RestService.For<TInterface>(httpClient, refitSettings);
        }
    }
}

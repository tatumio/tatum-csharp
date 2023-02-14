using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Tatum.CSharp.Core.Exceptions;
using Tatum.CSharp.Core.Models.Responses;
using Tatum.CSharp.Core.Serialization;

namespace Tatum.CSharp.Core.Configuration
{
    public static class ConfigurationExtensions
    {
        public static void ConfigureHttpClient(this TatumSdkConfiguration configuration, HttpClient client)
        {
            client.BaseAddress = new Uri(configuration.BaseUrl);
            if(configuration.ApiKey != null)
            {
                client.DefaultRequestHeaders.Add("x-api-key", configuration.ApiKey);
            }
        }
        
        public static async Task Validate(this TatumSdkConfiguration configuration, HttpClient client)
        {
            if(string.IsNullOrWhiteSpace(configuration.ApiKey))
            {
                return;
            }
            
            client.BaseAddress = new Uri(configuration.BaseUrl);
            client.DefaultRequestHeaders.Add("x-api-key", configuration.ApiKey);
            
            var versionResponse = await client.GetFromJsonAsync<VersionResponse>("v3/tatum/version/", TatumSerializerOptions.Default);

            if (versionResponse == null)
            {
                throw new ValidateSdkException("Tatum API is not available, could not connect to check version.");
            }
            
            if(versionResponse.Testnet != configuration.IsTestnet)
            {
                throw new InvalidOperationException("Testnet configuration does not match the testnet status of the Tatum API key.");
            }
        }
        
        public static async Task Validate(this TatumSdkConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            var client = httpClientFactory.CreateClient(TatumConstants.TatumHttpClientName);
            await configuration.Validate(client);
        }
    }
}
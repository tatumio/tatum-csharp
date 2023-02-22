using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Tatum.CSharp.Core.Exceptions;
using Tatum.CSharp.Core.Models;
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
            client.DefaultRequestHeaders.Add("User-Agent", "Tatum_SDK_CSharp/3.0.0");
        }
        
        public static async Task Validate(this TatumSdkConfiguration configuration, HttpClient client)
        {
            if(string.IsNullOrWhiteSpace(configuration.ApiKey))
            {
                return;
            }

            var versionResponse = await client.GetFromJsonAsync<VersionResponse>("v1/tatum/version", TatumSerializerOptions.Default).ConfigureAwait(false);

            if (versionResponse == null)
            {
                throw new ValidateSdkException("Tatum API is not available, could not connect to check version.");
            }
            
            if(versionResponse.Testnet && configuration.Network == Network.Mainnet)
            {
                throw new InvalidOperationException("Tatum API key is not valid for Testnet.");
            }
            
            if(!versionResponse.Testnet && configuration.Network == Network.Testnet)
            {
                throw new InvalidOperationException("Tatum API key is not valid for Mainnet.");
            }
        }
    }
}
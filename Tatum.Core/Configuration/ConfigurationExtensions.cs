using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Sockets;
using System.Threading.Tasks;
using Tatum.Core.Exceptions;
using Tatum.Core.Models;
using Tatum.Core.Models.Responses;
using Tatum.Core.Serialization;

namespace Tatum.Core.Configuration
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

            client.DefaultRequestHeaders.Add("User-Agent", $"Tatum_SDK_CSharp/{configuration.Version}");
            client.DefaultRequestHeaders.Add("cf-connecting-ip", GetExternalIPAddress().GetAwaiter().GetResult());
        }
        
        private static async Task<string> GetExternalIPAddress()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://api.ipify.org");
                var ipAddress = await response.Content.ReadAsStringAsync();
                return ipAddress;
            }
        }
        
        public static async Task Validate(this TatumSdkConfiguration configuration, HttpClient client)
        {
            if(string.IsNullOrWhiteSpace(configuration.ApiKey))
            {
                return;
            }

            VersionResponse versionResponse;
            
            try
            {
                versionResponse = await client.GetFromJsonAsync<VersionResponse>("v1/tatum/version", TatumSerializerOptions.Default).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                throw new ValidateSdkException($"Unable to initialize Tatum SDK, Tatum API not available: {e.Message}", e);
            }

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
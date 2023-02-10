using System;
using System.Net.Http;

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
    }
}
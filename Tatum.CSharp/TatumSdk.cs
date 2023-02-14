using System.Net.Http;
using Tatum.CSharp.Core.Configuration;
using Tatum.CSharp.Notifications;

namespace Tatum.CSharp
{
    public class TatumSdk : ITatumSdk
    {
        public ITatumNotifications Notifications { get; }

        private TatumSdk(HttpClient httpClient, TatumSdkConfiguration configuration)
        {
            configuration.ConfigureHttpClient(httpClient);
            
            Notifications = new TatumNotifications(httpClient, configuration);
        }
        
        private TatumSdk(IHttpClientFactory httpClientFactory, TatumSdkConfiguration configuration)
        {
            Notifications = new TatumNotifications(httpClientFactory, configuration);
        }
        
        public static TatumSdk Init(TatumSdkConfiguration configuration = null)
        {
            return Init(false, (string)null, configuration);
        }
        
        public static TatumSdk Init(string apiKey, TatumSdkConfiguration configuration = null)
        {
            return Init(false, apiKey, configuration);
        }
        
        public static TatumSdk Init(bool isTestnet, TatumSdkConfiguration configuration = null)
        {
            return Init(isTestnet, (string)null, configuration);
        }
        
        public static TatumSdk Init(bool isTestnet, string apiKey, TatumSdkConfiguration configuration = null)
        {
            if(configuration == null)
            {
                configuration = new DefaultTatumSdkConfiguration();
            }
            
            configuration.IsTestnet = isTestnet;
            configuration.ApiKey = apiKey;

            return new TatumSdk(new HttpClient(), configuration);
        }
        
        public static TatumSdk Init(HttpClient client, TatumSdkConfiguration configuration = null)
        {
            return Init(false, null, client, configuration);
        }
        
        public static TatumSdk Init(string apiKey, HttpClient client, TatumSdkConfiguration configuration = null)
        {
            return Init(false, apiKey, client, configuration);
        }
        
        public static TatumSdk Init(bool isTestnet, HttpClient client, TatumSdkConfiguration configuration = null)
        {
            return Init(isTestnet, null, client, configuration);
        }
        
        public static TatumSdk Init(bool isTestnet, string apiKey, HttpClient client, TatumSdkConfiguration configuration = null)
        {
            if(configuration == null)
            {
                configuration = new DefaultTatumSdkConfiguration();
            }
            
            configuration.IsTestnet = isTestnet;
            configuration.ApiKey = apiKey;

            configuration.Validate(client).GetAwaiter().GetResult();

            return new TatumSdk(client, configuration);
        }
        
        public static TatumSdk Init(IHttpClientFactory httpClientFactory, TatumSdkConfiguration configuration = null)
        {
            return Init(false, null, httpClientFactory, configuration);
        }
        
        public static TatumSdk Init(string apiKey, IHttpClientFactory httpClientFactory, TatumSdkConfiguration configuration = null)
        {
            return Init(false, apiKey, httpClientFactory, configuration);
        }
        
        public static TatumSdk Init(bool isTestnet, IHttpClientFactory httpClientFactory, TatumSdkConfiguration configuration = null)
        {
            return Init(isTestnet, null, httpClientFactory, configuration);
        }
        
        public static TatumSdk Init(bool isTestnet, string apiKey, IHttpClientFactory httpClientFactory, TatumSdkConfiguration configuration = null)
        {
            if(configuration == null)
            {
                configuration = new DefaultTatumSdkConfiguration();
            }
            
            configuration.IsTestnet = isTestnet;
            configuration.ApiKey = apiKey;
            
            configuration.Validate(httpClientFactory).GetAwaiter().GetResult();

            return new TatumSdk(httpClientFactory, configuration);
        }
    }
}
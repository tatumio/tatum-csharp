using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Tatum.CSharp.Core;
using Tatum.CSharp.Core.Configuration;
using Tatum.CSharp.Core.Models;
using Tatum.CSharp.Notifications;

namespace Tatum.CSharp
{
    public class TatumSdk : ITatumSdk
    {
        public ITatumNotifications Notifications { get; }

        private TatumSdk(HttpClient httpClient, TatumSdkConfiguration configuration)
        {
            Notifications = new TatumNotifications(httpClient, configuration);
        }
        
        private TatumSdk(IHttpClientFactory httpClientFactory, TatumSdkConfiguration configuration)
        {
            Notifications = new TatumNotifications(httpClientFactory, configuration);
        }
        
        public static TatumSdk Init(TatumSdkConfiguration configuration = null)
        {
            return Init(Network.Mainnet, (string)null, configuration);
        }
        
        public static TatumSdk Init(string apiKey, TatumSdkConfiguration configuration = null)
        {
            return Init(Network.Mainnet, apiKey, configuration);
        }
        
        public static TatumSdk Init(Network network, TatumSdkConfiguration configuration = null)
        {
            return Init(network, (string)null, configuration);
        }
        
        public static TatumSdk Init(Network network, string apiKey, TatumSdkConfiguration configuration = null)
        {
            return Init(network, apiKey, new HttpClient(), configuration);
        }
        
        public static TatumSdk Init(HttpClient client, TatumSdkConfiguration configuration = null)
        {
            return Init(Network.Mainnet, null, client, configuration);
        }
        
        public static TatumSdk Init(string apiKey, HttpClient client, TatumSdkConfiguration configuration = null)
        {
            return Init(Network.Mainnet, apiKey, client, configuration);
        }
        
        public static TatumSdk Init(Network network, HttpClient client, TatumSdkConfiguration configuration = null)
        {
            return Init(network, null, client, configuration);
        }
        
        public static TatumSdk Init(Network network, string apiKey, HttpClient client, TatumSdkConfiguration configuration = null)
        {
            configuration = ResolveConfiguration(network, apiKey, configuration);
            
            configuration.ConfigureHttpClient(client);
            
            configuration.Validate(client).GetAwaiter().GetResult();

            return new TatumSdk(client, configuration);
        }
        
        public static TatumSdk Init(IHttpClientFactory httpClientFactory, TatumSdkConfiguration configuration = null)
        {
            return Init(Network.Mainnet, null, httpClientFactory, configuration);
        }
        
        public static TatumSdk Init(string apiKey, IHttpClientFactory httpClientFactory, TatumSdkConfiguration configuration = null)
        {
            return Init(Network.Mainnet, apiKey, httpClientFactory, configuration);
        }
        
        public static TatumSdk Init(Network network, IHttpClientFactory httpClientFactory, TatumSdkConfiguration configuration = null)
        {
            return Init(network, null, httpClientFactory, configuration);
        }
        
        public static TatumSdk Init(Network network, string apiKey, IHttpClientFactory httpClientFactory, TatumSdkConfiguration configuration = null)
        {
            configuration = ResolveConfiguration(network, apiKey, configuration);
            
            var httpClient = httpClientFactory.CreateClient(TatumConstants.TatumHttpClientName);
            
            configuration.ConfigureHttpClient(httpClient);
            
            configuration.Validate(httpClient).GetAwaiter().GetResult();

            return new TatumSdk(httpClientFactory, configuration);
        }
        
        public static async Task<TatumSdk> InitAsync(TatumSdkConfiguration configuration = null)
        {
            return await InitAsync(Network.Mainnet, (string)null, configuration).ConfigureAwait(false);
        }
        
        public static async Task<TatumSdk> InitAsync(string apiKey, TatumSdkConfiguration configuration = null)
        {
            return await InitAsync(Network.Mainnet, apiKey, configuration).ConfigureAwait(false);
        }
        
        public static async Task<TatumSdk> InitAsync(Network network, TatumSdkConfiguration configuration = null)
        {
            return await InitAsync(network, (string)null, configuration).ConfigureAwait(false);
        }
        
        public static async Task<TatumSdk> InitAsync(Network network, string apiKey, TatumSdkConfiguration configuration = null)
        {
            return await InitAsync(network, apiKey, new HttpClient(), configuration).ConfigureAwait(false);
        }
        
        public static async Task<TatumSdk> InitAsync(HttpClient client, TatumSdkConfiguration configuration = null)
        {
            return await InitAsync(Network.Mainnet, null, client, configuration).ConfigureAwait(false);
        }
        
        public static async Task<TatumSdk> InitAsync(string apiKey, HttpClient client, TatumSdkConfiguration configuration = null)
        {
            return await InitAsync(Network.Mainnet, apiKey, client, configuration).ConfigureAwait(false);
        }
        
        public static async Task<TatumSdk> InitAsync(Network network, HttpClient client, TatumSdkConfiguration configuration = null)
        {
            return await InitAsync(network, null, client, configuration).ConfigureAwait(false);
        }
        
        public static async Task<TatumSdk> InitAsync(Network network, string apiKey, HttpClient client, TatumSdkConfiguration configuration = null)
        {
            configuration = ResolveConfiguration(network, apiKey, configuration);

            configuration.ConfigureHttpClient(client);
            
            await configuration.Validate(client).ConfigureAwait(false);

            return new TatumSdk(client, configuration);
        }
        
        public static async Task<TatumSdk> InitAsync(IHttpClientFactory httpClientFactory, TatumSdkConfiguration configuration = null)
        {
            return await InitAsync(Network.Mainnet, null, httpClientFactory, configuration).ConfigureAwait(false);
        }
        
        public static async Task<TatumSdk> InitAsync(string apiKey, IHttpClientFactory httpClientFactory, TatumSdkConfiguration configuration = null)
        {
            return await InitAsync(Network.Mainnet, apiKey, httpClientFactory, configuration).ConfigureAwait(false);
        }
        
        public static async Task<TatumSdk> InitAsync(Network network, IHttpClientFactory httpClientFactory, TatumSdkConfiguration configuration = null)
        {
            return await InitAsync(network, null, httpClientFactory, configuration).ConfigureAwait(false);
        }
        
        public static async Task<TatumSdk> InitAsync(Network network, string apiKey, IHttpClientFactory httpClientFactory, TatumSdkConfiguration configuration = null)
        {
            configuration = ResolveConfiguration(network, apiKey, configuration);

            var httpClient = httpClientFactory.CreateClient(TatumConstants.TatumHttpClientName);
            
            configuration.ConfigureHttpClient(httpClient);
            
            await configuration.Validate(httpClient).ConfigureAwait(false);

            return new TatumSdk(httpClientFactory, configuration);
        }

        private static TatumSdkConfiguration ResolveConfiguration(Network network, string apiKey,
            TatumSdkConfiguration configuration)
        {
            if (configuration == null)
            {
                configuration = new DefaultTatumSdkConfiguration();
            }

            configuration.Network = network;
            configuration.ApiKey = apiKey;
            
            configuration.Version = GetVersion();

            return configuration;
        }

        private static string GetVersion()
        {
            const string versionLocation = "Tatum.CSharp..version";
            
            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream(versionLocation);
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}
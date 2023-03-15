using System;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Http;
using Tatum.Core;
using Tatum.Core.Configuration;
using Tatum.Core.Handlers;
using Tatum.Core.Models;
using Tatum.Notifications;
using Tatum.Utils.DebugMode;

namespace Tatum
{
    public class TatumSdk : ITatumSdk
    {
        public ITatumNotifications Notifications { get; }

        private TatumSdk(HttpClient httpClient, ITatumSdkConfiguration configuration)
        {
            Notifications = new TatumNotifications(httpClient, configuration);
        }
        
        private TatumSdk(IHttpClientFactory httpClientFactory, ITatumSdkConfiguration configuration)
        {
            Notifications = new TatumNotifications(httpClientFactory, configuration);
        }
        
        public static TatumSdk Init()
        {
            return Init(Network.Mainnet, (string)null, (ITatumSdkConfiguration)null);
        }
        
        public static TatumSdk Init(ITatumSdkConfiguration configuration)
        {
            return Init(Network.Mainnet, (string)null, configuration);
        }
        
        public static TatumSdk Init(Action<ITatumSdkConfiguration> configurationAction)
        {
            return Init(Network.Mainnet, (string)null, configurationAction);
        }
        
        public static TatumSdk Init(string apiKey)
        {
            return Init(Network.Mainnet, apiKey, (ITatumSdkConfiguration)null);
        }
        
        public static TatumSdk Init(string apiKey, ITatumSdkConfiguration configuration)
        {
            return Init(Network.Mainnet, apiKey, configuration);
        }
        
        public static TatumSdk Init(string apiKey, Action<ITatumSdkConfiguration> configurationAction)
        {
            return Init(Network.Mainnet, apiKey, configurationAction);
        }
        
        public static TatumSdk Init(Network network)
        {
            return Init(network, (string)null, (ITatumSdkConfiguration)null);
        }
        
        public static TatumSdk Init(Network network, ITatumSdkConfiguration configuration)
        {
            return Init(network, (string)null, configuration);
        }
        
        public static TatumSdk Init(Network network, Action<ITatumSdkConfiguration> configurationAction)
        {
            return Init(network, (string)null, configurationAction);
        }

        public static TatumSdk Init(Network network, string apiKey)
        {
            return Init(network, apiKey, (ITatumSdkConfiguration)null);
        }
        
        public static TatumSdk Init(Network network, string apiKey, Action<ITatumSdkConfiguration> configurationAction)
        {
            ITatumSdkConfiguration configuration = null;
            
            if (configurationAction != null)
            {
                configuration = new DefaultTatumSdkConfiguration();
            
                configurationAction(configuration);
            }

            return Init(network, apiKey, configuration);
        }
        
        public static TatumSdk Init(Network network, string apiKey, ITatumSdkConfiguration configuration)
        {
            configuration = ResolveConfiguration(network, apiKey, configuration);

            var delegatingHandler = PrepareDelegatingHandler(configuration);

            var client = new HttpClient(delegatingHandler);

            configuration.ConfigureHttpClient(client);
            
            configuration.Validate(client).GetAwaiter().GetResult();

            return new TatumSdk(client, configuration);
        }

        public static TatumSdk Init(IHttpClientFactory httpClientFactory)
        {
            return Init(Network.Mainnet, null, httpClientFactory, (ITatumSdkConfiguration)null);
        }

        public static TatumSdk Init(IHttpClientFactory httpClientFactory, ITatumSdkConfiguration configuration )
        {
            return Init(Network.Mainnet, null, httpClientFactory, configuration);
        }

        public static TatumSdk Init(IHttpClientFactory httpClientFactory, Action<ITatumSdkConfiguration> configurationAction)
        {
            return Init(Network.Mainnet, null, httpClientFactory, configurationAction);
        }

        public static TatumSdk Init(string apiKey, IHttpClientFactory httpClientFactory)
        {
            return Init(Network.Mainnet, apiKey, httpClientFactory, (ITatumSdkConfiguration)null);
        }

        public static TatumSdk Init(Network network, IHttpClientFactory httpClientFactory)
        {
            return Init(network, null, httpClientFactory, (ITatumSdkConfiguration)null);
        }

        public static TatumSdk Init(string apiKey, IHttpClientFactory httpClientFactory, ITatumSdkConfiguration configuration)
        {
            return Init(Network.Mainnet, apiKey, httpClientFactory, configuration);
        }

        public static TatumSdk Init(Network network, IHttpClientFactory httpClientFactory, ITatumSdkConfiguration configuration)
        {
            return Init(network, null, httpClientFactory, configuration);
        }

        public static TatumSdk Init(string apiKey, IHttpClientFactory httpClientFactory, Action<ITatumSdkConfiguration> configurationAction)
        {
            return Init(Network.Mainnet, apiKey, httpClientFactory, configurationAction);
        }

        public static TatumSdk Init(Network network, IHttpClientFactory httpClientFactory, Action<ITatumSdkConfiguration> configurationAction)
        {
            return Init(network, null, httpClientFactory, configurationAction);
        }

        public static TatumSdk Init(Network network, string apiKey, IHttpClientFactory httpClientFactory)
        {
            return Init(network, apiKey, httpClientFactory, (ITatumSdkConfiguration)null);
        }

        public static TatumSdk Init(Network network, string apiKey, IHttpClientFactory httpClientFactory, Action<ITatumSdkConfiguration> configurationAction)
        {
            ITatumSdkConfiguration configuration = null;
            
            if (configurationAction != null)
            {
                configuration = new DefaultTatumSdkConfiguration();
            
                configurationAction(configuration);
            }

            return Init(network, apiKey, httpClientFactory, configuration);
        }

        public static TatumSdk Init(Network network, string apiKey, IHttpClientFactory httpClientFactory, ITatumSdkConfiguration configuration)
        {
            configuration = ResolveConfiguration(network, apiKey, configuration);
            
            var httpClient = httpClientFactory.CreateClient(TatumConstants.TatumHttpClientName);
            
            configuration.ConfigureHttpClient(httpClient);
            
            configuration.Validate(httpClient).GetAwaiter().GetResult();

            return new TatumSdk(httpClientFactory, configuration);
        }

        public static async Task<TatumSdk> InitAsync()
        {
            return await InitAsync(Network.Mainnet, (string)null, (ITatumSdkConfiguration)null).ConfigureAwait(false);
        }

        public static async Task<TatumSdk> InitAsync(string apiKey)
        {
            return await InitAsync(Network.Mainnet, apiKey, (ITatumSdkConfiguration)null).ConfigureAwait(false);
        }

        public static async Task<TatumSdk> InitAsync(Network network)
        {
            return await InitAsync(network, (string)null, (ITatumSdkConfiguration)null).ConfigureAwait(false);
        }

        public static async Task<TatumSdk> InitAsync(Network network, string apiKey)
        {
            return await InitAsync(network, apiKey, (ITatumSdkConfiguration)null).ConfigureAwait(false);
        }

        public static async Task<TatumSdk> InitAsync(ITatumSdkConfiguration configuration)
        {
            return await InitAsync(Network.Mainnet, (string)null, configuration).ConfigureAwait(false);
        }

        public static async Task<TatumSdk> InitAsync(string apiKey, ITatumSdkConfiguration configuration)
        {
            return await InitAsync(Network.Mainnet, apiKey, configuration).ConfigureAwait(false);
        }

        public static async Task<TatumSdk> InitAsync(Network network, ITatumSdkConfiguration configuration)
        {
            return await InitAsync(network, (string)null, configuration).ConfigureAwait(false);
        }

        public static async Task<TatumSdk> InitAsync(Action<ITatumSdkConfiguration> configurationAction)
        {
            return await InitAsync(Network.Mainnet, (string)null, configurationAction).ConfigureAwait(false);
        }

        public static async Task<TatumSdk> InitAsync(string apiKey, Action<ITatumSdkConfiguration> configurationAction)
        {
            return await InitAsync(Network.Mainnet, apiKey, configurationAction).ConfigureAwait(false);
        }

        public static async Task<TatumSdk> InitAsync(Network network, Action<ITatumSdkConfiguration> configurationAction)
        {
            return await InitAsync(network, (string)null, configurationAction).ConfigureAwait(false);
        }

        public static async Task<TatumSdk> InitAsync(Network network, string apiKey, Action<ITatumSdkConfiguration> configurationAction)
        {
            ITatumSdkConfiguration configuration = null;
            
            if (configurationAction != null)
            {
                configuration = new DefaultTatumSdkConfiguration();
            
                configurationAction(configuration);
            }

            return await InitAsync(network, apiKey, configuration).ConfigureAwait(false);
        }

        public static async Task<TatumSdk> InitAsync(Network network, string apiKey, ITatumSdkConfiguration configuration)
        {
            configuration = ResolveConfiguration(network, apiKey, configuration);

            var delegatingHandler = PrepareDelegatingHandler(configuration);

            var client = new HttpClient(delegatingHandler);

            configuration.ConfigureHttpClient(client);
            
            await configuration.Validate(client).ConfigureAwait(false);

            return new TatumSdk(client, configuration);
        }

        public static async Task<TatumSdk> InitAsync(IHttpClientFactory httpClientFactory)
        {
            return await InitAsync(Network.Mainnet, null, httpClientFactory, (ITatumSdkConfiguration)null).ConfigureAwait(false);
        }

        public static async Task<TatumSdk> InitAsync(string apiKey, IHttpClientFactory httpClientFactory)
        {
            return await InitAsync(Network.Mainnet, apiKey, httpClientFactory, (ITatumSdkConfiguration)null).ConfigureAwait(false);
        }

        public static async Task<TatumSdk> InitAsync(Network network, string apiKey, IHttpClientFactory httpClientFactory)
        {
            return await InitAsync(network, apiKey, httpClientFactory, (ITatumSdkConfiguration)null).ConfigureAwait(false);
        }

        public static async Task<TatumSdk> InitAsync(Network network, IHttpClientFactory httpClientFactory)
        {
            return await InitAsync(network, null, httpClientFactory, (ITatumSdkConfiguration)null).ConfigureAwait(false);
        }

        public static async Task<TatumSdk> InitAsync(IHttpClientFactory httpClientFactory, ITatumSdkConfiguration configuration)
        {
            return await InitAsync(Network.Mainnet, null, httpClientFactory, configuration).ConfigureAwait(false);
        }

        public static async Task<TatumSdk> InitAsync(string apiKey, IHttpClientFactory httpClientFactory, ITatumSdkConfiguration configuration)
        {
            return await InitAsync(Network.Mainnet, apiKey, httpClientFactory, configuration).ConfigureAwait(false);
        }

        public static async Task<TatumSdk> InitAsync(Network network, IHttpClientFactory httpClientFactory, ITatumSdkConfiguration configuration)
        {
            return await InitAsync(network, null, httpClientFactory, configuration).ConfigureAwait(false);
        }

        public static async Task<TatumSdk> InitAsync(IHttpClientFactory httpClientFactory, Action<ITatumSdkConfiguration> configurationAction)
        {
            return await InitAsync(Network.Mainnet, null, httpClientFactory, configurationAction).ConfigureAwait(false);
        }

        public static async Task<TatumSdk> InitAsync(string apiKey, IHttpClientFactory httpClientFactory, Action<ITatumSdkConfiguration> configurationAction)
        {
            return await InitAsync(Network.Mainnet, apiKey, httpClientFactory, configurationAction).ConfigureAwait(false);
        }

        public static async Task<TatumSdk> InitAsync(Network network, IHttpClientFactory httpClientFactory, Action<ITatumSdkConfiguration> configurationAction)
        {
            return await InitAsync(network, null, httpClientFactory, configurationAction).ConfigureAwait(false);
        }

        public static async Task<TatumSdk> InitAsync(Network network, string apiKey, IHttpClientFactory httpClientFactory, Action<ITatumSdkConfiguration> configurationAction)
        {
            ITatumSdkConfiguration configuration = null;
            
            if (configurationAction != null)
            {
                configuration = new DefaultTatumSdkConfiguration();
            
                configurationAction(configuration);
            }

            return await InitAsync(network, apiKey, httpClientFactory, configuration).ConfigureAwait(false);
        }

        public static async Task<TatumSdk> InitAsync(Network network, string apiKey, IHttpClientFactory httpClientFactory, ITatumSdkConfiguration configuration)
        {
            configuration = ResolveConfiguration(network, apiKey, configuration);

            var httpClient = httpClientFactory.CreateClient(TatumConstants.TatumHttpClientName);
            
            configuration.ConfigureHttpClient(httpClient);
            
            await configuration.Validate(httpClient).ConfigureAwait(false);

            return new TatumSdk(httpClientFactory, configuration);
        }

        private static ITatumSdkConfiguration ResolveConfiguration(Network network, string apiKey, ITatumSdkConfiguration configuration)
        {
            if (configuration == null)
            {
                configuration = new DefaultTatumSdkConfiguration();
            }

            configuration.BaseUrl = TatumConstants.BaseUrl;
            configuration.Network = network;
            configuration.ApiKey = apiKey;
            
            configuration.Version = GetVersion();

            return configuration;
        }

        private static DelegatingHandler PrepareDelegatingHandler(ITatumSdkConfiguration configuration)
        {
            var retryPolicyHandler = new PolicyHttpMessageHandler(configuration.RetryPolicy);
            retryPolicyHandler.InnerHandler = new HttpClientHandler();
            
            var noApiKeyNetworkHandler = new NoApiKeyNetworkHandler(configuration);
            noApiKeyNetworkHandler.InnerHandler = retryPolicyHandler;

            if (configuration.EnableDebugMode)
            {
                var debugModeHandler = new DebugModeHandler();
                debugModeHandler.InnerHandler = noApiKeyNetworkHandler;

                return debugModeHandler;
            }

            return noApiKeyNetworkHandler;
        }

        private static string GetVersion()
        {
            const string versionLocation = "Tatum..version";
            
            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream(versionLocation);
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}
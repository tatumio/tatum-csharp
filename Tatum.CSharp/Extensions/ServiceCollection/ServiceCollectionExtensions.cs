using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using Tatum.CSharp.Core;
using Tatum.CSharp.Core.Configuration;
using Tatum.CSharp.Core.Handlers;
using Tatum.CSharp.Core.Models;
using Tatum.CSharp.Utils.DebugMode;

namespace Tatum.CSharp.Extensions.ServiceCollection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTatumSdk(this IServiceCollection services, Network network, string apiKey, TatumSdkConfiguration configuration = null)
        {
            if(configuration == null)
            {
                configuration = new DefaultTatumSdkConfiguration();
            }
            
            RegisterHttpClient(services, configuration);
            
            services.AddSingleton<ITatumSdk>(srv => TatumSdk.Init(network == Network.Testnet, apiKey, srv.GetService<IHttpClientFactory>(), configuration));
            return services;
        }

        public static IServiceCollection AddTatumSdk(this IServiceCollection services, string apiKey, TatumSdkConfiguration configuration = null)
        {
            if(configuration == null)
            {
                configuration = new DefaultTatumSdkConfiguration();
            }

            RegisterHttpClient(services, configuration);
            
            services.AddSingleton<ITatumSdk>(srv => TatumSdk.Init(apiKey, srv.GetService<IHttpClientFactory>(), configuration));
            return services;
        }

        public static IServiceCollection AddTatumSdk(this IServiceCollection services, Network network, TatumSdkConfiguration configuration = null)
        {
            if(configuration == null)
            {
                configuration = new DefaultTatumSdkConfiguration();
            }

            RegisterHttpClient(services, configuration);
            
            services.AddSingleton<ITatumSdk>(srv => TatumSdk.Init(network == Network.Testnet, srv.GetService<IHttpClientFactory>(), configuration));
            return services;
        }

        public static IServiceCollection AddTatumSdk(this IServiceCollection services, TatumSdkConfiguration configuration = null)
        {
            if(configuration == null)
            {
                configuration = new DefaultTatumSdkConfiguration();
            }

            RegisterHttpClient(services, configuration);
            
            services.AddSingleton<ITatumSdk>(srv => TatumSdk.Init(srv.GetService<IHttpClientFactory>(), configuration));
            return services;
        }

        public static IServiceCollection AddTatumSdkWithDebug(this IServiceCollection services, Network network, string apiKey, TatumSdkConfiguration configuration = null)
        {
            if(configuration == null)
            {
                configuration = new DefaultTatumSdkConfiguration();
            }

            RegisterHttpClientWithDebug(services, configuration);

            services.AddSingleton<ITatumSdk>(srv => TatumSdk.Init(network == Network.Testnet, apiKey, srv.GetService<IHttpClientFactory>(), configuration));
            return services;
        }

        public static IServiceCollection AddTatumSdkWithDebug(this IServiceCollection services, string apiKey, TatumSdkConfiguration configuration = null)
        {
            if(configuration == null)
            {
                configuration = new DefaultTatumSdkConfiguration();
            }

            RegisterHttpClientWithDebug(services, configuration);

            services.AddSingleton<ITatumSdk>(srv => TatumSdk.Init(apiKey, srv.GetService<IHttpClientFactory>(), configuration));
            return services;
        }

        public static IServiceCollection AddTatumSdkWithDebug(this IServiceCollection services, Network network, TatumSdkConfiguration configuration = null)
        {
            if(configuration == null)
            {
                configuration = new DefaultTatumSdkConfiguration();
            }

            RegisterHttpClientWithDebug(services, configuration);

            services.AddSingleton<ITatumSdk>(srv => TatumSdk.Init(network == Network.Testnet, srv.GetService<IHttpClientFactory>(), configuration));
            return services;
        }

        public static IServiceCollection AddTatumSdkWithDebug(this IServiceCollection services, TatumSdkConfiguration configuration = null)
        {
            if(configuration == null)
            {
                configuration = new DefaultTatumSdkConfiguration();
            }

            RegisterHttpClientWithDebug(services, configuration);

            services.AddSingleton<ITatumSdk>(srv => TatumSdk.Init(srv.GetService<IHttpClientFactory>(), configuration));
            return services;
        }

        private static void RegisterHttpClient(IServiceCollection services, TatumSdkConfiguration configuration)
        {
            services.AddSingleton<NoApiKeyNetworkHandler>();
            services.AddHttpClient(TatumConstants.TatumHttpClientName)
                .AddHttpMessageHandler<NoApiKeyNetworkHandler>()
                .AddHttpMessageHandler(() => new PolicyHttpMessageHandler(configuration.RetryPolicy));
        }

        private static void RegisterHttpClientWithDebug(IServiceCollection services, TatumSdkConfiguration configuration)
        {
            services.AddSingleton<DebugModeHandler>();
            services.AddSingleton<NoApiKeyNetworkHandler>();
            services.AddHttpClient(TatumConstants.TatumHttpClientName)
                .AddHttpMessageHandler(() => new PolicyHttpMessageHandler(configuration.RetryPolicy))
                .AddHttpMessageHandler<NoApiKeyNetworkHandler>()
                .AddHttpMessageHandler<DebugModeHandler>();
        }
    }
}
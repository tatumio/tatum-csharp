using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using Tatum.Core;
using Tatum.Core.Configuration;
using Tatum.Core.Handlers;
using Tatum.Core.Models;
using Tatum.Utils.DebugMode;

namespace Tatum.Extensions.ServiceCollection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTatumSdk(this IServiceCollection services, Network network, string apiKey, ITatumSdkConfiguration configuration = null)
        {
            if(configuration == null)
            {
                configuration = new DefaultTatumSdkConfiguration();
            }
            
            RegisterHttpClient(services, configuration);
            
            services.AddSingleton<ITatumSdk>(srv => TatumSdk.Init(network, apiKey, srv.GetService<IHttpClientFactory>(), configuration));
            return services;
        }

        public static IServiceCollection AddTatumSdk(this IServiceCollection services, string apiKey, ITatumSdkConfiguration configuration = null)
        {
            if(configuration == null)
            {
                configuration = new DefaultTatumSdkConfiguration();
            }

            RegisterHttpClient(services, configuration);
            
            services.AddSingleton<ITatumSdk>(srv => TatumSdk.Init(apiKey, srv.GetService<IHttpClientFactory>(), configuration));
            return services;
        }

        public static IServiceCollection AddTatumSdk(this IServiceCollection services, Network network, ITatumSdkConfiguration configuration = null)
        {
            if(configuration == null)
            {
                configuration = new DefaultTatumSdkConfiguration();
            }

            RegisterHttpClient(services, configuration);
            
            services.AddSingleton<ITatumSdk>(srv => TatumSdk.Init(network, srv.GetService<IHttpClientFactory>(), configuration));
            return services;
        }

        public static IServiceCollection AddTatumSdk(this IServiceCollection services, ITatumSdkConfiguration configuration = null)
        {
            if(configuration == null)
            {
                configuration = new DefaultTatumSdkConfiguration();
            }

            RegisterHttpClient(services, configuration);
            
            services.AddSingleton<ITatumSdk>(srv => TatumSdk.Init(srv.GetService<IHttpClientFactory>(), configuration));
            return services;
        }

        public static IServiceCollection AddTatumSdkWithDebug(this IServiceCollection services, Network network, string apiKey, ITatumSdkConfiguration configuration = null)
        {
            if(configuration == null)
            {
                configuration = new DefaultTatumSdkConfiguration();
            }

            RegisterHttpClientWithDebug(services, configuration);

            services.AddSingleton<ITatumSdk>(srv => TatumSdk.Init(network, apiKey, srv.GetService<IHttpClientFactory>(), configuration));
            return services;
        }

        public static IServiceCollection AddTatumSdkWithDebug(this IServiceCollection services, string apiKey, ITatumSdkConfiguration configuration = null)
        {
            if(configuration == null)
            {
                configuration = new DefaultTatumSdkConfiguration();
            }

            RegisterHttpClientWithDebug(services, configuration);

            services.AddSingleton<ITatumSdk>(srv => TatumSdk.Init(apiKey, srv.GetService<IHttpClientFactory>(), configuration));
            return services;
        }

        public static IServiceCollection AddTatumSdkWithDebug(this IServiceCollection services, Network network, ITatumSdkConfiguration configuration = null)
        {
            if(configuration == null)
            {
                configuration = new DefaultTatumSdkConfiguration();
            }

            RegisterHttpClientWithDebug(services, configuration);

            services.AddSingleton<ITatumSdk>(srv => TatumSdk.Init(network, srv.GetService<IHttpClientFactory>(), configuration));
            return services;
        }

        public static IServiceCollection AddTatumSdkWithDebug(this IServiceCollection services, ITatumSdkConfiguration configuration = null)
        {
            if(configuration == null)
            {
                configuration = new DefaultTatumSdkConfiguration();
            }

            RegisterHttpClientWithDebug(services, configuration);

            services.AddSingleton<ITatumSdk>(srv => TatumSdk.Init(srv.GetService<IHttpClientFactory>(), configuration));
            return services;
        }

        private static void RegisterHttpClient(IServiceCollection services, ITatumSdkConfiguration configuration)
        {
            services.AddTransient(x => new NoApiKeyNetworkHandler(configuration));
            services.AddHttpClient(TatumConstants.TatumHttpClientName)
                .AddHttpMessageHandler<NoApiKeyNetworkHandler>()
                .AddHttpMessageHandler(() => new PolicyHttpMessageHandler(configuration.RetryPolicy));
        }

        private static void RegisterHttpClientWithDebug(IServiceCollection services, ITatumSdkConfiguration configuration)
        {
            services.AddTransient<DebugModeHandler>();
            services.AddTransient(x => new NoApiKeyNetworkHandler(configuration));
            services.AddHttpClient(TatumConstants.TatumHttpClientName)
                .AddHttpMessageHandler(() => new PolicyHttpMessageHandler(configuration.RetryPolicy))
                .AddHttpMessageHandler<NoApiKeyNetworkHandler>()
                .AddHttpMessageHandler<DebugModeHandler>();
        }
    }
}
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Tatum.CSharp.Core;
using Tatum.CSharp.Core.Configuration;
using Tatum.CSharp.Core.Models;
using Tatum.CSharp.Utils.DebugMode;

namespace Tatum.CSharp.Extensions.ServiceCollection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTatumSdk(this IServiceCollection services, Network network, string apiKey, TatumSdkConfiguration configuration = null)
        {
            services.AddHttpClient(TatumConstants.TatumHttpClientName);
            services.AddSingleton<ITatumSdk>(srv => TatumSdk.Init(network == Network.Testnet, apiKey, srv.GetService<IHttpClientFactory>(), configuration));
            return services;
        }
        
        public static IServiceCollection AddTatumSdk(this IServiceCollection services, string apiKey, TatumSdkConfiguration configuration = null)
        {
            services.AddHttpClient(TatumConstants.TatumHttpClientName);
            services.AddSingleton<ITatumSdk>(srv => TatumSdk.Init(apiKey, srv.GetService<IHttpClientFactory>(), configuration));
            return services;
        }
        
        public static IServiceCollection AddTatumSdk(this IServiceCollection services, Network network, TatumSdkConfiguration configuration = null)
        {
            services.AddHttpClient(TatumConstants.TatumHttpClientName);
            services.AddSingleton<ITatumSdk>(srv => TatumSdk.Init(network == Network.Testnet, srv.GetService<IHttpClientFactory>(), configuration));
            return services;
        }
        
        public static IServiceCollection AddTatumSdk(this IServiceCollection services, TatumSdkConfiguration configuration = null)
        {
            services.AddHttpClient(TatumConstants.TatumHttpClientName);
            services.AddSingleton<ITatumSdk>(srv => TatumSdk.Init(srv.GetService<IHttpClientFactory>(), configuration));
            return services;
        }
        
        public static IServiceCollection AddTatumSdkWithDebug(this IServiceCollection services, Network network, string apiKey, TatumSdkConfiguration configuration = null)
        {
            services.AddSingleton<DebugModeHandler>();
            services.AddHttpClient(TatumConstants.TatumHttpClientName)
                .AddHttpMessageHandler<DebugModeHandler>();

            services.AddSingleton<ITatumSdk>(srv => TatumSdk.Init(network == Network.Testnet, apiKey, srv.GetService<IHttpClientFactory>(), configuration));
            return services;
        }
        
        public static IServiceCollection AddTatumSdkWithDebug(this IServiceCollection services, string apiKey, TatumSdkConfiguration configuration = null)
        {
            services.AddSingleton<DebugModeHandler>();
            services.AddHttpClient(TatumConstants.TatumHttpClientName)
                .AddHttpMessageHandler<DebugModeHandler>();

            services.AddSingleton<ITatumSdk>(srv => TatumSdk.Init(apiKey, srv.GetService<IHttpClientFactory>(), configuration));
            return services;
        }
        
        public static IServiceCollection AddTatumSdkWithDebug(this IServiceCollection services, Network network, TatumSdkConfiguration configuration = null)
        {
            services.AddSingleton<DebugModeHandler>();
            services.AddHttpClient(TatumConstants.TatumHttpClientName)
                .AddHttpMessageHandler<DebugModeHandler>();

            services.AddSingleton<ITatumSdk>(srv => TatumSdk.Init(network == Network.Testnet, srv.GetService<IHttpClientFactory>(), configuration));
            return services;
        }
        
        public static IServiceCollection AddTatumSdkWithDebug(this IServiceCollection services, TatumSdkConfiguration configuration = null)
        {
            services.AddSingleton<DebugModeHandler>();
            services.AddHttpClient(TatumConstants.TatumHttpClientName)
                .AddHttpMessageHandler<DebugModeHandler>();

            services.AddSingleton<ITatumSdk>(srv => TatumSdk.Init(srv.GetService<IHttpClientFactory>(), configuration));
            return services;
        }
    }
}
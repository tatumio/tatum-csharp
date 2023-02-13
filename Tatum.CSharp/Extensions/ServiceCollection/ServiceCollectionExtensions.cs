using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Tatum.CSharp.Core;
using Tatum.CSharp.Utils.DebugMode;

namespace Tatum.CSharp.Extensions.ServiceCollection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTatumSdk(this IServiceCollection services, bool isTestnet, string apiKey)
        {
            services.AddHttpClient(TatumConstants.TatumHttpClientName);
            return services.AddTatumSdkInternal(isTestnet, apiKey);
        }
        
        public static IServiceCollection AddTatumSdkWithDebug(this IServiceCollection services, bool isTestnet, string apiKey)
        {
            services.AddSingleton<DebugModeHandler>();
            services.AddHttpClient(TatumConstants.TatumHttpClientName)
                .AddHttpMessageHandler<DebugModeHandler>();

            return services.AddTatumSdkInternal(isTestnet, apiKey);
        }
        
        private static IServiceCollection AddTatumSdkInternal(this IServiceCollection services, bool isTestnet, string apiKey)
        {
            services.AddSingleton<ITatumSdk>(srv => TatumSdk.Init(isTestnet, apiKey, srv.GetService<IHttpClientFactory>()));

            return services;
        }
    }
}
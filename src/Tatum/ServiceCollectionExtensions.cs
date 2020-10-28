using Microsoft.Extensions.DependencyInjection;

namespace Tatum
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTatum(this IServiceCollection services, string apiBaseUrl, string xApiKey)
        {
            return services;
        }
    }
}

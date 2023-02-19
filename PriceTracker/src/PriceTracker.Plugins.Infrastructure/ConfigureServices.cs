using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PriceTracker.Plugins.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPluginsInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}

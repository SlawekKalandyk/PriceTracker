using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PriceTracker.Api.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApiInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}

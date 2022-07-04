using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PriceTracker.Infrastructure.Api
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApiInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PriceTracker.Infrastructure.Scraper
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddScraperInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}

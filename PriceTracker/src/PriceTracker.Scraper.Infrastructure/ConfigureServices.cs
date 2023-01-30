using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PriceTracker.Scraper.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddScraperInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}

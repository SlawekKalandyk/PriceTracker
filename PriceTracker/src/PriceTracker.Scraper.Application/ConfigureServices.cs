using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PriceTracker.Scraper.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddScraperApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(serviceConfiguration => serviceConfiguration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}

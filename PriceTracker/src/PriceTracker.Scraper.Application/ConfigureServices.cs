using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PriceTracker.Scraper.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddScraperApplicationServices(this IServiceCollection services, IConfiguration? configuration = null)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}

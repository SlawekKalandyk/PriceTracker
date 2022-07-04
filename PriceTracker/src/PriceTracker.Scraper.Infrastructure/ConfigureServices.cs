using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PriceTracker.Scraper.Application.Common.Interfaces;
using PriceTracker.Scraper.Application.Common.Interfaces.ShopScrapers;
using PriceTracker.Scraper.Infrastructure.Services;
using PriceTracker.Scraper.Infrastructure.Services.ShopScrapers;

namespace PriceTracker.Scraper.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddScraperInfrastructureServices(this IServiceCollection services, IConfiguration? configuration = null)
        {
            services.AddTransient<IDateTimeProvider, DateTimeProvider>();

            services.AddScoped<IXKomScraper, XKomScraper>();
            services.AddScoped<IMoreleScraper, MoreleScraper>();

            services.AddSingleton<IWebsiteScraper, WebsiteScraper>();

            return services;
        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PriceTracker.Application.Scraper.Common.Interfaces;
using PriceTracker.Application.Scraper.Common.Interfaces.ShopScrapers;
using PriceTracker.Infrastructure.Scraper.Services;
using PriceTracker.Infrastructure.Scraper.Services.ShopScrapers;

namespace PriceTracker.Infrastructure.Scraper
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

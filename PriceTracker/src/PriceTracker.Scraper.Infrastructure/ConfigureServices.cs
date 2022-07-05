using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PriceTracker.Scraper.Application.Common.Interfaces;
using PriceTracker.Scraper.Infrastructure.Persistence;
using PriceTracker.Scraper.Infrastructure.Services;
using PriceTracker.Scraper.Infrastructure.Services.ShopScrapers;

namespace PriceTracker.Scraper.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddScraperInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = Environment.ExpandEnvironmentVariables(configuration.GetConnectionString("DefaultConnection"));

            services.AddDbContext<ScraperApplicationDbContext>(options
                => options.UseSqlite(
                    connectionString, 
                    builder => builder.MigrationsAssembly(typeof(ScraperApplicationDbContext).Assembly.FullName)
                    ));


            services.AddScoped<IScraperApplicationDbContext>(provider =>
                provider.GetService<ScraperApplicationDbContext>());

            services.AddTransient<IDateTimeProvider, DateTimeProvider>();

            services.AddScoped<IShopScraper, XKomScraper>();
            services.AddScoped<IShopScraper, MoreleScraper>();

            services.AddSingleton<IWebsiteScraper, WebsiteScraper>();

            return services;
        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PriceTracker.Plugins.Shared;

namespace PriceTracker.Plugins
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPluginShopServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IWebsiteScraper, WebsiteScraper>();

            var pluginLocation = configuration["PluginsLocation"];
            var pluginLoader = new PluginLoader<IShopScraper>();
            foreach (var shopScraperType in pluginLoader.LoadPluginTypes(pluginLocation))
            {
                services.AddSingleton(typeof(IShopScraper), shopScraperType);
            }

            return services;
        }
    }
}
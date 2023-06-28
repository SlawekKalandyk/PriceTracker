using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PriceTracker.Plugins;
using PriceTracker.Shared;
using PriceTracker.Shared.Persistence;

namespace PriceTracker.Scraper
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, configuration) =>
                {
                    configuration.Sources.Clear();
                    configuration
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true);
#if DEBUG
                    configuration.AddUserSecrets<ApplicationDbContext>();
#endif
                    configuration.Build();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSharedServices(hostContext.Configuration)
                        .AddScraperServices(hostContext.Configuration)
                        .AddPluginShopServices(hostContext.Configuration)
                        .AddHostedService<ScraperHostedService>();
                }).Build();
            
            await host.RunAsync();
        }
    }
}
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PriceTracker.Plugins;
using PriceTracker.Scraper.Application;
using PriceTracker.Scraper.Infrastructure;
using PriceTracker.Shared.Application;
using PriceTracker.Shared.Infrastructure;

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

                    configuration.Build();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSharedApplicationServices(hostContext.Configuration)
                        .AddSharedInfrastructureServices(hostContext.Configuration)
                        .AddScraperApplicationServices(hostContext.Configuration)
                        .AddScraperInfrastructureServices(hostContext.Configuration)
                        .AddPluginShopServices(hostContext.Configuration)
                        .AddHostedService<ScraperHostedService>();
                }).Build();

            await host.RunAsync();
        }
    }
}
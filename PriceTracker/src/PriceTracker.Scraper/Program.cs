using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

                    IHostEnvironment env = hostingContext.HostingEnvironment;

                    configuration
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);

                    configuration.Build();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSharedApplicationServices(hostContext.Configuration);
                    services.AddSharedInfrastructureServices(hostContext.Configuration);
                    services.AddScraperApplicationServices(hostContext.Configuration);
                    services.AddScraperInfrastructureServices(hostContext.Configuration);
                    services.AddHostedService<ScraperHostedService>();
                }).Build();


            await host.RunAsync();
        }
    }
}
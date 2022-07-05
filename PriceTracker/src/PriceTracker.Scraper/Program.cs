using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PriceTracker.Scraper.Application;
using PriceTracker.Scraper.Infrastructure;

namespace PriceTracker.Scraper
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddScraperApplicationServices();
                    services.AddScraperInfrastructureServices();
                    services.AddSingleton<IHostedService, ScraperService>();
                });

            await builder.RunConsoleAsync();
        }
    }
}
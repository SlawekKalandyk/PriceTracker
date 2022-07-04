using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PriceTracker.Application.Scraper;
using PriceTracker.Infrastructure.Scraper;

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
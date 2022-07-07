using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PriceTracker.Scraper.Application.Features.Products.Commands.UpdateProducts;
using PriceTracker.Scraper.Application.Features.Products.Queries.GetTrackedProducts;

namespace PriceTracker.Scraper
{
    public class ScraperHostedService : BackgroundService
    {
        private const int IntervalMinutes = 60;

        private readonly IServiceProvider _serviceProvider;

        public ScraperHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceProvider.CreateScope();
                var mediator = scope.ServiceProvider.GetRequiredService<ISender>();
                var getTrackedProductsResponse = await mediator.Send(new GetTrackedProductsQuery(), stoppingToken);

                var updateProductsCommand = new UpdateProductsCommand
                {
                    Products = getTrackedProductsResponse.Products
                };
                await mediator.Send(updateProductsCommand, stoppingToken);

                await Task.Delay(TimeSpan.FromMinutes(IntervalMinutes), stoppingToken);
            }
        }
    }
}

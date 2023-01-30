using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PriceTracker.Plugins.Shared;
using PriceTracker.Scraper.Application.Features.Products.Commands.UpdateProducts;
using PriceTracker.Scraper.Application.Features.Products.Queries.GetTrackedProducts;
using PriceTracker.Shared.Application.Common.Interfaces;

namespace PriceTracker.Scraper
{
    public class ScraperHostedService : BackgroundService
    {
        private const int IntervalMinutes = 60;

        private readonly IServiceProvider _serviceProvider;
        private readonly IEnumerable<IShopScraper> _shopScrapers;
        private readonly IApplicationDbContext _context;

        public ScraperHostedService(IServiceProvider serviceProvider, IApplicationDbContext context, IEnumerable<IShopScraper> shopScrapers)
        {
            _serviceProvider = serviceProvider;
            _context = context;
            _shopScrapers = shopScrapers;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            await AddShopsFromScrapers(cancellationToken).WaitAsync(cancellationToken);

            while (!cancellationToken.IsCancellationRequested)
            {
                await UpdateProducts(cancellationToken);
                await Task.Delay(TimeSpan.FromMinutes(IntervalMinutes), cancellationToken);
            }
        }

        private async Task AddShopsFromScrapers(CancellationToken cancellationToken)
        {
            foreach (var shop in _shopScrapers.Select(scraper => scraper.Shop))
            {
                if (!_context.Shops.Any(existingShop => existingShop.Name == shop.Name))
                {
                    _context.Shops.Add(shop);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task UpdateProducts(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<ISender>();
            var getTrackedProductsResponse = await mediator.Send(new GetTrackedProductsQuery(), cancellationToken);

            var updateProductsCommand = new UpdateProductsCommand
            {
                Products = getTrackedProductsResponse.Products
            };
            await mediator.Send(updateProductsCommand, cancellationToken);
        }
    }
}

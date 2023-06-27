using System.Threading.Tasks.Dataflow;
using MediatR;
using PriceTracker.Domain.Entities;
using PriceTracker.Plugins.Shared;
using PriceTracker.Shared.Common.Interfaces;

namespace PriceTracker.Scraper.Features.Commands
{
    public record UpdateProductsCommand(IQueryable<Product> Products) : IRequest<UpdateProductsCommandResponse>
    {
    }

    public record UpdateProductsCommandResponse
    {

    }

    public class UpdateProductsCommandHandler : IRequestHandler<UpdateProductsCommand, UpdateProductsCommandResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IEnumerable<IShopScraper> _scrapers;
        private const int MaxTasksAtOnce = 1;

        public UpdateProductsCommandHandler(IApplicationDbContext context, IEnumerable<IShopScraper> scrapers)
        {
            _context = context;
            _scrapers = scrapers;
        }

        public async Task<UpdateProductsCommandResponse> Handle(UpdateProductsCommand request, CancellationToken cancellationToken)
        {
            var blocks = new Dictionary<string, ActionBlock<Product>>();

            foreach (var scraper in _scrapers)
            {
                blocks[scraper.ShopData.Name] = new ActionBlock<Product>(async (product) =>
                {
                    await UpdateProduct(product, cancellationToken);
                }, new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = MaxTasksAtOnce });
            }

            foreach (var product in request.Products)
            {
                blocks[product.Shop.Name].Post(product);
            }

            foreach (var block in blocks.Values)
            {
                block.Complete();
            }

            await Task.WhenAll(blocks.Values.Select(block => block.Completion));

            return new UpdateProductsCommandResponse();
        }

        private async Task UpdateProduct(Product product, CancellationToken cancellationToken)
        {
            var scraper = GetScraperForShop(_scrapers, product.Shop);
            await scraper.Scrape(product);

            await _context.SaveChangesAsync(cancellationToken);
        }

        private IShopScraper GetScraperForShop(IEnumerable<IShopScraper> scrapers, Shop shop)
        {
            return scrapers.Single(scraper => scraper.ShopData.Name == shop.Name);
        }
    }
}

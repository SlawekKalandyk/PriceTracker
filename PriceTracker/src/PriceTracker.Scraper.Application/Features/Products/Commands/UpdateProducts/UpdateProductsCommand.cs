using MediatR;
using PriceTracker.Domain.Entities;
using PriceTracker.Shared.Application.Common.Interfaces;
using System.Threading.Tasks.Dataflow;
using PriceTracker.Plugins.Shared;

namespace PriceTracker.Scraper.Application.Features.Products.Commands.UpdateProducts
{
    public record UpdateProductsCommand : IRequest<UpdateProductsCommandResponse>
    {
        public IQueryable<Product> Products { get; init; }
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
            var blocks = new Dictionary<Shop, ActionBlock<Product>>();

            foreach (var scraper in _scrapers)
            {
                blocks[scraper.Shop] = new ActionBlock<Product>(async (product) =>
                {
                    await UpdateProduct(product, cancellationToken);
                }, new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = MaxTasksAtOnce });
            }

            foreach (var product in request.Products)
            {
                blocks[product.Shop].Post(product);
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
            await scraper.Scrape(product.Url, product);

            await _context.SaveChangesAsync(cancellationToken);
        }

        private IShopScraper GetScraperForShop(IEnumerable<IShopScraper> scrapers, Shop shop)
        {
            return scrapers.Single(scraper => scraper.Shop == shop);
        }
    }
}

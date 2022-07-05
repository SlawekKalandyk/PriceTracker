using MediatR;
using PriceTracker.Domain.Entities;
using PriceTracker.Domain.Enums;
using PriceTracker.Scraper.Application.Common.Interfaces;
using System.Threading.Tasks.Dataflow;

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
        private readonly IScraperApplicationDbContext _context;
        private readonly IEnumerable<IShopScraper> _scrapers;
        private const int MaxTasksAtOnce = 10;

        public UpdateProductsCommandHandler(IScraperApplicationDbContext context, IEnumerable<IShopScraper> scrapers)
        {
            _context = context;
            _scrapers = scrapers;
        }

        public async Task<UpdateProductsCommandResponse> Handle(UpdateProductsCommand request, CancellationToken cancellationToken)
        {
            var block = new ActionBlock<Product>(async (product) =>
            {
                await UpdateProduct(product, cancellationToken);
            }, new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = MaxTasksAtOnce });

            foreach (var product in request.Products)
            {
                block.Post(product);
            }

            block.Complete();
            await block.Completion;

            return new UpdateProductsCommandResponse();
        }

        private async Task UpdateProduct(Product product, CancellationToken cancellationToken)
        {
            var scraper = GetScraperForShop(_scrapers, product.GeneralInformation.Shop);
            await scraper.Scrape(product.GeneralInformation.Url, product);
            await _context.SaveChangesAsync(cancellationToken);
        }

        private IShopScraper GetScraperForShop(IEnumerable<IShopScraper> scrapers, Shop shop)
        {
            return scrapers.Single(scraper => scraper.Shop == shop);
        }
    }
}

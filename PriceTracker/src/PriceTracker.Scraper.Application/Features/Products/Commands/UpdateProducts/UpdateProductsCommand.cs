using MediatR;
using PriceTracker.Domain.Entities;
using PriceTracker.Domain.Enums;
using PriceTracker.Scraper.Application.Common.Interfaces;
using PriceTracker.Scraper.Application.Common.Interfaces.ShopScrapers;
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
        private readonly IXKomScraper _xKomScraper;
        private readonly IMoreleScraper _moreleScraper;
        private const int MaxTasksAtOnce = 10;

        public UpdateProductsCommandHandler(IScraperApplicationDbContext context, IXKomScraper xKomScraper, IMoreleScraper moreleScraper)
        {
            _context = context;
            _xKomScraper = xKomScraper;
            _moreleScraper = moreleScraper;
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
            switch (product.GeneralInformation.Shop)
            {
                case Shop.XKom:
                    await _xKomScraper.Scrape(product.GeneralInformation.Url, product);
                    break;
                case Shop.Morele:
                    await _moreleScraper.Scrape(product.GeneralInformation.Url, product);
                    break;
            }

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

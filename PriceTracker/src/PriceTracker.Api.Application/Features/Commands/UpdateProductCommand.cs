using MediatR;
using PriceTracker.Domain.Entities;
using PriceTracker.Plugins.Shared;
using PriceTracker.Shared.Application.Common.Interfaces;

namespace PriceTracker.Api.Application.Features.Commands
{
    public record UpdateProductCommand(Product Product) : IRequest<UpdateProductCommandResponse>
    {
    }

    public record UpdateProductCommandResponse(Product UpdatedProduct)
    {
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductCommandResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IEnumerable<IShopScraper> _scrapers;

        public UpdateProductCommandHandler(IApplicationDbContext context, IEnumerable<IShopScraper> scrapers)
        {
            _context = context;
            _scrapers = scrapers;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            var scraper = _scrapers.SingleOrDefault(s => s.ShopData.Name == request.Product.Shop.Name);
            if (scraper == null)
                throw new ArgumentNullException($"Scraper not found for product {request.Product.Shop.Name} - {request.Product.Name}, {request.Product.Url}");


            var updatedProduct = await scraper.Scrape(request.Product);
            _context.Products.Update(updatedProduct);
            await _context.SaveChangesAsync(cancellationToken);
            return new UpdateProductCommandResponse(updatedProduct);
        }
    }
}

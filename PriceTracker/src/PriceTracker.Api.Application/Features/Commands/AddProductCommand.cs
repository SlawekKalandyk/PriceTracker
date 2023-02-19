using MediatR;
using PriceTracker.Domain.Entities;
using PriceTracker.Plugins.Shared;
using PriceTracker.Shared.Application.Common.Interfaces;

namespace PriceTracker.Api.Application.Features.Commands
{
    public record AddProductCommand(string Url) : IRequest<AddProductCommandResponse>
    {
    }

    public record AddProductCommandResponse(Product? Product)
    {
    }

    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, AddProductCommandResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IEnumerable<IShopScraper> _scrapers;

        public AddProductCommandHandler(IApplicationDbContext context, IEnumerable<IShopScraper> scrapers)
        {
            _context = context;
            _scrapers = scrapers;
        }

        public async Task<AddProductCommandResponse> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var uri = new Uri(request.Url);
            var domain = uri.Host;
            var shop = _context.Shops.ToList().SingleOrDefault(s => s.DomainUrls.Contains(domain));
            Product? newProduct = null;
            if (shop != null)
            {
                var scraper = _scrapers.SingleOrDefault(s => s.ShopData.Name == shop.Name);
                if (scraper != null)
                {
                    newProduct = await scraper.Scrape(request.Url);
                    newProduct.Shop = shop;
                    newProduct = _context.Products.Add(newProduct).Entity;
                    await _context.SaveChangesAsync(cancellationToken);
                }
            }

            return new AddProductCommandResponse(newProduct);
        }
    }
}

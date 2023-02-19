using MediatR;
using PriceTracker.Plugins.Shared;
using PriceTracker.Shared.Application.Common.Interfaces;

namespace PriceTracker.Api.Application.Features.Commands
{
    public record AddProductCommand : IRequest<AddProductCommandResponse>
    {
        public string Url { get; set; }
    }

    public record AddProductCommandResponse
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
            if (shop != null)
            {
                var scraper = _scrapers.SingleOrDefault(s => s.ShopData.Name == shop.Name);
                if (scraper != null)
                {
                    var product = await scraper.Scrape(request.Url);
                    product.Shop = shop;
                    await _context.Products.AddAsync(product, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                }
            }

            return new AddProductCommandResponse();
        }
    }
}

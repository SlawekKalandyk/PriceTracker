using MediatR;
using PriceTracker.Plugins.Shared;
using PriceTracker.Shared.Application.Common.Interfaces;

namespace PriceTracker.Scraper.Application.Features.Products.Commands.LoadShops
{
    public record LoadShopsCommand : IRequest<LoadShopsCommandResponse>
    {
    }

    public record LoadShopsCommandResponse
    {
    }

    public class LoadShopsCommandHandler : IRequestHandler<LoadShopsCommand, LoadShopsCommandResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IEnumerable<IShopScraper> _shopScrapers;

        public LoadShopsCommandHandler(IApplicationDbContext context, IEnumerable<IShopScraper> shopScrapers)
        {
            _context = context;
            _shopScrapers = shopScrapers;
        }

        public async Task<LoadShopsCommandResponse> Handle(LoadShopsCommand request, CancellationToken cancellationToken)
        {
            foreach (var shop in _shopScrapers.Select(scraper => scraper.Shop))
            {
                if (!_context.Shops.Any(existingShop => existingShop.Name == shop.Name))
                {
                    _context.Shops.Add(shop);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);

            return new LoadShopsCommandResponse();
        }
    }
}

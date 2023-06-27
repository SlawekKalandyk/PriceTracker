using MediatR;
using PriceTracker.Domain.Entities;
using PriceTracker.Plugins.Shared;
using PriceTracker.Shared.Common.Interfaces;

namespace PriceTracker.Shared.Features.Commands
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
            foreach (var shopData in _shopScrapers.Select(scraper => scraper.ShopData))
            {
                if (!_context.Shops.Any(existingShop => existingShop.Name == shopData.Name))
                {
                    var shop = new Shop
                    {
                        Name = shopData.Name,
                        DomainUrls = shopData.DomainUrls
                    };
                    _context.Shops.Add(shop);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);

            return new LoadShopsCommandResponse();
        }
    }
}

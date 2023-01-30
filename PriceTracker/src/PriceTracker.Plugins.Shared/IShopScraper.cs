using PriceTracker.Domain.Entities;

namespace PriceTracker.Plugins.Shared
{
    public interface IShopScraper
    {
        Task<Product> Scrape(string url, Product? product = null);
        Shop Shop { get; }
    }
}

using PriceTracker.Domain.Entities;

namespace PriceTracker.Plugins.Shared
{
    public interface IShopScraper
    {
        Task<Product> Scrape(string url);
        Task<Product> Scrape(Product product);
        ShopData ShopData { get; }
    }
}

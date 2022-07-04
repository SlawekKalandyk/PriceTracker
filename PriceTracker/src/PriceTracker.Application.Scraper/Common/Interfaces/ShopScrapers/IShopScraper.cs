using PriceTracker.Domain.Entities;

namespace PriceTracker.Application.Scraper.Common.Interfaces.ShopScrapers
{
    public interface IShopScraper
    {
        Task<Product> Scrape(string url, Product? product = null);
    }
}

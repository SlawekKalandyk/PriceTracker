using PriceTracker.Domain.Entities;

namespace PriceTracker.Scraper.Application.Common.Interfaces.ShopScrapers
{
    public interface IShopScraper
    {
        Task<Product> Scrape(string url, Product? product = null);
    }
}

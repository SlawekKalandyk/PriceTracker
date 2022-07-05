using PriceTracker.Domain.Entities;
using PriceTracker.Domain.Enums;

namespace PriceTracker.Scraper.Application.Common.Interfaces
{
    public interface IShopScraper
    {
        Task<Product> Scrape(string url, Product? product = null);
        Shop Shop { get; }
    }
}

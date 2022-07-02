using PriceTrackerWebApi.Core.Products;
using PriceTrackerWebApi.Core.Scrapers;

namespace PriceTrackerWebApi.Core.Scrapers.Factories
{
    public class MoreleScraperFactory : BaseScraperFactory<MoreleScraper, MoreleProduct>
    {
        public override async Task<MoreleScraper> Create(string url)
        {
            var html = await WebsiteScraper.ScrapeDynamicWebsite(url);
            return new MoreleScraper(url, html, DateTime.UtcNow);
        }
    }
}

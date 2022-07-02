using PriceTrackerWebApi.Core.Shops.Base;

namespace PriceTrackerWebApi.Core.Shops.Morele
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

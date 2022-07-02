using PriceTrackerWebApi.Core.Products;
using PriceTrackerWebApi.Core.Scrapers;

namespace PriceTrackerWebApi.Core.Scrapers.Factories
{
    public class XKomScraperFactory : BaseScraperFactory<XKomScraper, XKomProduct>
    {
        public override async Task<XKomScraper> Create(string url)
        {
            var html = await WebsiteScraper.ScrapeDynamicWebsite(url);
            return new XKomScraper(url, html, DateTime.UtcNow);
        }
    }
}

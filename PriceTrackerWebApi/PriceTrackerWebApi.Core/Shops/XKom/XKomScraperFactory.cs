using PriceTrackerWebApi.Core.Shops.Base;

namespace PriceTrackerWebApi.Core.Shops.XKom
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

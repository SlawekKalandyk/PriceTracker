using PriceTracker.Application.Scraper.Utility;

namespace PriceTracker.Application.Scraper.Shops.Base
{
    public abstract class BaseScraperFactory<TScraper, TProduct> : IDisposable
        where TScraper : BaseScraper<TProduct>
        where TProduct : BaseProduct
    {
        protected readonly UniversalWebsiteScraper WebsiteScraper;

        protected BaseScraperFactory()
        {
            WebsiteScraper = new UniversalWebsiteScraper();
        }

        public abstract Task<TScraper> Create(string url);

        public void Dispose()
        {
            WebsiteScraper.Dispose();
        }
    }
}

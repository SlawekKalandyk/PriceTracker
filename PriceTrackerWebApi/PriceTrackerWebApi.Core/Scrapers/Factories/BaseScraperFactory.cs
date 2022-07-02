using PriceTrackerWebApi.Core.Products;
using PriceTrackerWebApi.Core.Scrapers;
using PriceTrackerWebApi.Core.Utility;

namespace PriceTrackerWebApi.Core.Scrapers.Factories
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

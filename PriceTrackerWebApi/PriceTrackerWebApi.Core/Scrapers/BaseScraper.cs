using HtmlAgilityPack;
using PriceTrackerWebApi.Core.Products;
using PriceTrackerWebApi.Core.Traits;

namespace PriceTrackerWebApi.Core.Scrapers
{
    public abstract class BaseScraper<T> : IGeneralInformationScraper, IPriceScraper, IAvailabilityScraper where T : BaseProduct
    {
        protected readonly DateTime TimeStamp;
        protected readonly HtmlDocument HtmlDocument;
        protected readonly string Url;

        protected BaseScraper(string url, string html, DateTime? timeStamp = null)
        {
            Url = url;
            HtmlDocument = new HtmlDocument();
            HtmlDocument.LoadHtml(html);
            TimeStamp = timeStamp ?? DateTime.UtcNow;
        }

        public abstract T Scrape(T? product = null);

        public abstract GeneralInformation ScrapeGeneralInformation();

        public abstract Price ScrapePrice();

        public abstract Availability ScrapeAvailability();
    }
}

using HtmlAgilityPack;
using PriceTracker.Domain.Entities;
using PriceTracker.Shared.Application.Common.Interfaces;

namespace PriceTracker.Plugins.Shared
{
    public abstract class BaseShopScraper : IShopScraper
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IWebsiteScraper _websiteScraper;

        protected BaseShopScraper(IWebsiteScraper websiteScraper, IDateTimeProvider dateTimeProvider)
        {
            _websiteScraper = websiteScraper;
            _dateTimeProvider = dateTimeProvider;
        }

        public virtual async Task<Product> Scrape(string url, Product? product = null)
        {
            var timeStamp = _dateTimeProvider.Now;
            var html = await _websiteScraper.ScrapeDynamicWebsite(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            product ??= ScrapeProductInformation(url, htmlDocument);
            product.Shop ??= Shop;

            var availability = ScrapeAvailability(htmlDocument, timeStamp);
            product.AvailabilityHistory.Add(availability);
            if (availability.IsAvailable)
            {
                var price = ScrapePrice(htmlDocument, timeStamp);
                product.PriceHistory.Add(price);
            }

            return product;
        }

        public abstract Shop Shop { get; }

        protected abstract Product ScrapeProductInformation(string url, HtmlDocument htmlDocument);

        protected abstract Price ScrapePrice(HtmlDocument htmlDocument, DateTime timeStamp);

        protected abstract Availability ScrapeAvailability(HtmlDocument htmlDocument, DateTime timeStamp);
    }
}

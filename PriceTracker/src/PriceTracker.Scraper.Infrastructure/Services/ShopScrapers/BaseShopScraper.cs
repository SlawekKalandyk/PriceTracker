using HtmlAgilityPack;
using PriceTracker.Scraper.Application.Common.Interfaces;
using PriceTracker.Scraper.Application.Common.Interfaces.ShopScrapers;
using PriceTracker.Domain.Entities;
using PriceTracker.Domain.ValueObjects;

namespace PriceTracker.Scraper.Infrastructure.Services.ShopScrapers
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
            product ??= new Product
            {
                GeneralInformation = ScrapeGeneralInformation(url, htmlDocument)
            };
            product.AvailabilityHistory.Add(ScrapeAvailability(htmlDocument, timeStamp));
            product.PriceHistory.Add(ScrapePrice(htmlDocument, timeStamp));
            return product;
        }

        protected abstract GeneralProductInformation ScrapeGeneralInformation(string url, HtmlDocument htmlDocument);

        protected abstract Price ScrapePrice(HtmlDocument htmlDocument, DateTime timeStamp);

        protected abstract Availability ScrapeAvailability(HtmlDocument htmlDocument, DateTime timeStamp);
    }
}

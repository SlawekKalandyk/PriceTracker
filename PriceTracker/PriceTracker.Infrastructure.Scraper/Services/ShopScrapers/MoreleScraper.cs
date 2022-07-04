using HtmlAgilityPack;
using PriceTracker.Application.Scraper.Common.Interfaces;
using PriceTracker.Application.Scraper.Common.Interfaces.ShopScrapers;
using PriceTracker.Domain.Entities;
using PriceTracker.Domain.ValueObjects;
using System.Xml.XPath;

namespace PriceTracker.Infrastructure.Scraper.Services.ShopScrapers
{
    public class MoreleScraper : BaseShopScraper, IMoreleScraper
    {
        private readonly XPathExpression _productNameExpression = XPathExpression.Compile(@"//h1[@class='prod-name']");
        private readonly XPathExpression _currentPriceExpression = XPathExpression.Compile(@"//*[@id='product_price_brutto']");
        private readonly XPathExpression _originalPriceExpression = XPathExpression.Compile(@"//*[@class='product-price-old']");
        private readonly XPathExpression _availabilityExpression = XPathExpression.Compile(@"//*[text()[contains(., 'PRODUKT NIEDOSTĘPNY')]]");

        public MoreleScraper(IWebsiteScraper websiteScraper, IDateTimeProvider dateTimeProvider) : base(websiteScraper, dateTimeProvider)
        {
        }

        protected override GeneralProductInformation ScrapeGeneralInformation(string url, HtmlDocument htmlDocument)
        {
            var productNameNode = htmlDocument.DocumentNode.SelectSingleNode(_productNameExpression);
            var productName = productNameNode == null ? "" : productNameNode.InnerText;
            return new GeneralProductInformation
            {
                Name = productName,
                Url = url
            };
        }

        protected override Price ScrapePrice(HtmlDocument htmlDocument, DateTime timeStamp)
        {
            var originalPriceNode = htmlDocument.DocumentNode.SelectSingleNode(_originalPriceExpression);
            var currentPriceNode = htmlDocument.DocumentNode.SelectSingleNode(_currentPriceExpression);

            var currentPrice = currentPriceNode.GetAttributeValue("content", 0m);
            var originalPrice = originalPriceNode == null ? 0m : MorelePriceToDecimal(originalPriceNode.InnerText);
            var discount = originalPrice == 0m ? 0m : originalPrice - currentPrice;

            return new Price
            {
                CurrentPrice = currentPrice,
                Discount = discount,
                TimeStamp = timeStamp
            };
        }

        protected override Availability ScrapeAvailability(HtmlDocument htmlDocument, DateTime timeStamp)
        {
            var unavailableNode = htmlDocument.DocumentNode.SelectSingleNode(_availabilityExpression);
            return new Availability
            {
                IsAvailable = unavailableNode == null,
                TimeStamp = timeStamp
            };
        }

        private decimal MorelePriceToDecimal(string morelePrice)
        {
            morelePrice = morelePrice.Replace("zł", "")
                .Replace(" ", "")
                .Replace(",", "");

            if (decimal.TryParse(morelePrice, out var decimalMorelePrice))
            {
                return decimalMorelePrice;
            }

            throw new ArgumentException($"String can't be parsed to decimal: {morelePrice}");
        }
    }
}

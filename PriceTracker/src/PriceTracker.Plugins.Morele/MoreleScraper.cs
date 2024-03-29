﻿using HtmlAgilityPack;
using PriceTracker.Domain.Entities;
using PriceTracker.Plugins.Shared;
using System.Xml.XPath;

namespace PriceTracker.Plugins.Morele
{
    public class MoreleScraper : BaseShopScraper
    {
        private readonly XPathExpression _productNameExpression = XPathExpression.Compile(@"//h1[@class='prod-name']");
        private readonly XPathExpression _currentPriceExpression = XPathExpression.Compile(@"//*[@id='product_price_brutto']");
        private readonly XPathExpression _originalPriceExpression = XPathExpression.Compile(@"//*[@class='product-price-old']");
        private readonly XPathExpression _availabilityExpression = XPathExpression.Compile(@"//*[text()[contains(., 'Powiadom mnie o dostępności')]]");

        public MoreleScraper(IWebsiteScraper websiteScraper) : base(websiteScraper)
        {
        }

        public override ShopData ShopData => new()
        {
            Name = "Morele",
            DomainUrls = new[] { "www.morele.net" }
        };

        protected override Product ScrapeProductInformation(string url, HtmlDocument htmlDocument)
        {
            var productNameNode = htmlDocument.DocumentNode.SelectSingleNode(_productNameExpression);
            var productName = productNameNode == null ? "" : productNameNode.InnerText;
            return new Product
            {
                Name = productName,
                Url = url
            };
        }

        protected override Price ScrapePrice(HtmlDocument htmlDocument, DateTime timeStamp)
        {
            var originalPriceNode = htmlDocument.DocumentNode.SelectSingleNode(_originalPriceExpression);
            var currentPriceNode = htmlDocument.DocumentNode.SelectSingleNode(_currentPriceExpression);

            var currentPrice = currentPriceNode.GetAttributeValue("data-price", 0m);
            var originalPrice = originalPriceNode == null ? currentPrice : MorelePriceToDecimal(originalPriceNode.InnerText);

            return new Price
            {
                CurrentPrice = currentPrice,
                OriginalPrice = originalPrice,
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
                .Replace(",", ".");

            if (decimal.TryParse(morelePrice, out var decimalMorelePrice))
            {
                return decimalMorelePrice;
            }

            throw new ArgumentException($"String can't be parsed to decimal: {morelePrice}");
        }
    }
}

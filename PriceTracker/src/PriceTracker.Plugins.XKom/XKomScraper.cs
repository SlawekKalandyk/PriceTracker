using HtmlAgilityPack;
using PriceTracker.Domain.Entities;
using PriceTracker.Plugins.Shared;
using System.Text.RegularExpressions;
using System.Xml.XPath;

namespace PriceTracker.Plugins.XKom
{
    public class XKomScraper : BaseShopScraper
    {
        private readonly XPathExpression _addToCartXPathExpression = XPathExpression.Compile(@"//*[text()[contains(., 'Dodaj do koszyka')]]");
        private readonly XPathExpression _availabilityXPathExpression = XPathExpression.Compile(@"descendant-or-self::*[text()[contains(., 'Dostępny')]]");
        private readonly XPathExpression _pricesXPathExpression = XPathExpression.Compile(@"descendant-or-self::*[text()[contains(., 'zł')]]");
        private readonly XPathExpression _productNameXPathExpression = XPathExpression.Compile(@"//*[self::h1]");
        private readonly Regex _priceRegex = new(@"(\d+\s*,*\d*)");

        public XKomScraper(IWebsiteScraper websiteScraper) : base(websiteScraper)
        {
        }

        public override ShopData ShopData => new()
        {
            Name = "X-Kom",
            DomainUrls = new[] { "www.x-kom.pl" }
        };

        protected override Product ScrapeProductInformation(string url, HtmlDocument htmlDocument)
        {
            var productNameNode = htmlDocument.DocumentNode.SelectSingleNode(_productNameXPathExpression);
            var productName = productNameNode == null ? "" : productNameNode.InnerText;
            return new Product
            {
                Name = productName,
                Url = url
            };
        }

        protected override Price ScrapePrice(HtmlDocument htmlDocument, DateTime timeStamp)
        {
            var addToCartNode = htmlDocument.DocumentNode.SelectSingleNode(_addToCartXPathExpression);
            if (addToCartNode == null)
            {
                return new Price
                {
                    CurrentPrice = 0m,
                    Discount = 0m,
                    TimeStamp = timeStamp
                };
            }

            var priceNodesAncestor = addToCartNode
                .ParentNode
                .ParentNode
                .ParentNode
                .ParentNode
                .ParentNode
                .ParentNode;
            var nonFormattedPrices = priceNodesAncestor.SelectNodes(_pricesXPathExpression);
            var prices = priceNodesAncestor.SelectNodes(_pricesXPathExpression)
                .Where(node => !node.InnerText.Contains("Rata") && !node.InnerText.Contains("Oszczędź"))
                .Select(node => XKomPriceToDecimal(node.InnerText))
                .ToList();

            prices.Sort();

            var fullPrice = prices[^1];
            var discountedPrice = 0m;
            if (nonFormattedPrices.Any(node => node.InnerText.Contains("Oszczędź")))
            {
                discountedPrice = prices[^2];
            }

            var currentPrice = discountedPrice == 0m ? fullPrice : discountedPrice;
            var discount = fullPrice - discountedPrice;
            return new Price
            {
                CurrentPrice = currentPrice,
                Discount = discount,
                TimeStamp = timeStamp
            };
        }

        protected override Availability ScrapeAvailability(HtmlDocument htmlDocument, DateTime timeStamp)
        {
            var addToCartNode = htmlDocument.DocumentNode.SelectSingleNode(_addToCartXPathExpression);
            if (addToCartNode == null)
            {
                return new Availability
                {
                    IsAvailable = false,
                    TimeStamp = timeStamp
                };
            }

            var availabilityNodeAncestor = addToCartNode
                .ParentNode
                .ParentNode
                .ParentNode
                .ParentNode
                .ParentNode
                .ParentNode;
            return new Availability
            {
                IsAvailable = availabilityNodeAncestor.SelectSingleNode(_availabilityXPathExpression) != null,
                TimeStamp = timeStamp
            };
        }

        private decimal XKomPriceToDecimal(string xKomPrice)
        {
            var match = _priceRegex.Match(xKomPrice);
            xKomPrice = match.Value.Replace(",", ".").Replace(" ", "");
            if (decimal.TryParse(xKomPrice, out var decimalXKomPrice))
            {
                return decimalXKomPrice;
            }

            throw new ArgumentException($"String can't be parsed to decimal: {xKomPrice}");
        }
    }
}

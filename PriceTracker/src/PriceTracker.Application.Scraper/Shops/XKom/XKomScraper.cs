using System.Text.RegularExpressions;
using System.Xml.XPath;
using PriceTracker.Application.Scraper.Scrapers;
using PriceTracker.Application.Scraper.Shops.Base;
using PriceTracker.Application.Scraper.Traits;

namespace PriceTracker.Application.Scraper.Shops.XKom
{
    public class XKomScraper : BaseScraper<XKomProduct>
    {
        private readonly XPathExpression _addToCartXPathExpression = XPathExpression.Compile(@"//*[text()[contains(., 'Dodaj do koszyka')]]");
        private readonly XPathExpression _availabilityXPathExpression = XPathExpression.Compile(@"descendant-or-self::*[text()[contains(., 'Dostępny')]]");
        private readonly XPathExpression _pricesXPathExpression = XPathExpression.Compile(@"descendant-or-self::*[text()[contains(., 'zł')]]");
        private readonly XPathExpression _productNameXPathExpression = XPathExpression.Compile(@"//*[self::h1]");
        private readonly Regex _priceRegex = new(@"(\d+\s*,*\d*)");

        public XKomScraper(string url, string html, DateTime? timeStamp = null) : base(url, html, timeStamp)
        {
        }

        public override XKomProduct Scrape(XKomProduct? product = null)
        {
            product ??= new XKomProduct((this as IGeneralInformationScraper).ScrapeGeneralInformation());
            product.AvailabilityHistory.Add((this as IAvailabilityScraper).ScrapeAvailability());
            product.PriceHistory.Add((this as IPriceScraper).ScrapePrice());
            return product;
        }

        public override GeneralInformation ScrapeGeneralInformation()
        {
            var productNameNode = HtmlDocument.DocumentNode.SelectSingleNode(_productNameXPathExpression);
            var productName = productNameNode == null ? "" : productNameNode.InnerText;
            return new GeneralInformation(Url, productName);
        }

        public override Price ScrapePrice()
        {
            var addToCartNode = HtmlDocument.DocumentNode.SelectSingleNode(_addToCartXPathExpression);
            if (addToCartNode == null)
            {
                return new Price(0m, 0m, TimeStamp);
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

            return new Price(currentPrice, discount, TimeStamp);
        }

        public override Availability ScrapeAvailability()
        {
            var addToCartNode = HtmlDocument.DocumentNode.SelectSingleNode(_addToCartXPathExpression);
            if (addToCartNode == null)
            {
                return new Availability(false, TimeStamp);
            }

            var availabilityNodeAncestor = addToCartNode
                .ParentNode
                .ParentNode
                .ParentNode
                .ParentNode
                .ParentNode
                .ParentNode;
            return new Availability(availabilityNodeAncestor.SelectSingleNode(_availabilityXPathExpression) != null, TimeStamp);
        }

        private decimal XKomPriceToDecimal(string xKomPrice)
        {
            // trim 'zł'
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

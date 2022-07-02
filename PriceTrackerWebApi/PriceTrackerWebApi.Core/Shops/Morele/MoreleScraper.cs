using System.Xml.XPath;
using PriceTrackerWebApi.Core.Shops.Base;
using PriceTrackerWebApi.Core.Traits;

namespace PriceTrackerWebApi.Core.Shops.Morele
{
    public class MoreleScraper : BaseScraper<MoreleProduct>
    {
        private readonly XPathExpression _productNameExpression = XPathExpression.Compile(@"//h1[@class='prod-name']");
        private readonly XPathExpression _currentPriceExpression = XPathExpression.Compile(@"//*[@id='product_price_brutto']");
        private readonly XPathExpression _originalPriceExpression = XPathExpression.Compile(@"//*[@class='product-price-old']");
        private readonly XPathExpression _availabilityExpression = XPathExpression.Compile(@"//*[text()[contains(., 'PRODUKT NIEDOSTĘPNY')]]");

        public MoreleScraper(string url, string html, DateTime? timeStamp = null) : base(url, html, timeStamp)
        {
        }

        public override MoreleProduct Scrape(MoreleProduct? product = null)
        {
            product ??= new MoreleProduct(ScrapeGeneralInformation());
            product.AvailabilityHistory.Add(ScrapeAvailability());
            product.PriceHistory.Add(ScrapePrice());
            return product;
        }

        public override GeneralInformation ScrapeGeneralInformation()
        {
            var productNameNode = HtmlDocument.DocumentNode.SelectSingleNode(_productNameExpression);
            var productName = productNameNode == null ? "" : productNameNode.InnerText;
            return new GeneralInformation(Url, productName);
        }

        public override Price ScrapePrice()
        {
            var originalPriceNode = HtmlDocument.DocumentNode.SelectSingleNode(_originalPriceExpression);
            var currentPriceNode = HtmlDocument.DocumentNode.SelectSingleNode(_currentPriceExpression);

            var currentPrice = currentPriceNode.GetAttributeValue("content", 0m);
            var originalPrice = originalPriceNode == null ? 0m : MorelePriceToDecimal(originalPriceNode.InnerText);
            var discount = originalPrice == 0m ? 0m : originalPrice - currentPrice;

            return new Price(currentPrice, discount, TimeStamp);
        }

        public override Availability ScrapeAvailability()
        {
            var unavailableNode = HtmlDocument.DocumentNode.SelectSingleNode(_availabilityExpression);
            return new Availability(unavailableNode == null, TimeStamp);
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

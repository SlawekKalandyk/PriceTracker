using PriceTracker.Application.Scraper.Shops.XKom;

namespace PriceTracker.Tests.CoreTests
{
    public class XKomScraperTests
    {
        [Fact]
        public void ManualTests()
        {
            using var scraperFactory = new XKomScraperFactory();
            var url = @"https://www.x-kom.pl/p/597431-procesor-amd-ryzen-9-amd-ryzen-9-5900x.html";
            var scraper = scraperFactory.Create(url).Result;
            var product = scraper.Scrape();
        }
    }
}

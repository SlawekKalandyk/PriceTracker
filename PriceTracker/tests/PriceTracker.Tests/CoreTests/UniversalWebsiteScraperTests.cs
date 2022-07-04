using PriceTracker.Application.Scraper.Utility;

namespace PriceTracker.Tests.CoreTests
{
    public class UniversalWebsiteScraperTests
    {
        [Fact]
        public void ManualTests()
        {
            using var scraper = new UniversalWebsiteScraper();
            var url = "https://www.x-kom.pl/p/597431-procesor-amd-ryzen-9-amd-ryzen-9-5900x.html";
            var content = scraper.ScrapeDynamicWebsite(url).Result;
            using var scraper2 = new UniversalWebsiteScraper();
            var content2 = scraper2.ScrapeDynamicWebsite(url).Result;
        }
    }
}

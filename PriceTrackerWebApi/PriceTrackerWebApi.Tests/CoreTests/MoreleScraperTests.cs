using PriceTrackerWebApi.Core.Shops.Morele;

namespace PriceTrackerWebApi.Tests.CoreTests
{
    public class MoreleScraperTests
    {
        [Fact]
        public void ManualTests()
        {
            var unavailableUrl =
                @"https://www.morele.net/pamiec-hyperx-predator-ddr4-16-gb-3200mhz-cl16-hx432c16pb3k2-16-774211/";
            using var scraperFactory = new MoreleScraperFactory();
            var scraper = scraperFactory.Create(unavailableUrl).Result;
            var product = scraper.Scrape();
        }
    }
}

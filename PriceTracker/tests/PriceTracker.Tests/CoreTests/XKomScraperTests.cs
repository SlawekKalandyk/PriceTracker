using PriceTracker.Plugins.Shared;
using PriceTracker.Plugins.XKom;

namespace PriceTracker.Tests.CoreTests
{
    public class XKomScraperTests
    {
        [Fact]
        public async void ManualTests()
        {
            var url = @"https://www.x-kom.pl/p/735718-procesor-amd-ryzen-7-amd-ryzen-7-5700x.html";
            await using var websiteScraper = new WebsiteScraper();
            var scraper = new XKomScraper(websiteScraper);
            var task = scraper.Scrape(url);
            await task;
            var result = task.Result;
        }
    }
}

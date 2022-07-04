using PuppeteerSharp;

namespace PriceTracker.Application.Scraper.Utility
{
    public class UniversalWebsiteScraper : IDisposable
    {
        private readonly Browser? _browser;
        private readonly BrowserFactory? _browserFactory;

        public UniversalWebsiteScraper(bool websiteCanBeDynamic = true)
        {
            if (websiteCanBeDynamic)
            {
                _browserFactory = new BrowserFactory();
                _browser = _browserFactory.GetChromiumBrowser();
            }
        }

        public UniversalWebsiteScraper(BrowserFactory browserFactory)
        {
            _browserFactory = browserFactory;
            _browser = _browserFactory.GetChromiumBrowser();
        }

        public async Task<string> ScrapeDynamicWebsite(string url)
        {
            if (_browser == null)
            {
                throw new NullReferenceException("Attempted to scrape dynamic website on non-dynamic scraper");
            }

            var page = await _browser.NewPageAsync();
            await page.GoToAsync(url);
            var html = await page.GetContentAsync();
            await page.CloseAsync();
            return html;
        }

        public async Task<string> ScrapeStaticWebsite(string url)
        {
            using var client = new HttpClient();
            return await client.GetStringAsync(url);
        }

        public void Dispose()
        {
            _browserFactory?.Dispose();
        }
    }
}

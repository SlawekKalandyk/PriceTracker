using PriceTracker.Application.Scraper.Common.Interfaces;
using PuppeteerSharp;

namespace PriceTracker.Infrastructure.Scraper.Services
{
    public class WebsiteScraper : IWebsiteScraper, IDisposable
    {
        private readonly Browser _browser;
        private readonly BrowserFetcher _chromiumBrowserFetcher = new(Product.Chrome);

        public WebsiteScraper()
        {
            ClearOldChromiumDownloads();
            _browser = Puppeteer.LaunchAsync(DefaultLaunchOptions).Result;
        }

        public async Task<string> ScrapeDynamicWebsite(string url)
        {
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

        private LaunchOptions DefaultLaunchOptions => new()
        {
            Headless = true,
            ExecutablePath = _chromiumBrowserFetcher.GetExecutablePath(BrowserFetcher.DefaultChromiumRevision),
        };

        private void ClearOldChromiumDownloads()
        {
            var oldRevisions = _chromiumBrowserFetcher.LocalRevisions().Where(l => l != BrowserFetcher.DefaultChromiumRevision);

            foreach (var revision in oldRevisions)
            {
                _chromiumBrowserFetcher.Remove(revision);
            }
        }

        public void Dispose()
        {
            _browser.Disconnect();
            _browser.Dispose();
        }
    }
}

using PuppeteerSharp;

namespace PriceTracker.Plugins.Shared
{
    public class WebsiteScraper : IWebsiteScraper, IAsyncDisposable
    {
        private readonly IBrowser _browser;
        private readonly IBrowserFetcher _chromiumBrowserFetcher = new BrowserFetcher(Product.Chrome);

        public WebsiteScraper()
        {
            ClearOldChromiumDownloads();
            DownloadChromiumIfNotExists(BrowserFetcher.DefaultChromiumRevision);
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

        private void DownloadChromiumIfNotExists(string revision)
        {
            if (!File.Exists(_chromiumBrowserFetcher.GetExecutablePath(revision)))
            {
                _chromiumBrowserFetcher.DownloadAsync(revision).Wait();
            }
        }

        public async ValueTask DisposeAsync()
        {
            await _browser.CloseAsync();
            await _browser.DisposeAsync();
        }
    }
}

using PuppeteerSharp;
using System.Collections.Concurrent;

namespace PriceTracker.Application.Scraper.Utility
{
    public class BrowserFactory : IDisposable
    {
        private readonly IDictionary<LaunchOptions, Browser> _browsers = new ConcurrentDictionary<LaunchOptions, Browser>();
        private readonly BrowserFetcher _chromiumBrowserFetcher = new(Product.Chrome);
        private bool _clearedOldChromiumDownloads = false;

        private LaunchOptions DefaultLaunchOptions => new()
        {
            Headless = true,
            ExecutablePath = _chromiumBrowserFetcher.GetExecutablePath(BrowserFetcher.DefaultChromiumRevision),
        };

        public Browser GetChromiumBrowser(LaunchOptions? options = null)
        {
            options ??= DefaultLaunchOptions;
            CreateBrowserIfNotExists(options);

            return _browsers[options];
        }

        private void CreateBrowserIfNotExists(LaunchOptions options)
        {
            if (!_browsers.ContainsKey(options))
            {
                _browsers[options] = Puppeteer.LaunchAsync(options).Result;
            }
        }

        private void ClearOldChromiumDownloads()
        {
            if (_clearedOldChromiumDownloads)
            {
                return;
            }

            var oldRevisions = _chromiumBrowserFetcher.LocalRevisions().Where(l => l != BrowserFetcher.DefaultChromiumRevision);

            foreach (var revision in oldRevisions)
            {
                _chromiumBrowserFetcher.Remove(revision);
            }

            _clearedOldChromiumDownloads = true;
        }

        public void Dispose()
        {
            foreach (var browser in _browsers.Values)
            {
                browser.Disconnect();
                browser.Dispose();
            }
        }
    }
}

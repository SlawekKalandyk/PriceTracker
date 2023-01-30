namespace PriceTracker.Plugins.Shared
{
    public interface IWebsiteScraper
    { 
        Task<string> ScrapeDynamicWebsite(string url);
        Task<string> ScrapeStaticWebsite(string url);
    }
}

namespace PriceTracker.Scraper.Application.Common.Interfaces
{
    public interface IWebsiteScraper
    { 
        Task<string> ScrapeDynamicWebsite(string url);
        Task<string> ScrapeStaticWebsite(string url);
    }
}

using PriceTrackerWebApi.Core.Traits;

namespace PriceTrackerWebApi.Core.Scrapers
{
    public interface IPriceScraper
    {
        Price ScrapePrice();
    }
}

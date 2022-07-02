using PriceTrackerWebApi.Core.Traits;

namespace PriceTrackerWebApi.Core.Scrapers
{
    public interface IAvailabilityScraper
    {
        Availability ScrapeAvailability();
    }
}

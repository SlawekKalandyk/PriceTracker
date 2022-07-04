using PriceTracker.Application.Scraper.Shops.Base;
using PriceTracker.Application.Scraper.Traits;

namespace PriceTracker.Application.Scraper.Shops.Morele
{
    public record MoreleProduct(GeneralInformation GeneralInformation) : BaseProduct(GeneralInformation);
}

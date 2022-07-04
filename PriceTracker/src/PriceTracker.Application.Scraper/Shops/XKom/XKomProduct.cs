using PriceTracker.Application.Scraper.Shops.Base;
using PriceTracker.Application.Scraper.Traits;

namespace PriceTracker.Application.Scraper.Shops.XKom
{
    public record XKomProduct(GeneralInformation GeneralInformation) : BaseProduct(GeneralInformation);
}

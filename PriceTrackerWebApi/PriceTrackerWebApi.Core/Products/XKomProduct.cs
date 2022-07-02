using PriceTrackerWebApi.Core.Traits;

namespace PriceTrackerWebApi.Core.Products
{
    public record XKomProduct(GeneralInformation GeneralInformation) : BaseProduct(GeneralInformation);
}

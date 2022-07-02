using PriceTrackerWebApi.Core.Shops.Base;
using PriceTrackerWebApi.Core.Traits;

namespace PriceTrackerWebApi.Core.Shops.XKom
{
    public record XKomProduct(GeneralInformation GeneralInformation) : BaseProduct(GeneralInformation);
}

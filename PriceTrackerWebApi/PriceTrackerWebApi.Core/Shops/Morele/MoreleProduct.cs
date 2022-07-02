using PriceTrackerWebApi.Core.Shops.Base;
using PriceTrackerWebApi.Core.Traits;

namespace PriceTrackerWebApi.Core.Shops.Morele
{
    public record MoreleProduct(GeneralInformation GeneralInformation) : BaseProduct(GeneralInformation);
}

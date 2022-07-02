using PriceTrackerWebApi.Core.Traits;

namespace PriceTrackerWebApi.Core.Products
{
    public record MoreleProduct(GeneralInformation GeneralInformation) : BaseProduct(GeneralInformation);
}

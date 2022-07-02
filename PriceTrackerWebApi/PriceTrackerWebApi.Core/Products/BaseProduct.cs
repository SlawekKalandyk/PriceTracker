using PriceTrackerWebApi.Core.Traits;

namespace PriceTrackerWebApi.Core.Products
{
    public abstract record BaseProduct(GeneralInformation GeneralInformation)
    {
        public IList<Price> PriceHistory { get; } = new List<Price>();
        public IList<Availability> AvailabilityHistory { get; } = new List<Availability>();
    }
}

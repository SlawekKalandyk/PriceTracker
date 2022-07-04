using PriceTracker.Domain.Common;
using PriceTracker.Domain.ValueObjects;

namespace PriceTracker.Domain.Entities
{
    public class Product : BaseEntity
    {
        public GeneralProductInformation GeneralInformation { get; set; }

        public IList<Price> PriceHistory { get; private set; } = new List<Price>();

        public IList<Availability> AvailabilityHistory { get; private set; } = new List<Availability>();
    }
}

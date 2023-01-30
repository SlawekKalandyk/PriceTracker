using PriceTracker.Domain.Common;

namespace PriceTracker.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public bool IsTracked { get; set; } = true;
        public Shop Shop { get; set; }
        public IList<Price> PriceHistory { get; private set; } = new List<Price>();
        public IList<Availability> AvailabilityHistory { get; private set; } = new List<Availability>();
    }
}

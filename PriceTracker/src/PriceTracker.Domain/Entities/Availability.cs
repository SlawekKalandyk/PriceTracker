using PriceTracker.Domain.Common;

namespace PriceTracker.Domain.Entities
{
    public class Availability : BaseEntity
    {
        public bool IsAvailable { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}

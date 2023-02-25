using System.ComponentModel.DataAnnotations.Schema;
using PriceTracker.Domain.Common;

namespace PriceTracker.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public bool IsTracked { get; set; } = true;
        public decimal PriceNotificationThreshold { get; set; }
        public IList<Price> PriceHistory { get; } = new List<Price>();
        public IList<Availability> AvailabilityHistory { get; } = new List<Availability>();

        public Shop Shop { get; set; }

        [NotMapped]
        public Price? LastRecordedPrice => PriceHistory.MaxBy(p => p.TimeStamp);
        [NotMapped]
        public Availability? LastRecordedAvailability => AvailabilityHistory.MaxBy(a => a.TimeStamp);
        [NotMapped] 
        public DateTime? LastUpdateTime => AvailabilityHistory.MaxBy(a => a.TimeStamp)?.TimeStamp;
    }
}

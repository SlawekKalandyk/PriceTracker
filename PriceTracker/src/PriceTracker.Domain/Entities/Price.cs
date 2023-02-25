using System.ComponentModel.DataAnnotations.Schema;
using PriceTracker.Domain.Common;

namespace PriceTracker.Domain.Entities
{
    public class Price : BaseEntity
    {
        public decimal CurrentPrice { get; set; }
        public decimal Discount { get; set; } = 0m;
        public DateTime TimeStamp { get; set; }

        public Product Product { get; set; }

        [NotMapped]
        public decimal OriginalPrice => CurrentPrice + Discount;
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using PriceTracker.Domain.Common;

namespace PriceTracker.Domain.Entities
{
    public class Price : BaseEntity
    {
        public decimal CurrentPrice { get; set; }
        public decimal OriginalPrice { get; set; }
        public DateTime TimeStamp { get; set; }

        public Product Product { get; set; }

        [NotMapped] 
        public decimal Discount => OriginalPrice - CurrentPrice;

    }
}

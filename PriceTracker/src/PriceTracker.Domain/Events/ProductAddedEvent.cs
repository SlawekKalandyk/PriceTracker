using PriceTracker.Domain.Common;
using PriceTracker.Domain.Entities;

namespace PriceTracker.Domain.Events
{
    public class ProductAddedEvent : BaseEvent
    {
        public ProductAddedEvent(Product product)
        {
            Product = product;
        }

        public Product Product { get; }
    }
}

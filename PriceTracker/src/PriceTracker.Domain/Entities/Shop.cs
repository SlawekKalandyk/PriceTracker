using PriceTracker.Domain.Common;

namespace PriceTracker.Domain.Entities
{
    public class Shop : BaseEntity
    {
        public string Name { get; set; }
        public string[] DomainUrls { get; set; }
        public IList<Product> Products { get; private set; } = new List<Product>();
    }
}

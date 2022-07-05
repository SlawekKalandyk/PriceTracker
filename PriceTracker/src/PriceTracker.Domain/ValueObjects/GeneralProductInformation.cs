using PriceTracker.Domain.Common;
using PriceTracker.Domain.Enums;

namespace PriceTracker.Domain.ValueObjects
{
    public class GeneralProductInformation : ValueObject
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public Shop Shop { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Url;
            yield return Shop;
        }
    }
}

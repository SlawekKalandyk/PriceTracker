using PriceTracker.Domain.Common;

namespace PriceTracker.Domain.ValueObjects
{
    public class GeneralProductInformation : ValueObject
    {
        public string Name { get; set; }

        public string Url { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Url;
        }
    }
}

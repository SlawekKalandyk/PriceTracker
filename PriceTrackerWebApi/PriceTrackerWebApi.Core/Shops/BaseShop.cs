using PriceTrackerWebApi.Core.Products;

namespace PriceTrackerWebApi.Core.Shops
{
    public abstract class BaseShop<T> where T : BaseProduct
    {
        public IEnumerable<T> ObservedProducts { get; } = new List<T>();
    }
}

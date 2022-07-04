namespace PriceTracker.Application.Scraper.Shops.Base
{
    public abstract class BaseShop<T> where T : BaseProduct
    {
        public IEnumerable<T> ObservedProducts { get; } = new List<T>();
    }
}

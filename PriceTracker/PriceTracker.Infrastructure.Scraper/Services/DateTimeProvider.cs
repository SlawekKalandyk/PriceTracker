using PriceTracker.Application.Scraper.Common.Interfaces;

namespace PriceTracker.Infrastructure.Scraper.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        private DateTime? now;

        public DateTime Now
        {
            get
            {
                if (!now.HasValue)
                    now = DateTime.UtcNow;

                return now.Value;
            }
        }
    }
}

using PriceTracker.Scraper.Application.Common.Interfaces;

namespace PriceTracker.Scraper.Infrastructure.Services
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

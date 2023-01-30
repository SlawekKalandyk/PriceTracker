using PriceTracker.Shared.Application.Common.Interfaces;

namespace PriceTracker.Shared.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        private DateTime? now;

        public DateTime Now
        {
            get
            {
                now ??= DateTime.UtcNow;

                return now.Value;
            }
        }
    }
}

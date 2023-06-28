using PriceTracker.Notifier.Notifications;

namespace PriceTracker.Tests.NotifierTests
{
    public class NotifierTests
    {
        [Fact]
        public void ManualTests()
        {
            new NotificationBuilder()
                .AddTitle("Test title")
                .AddDescription("Test description")
                .Build()
                .Show();
        }
    }
}

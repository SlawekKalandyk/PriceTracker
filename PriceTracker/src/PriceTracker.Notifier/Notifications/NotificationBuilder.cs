namespace PriceTracker.Notifier.Notifications
{
    public class NotificationBuilder
    {
        private readonly BaseNotification _notification;

        public NotificationBuilder()
        {
            _notification = CreateNotification();
        }
        public NotificationBuilder AddTitle(string title)
        {
            _notification.Title = title;
            return this;
        }

        public NotificationBuilder AddDescription(string description)
        {
            _notification.Description = description;
            return this;
        }

        public INotification Build()
        {
            return _notification;
        }

        private BaseNotification CreateNotification()
        {
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                return new WindowsNotification();
            }

            if (Environment.OSVersion.Platform == PlatformID.Unix)
            {
                return new LinuxNotification();
            }

            throw new NotSupportedException();
        }
    }
}

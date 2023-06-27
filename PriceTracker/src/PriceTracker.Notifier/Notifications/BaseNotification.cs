namespace PriceTracker.Notifier.Notifications
{
    internal abstract class BaseNotification : INotification
    {
        public virtual string? Title { get; set; }
        public virtual string? Description { get; set; }

        public abstract void Show();
    }
}

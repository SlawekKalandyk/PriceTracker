using System.Text;
#if NET6_0_WINDOWS10_0_17763_0
using Microsoft.Toolkit.Uwp.Notifications;
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;
#endif

namespace PriceTracker.Notifier.Notifications
{
    public class WindowsNotification : BaseNotification
    {
        public override void Show()
        {
#if NET6_0_WINDOWS10_0_17763_0
            var toastBuilder = new ToastContentBuilder();
            if (Title != null)
            {
                toastBuilder = toastBuilder.AddText(Title);
            }
            if (Description != null)
            {
                toastBuilder = toastBuilder.AddText(Description);
            }

            toastBuilder.Show();
#endif
        }
    }
}

namespace PriceTracker.WinForms.Helpers
{
    public class UrlRunner
    {
        public static void Run(string url)
        {
            System.Diagnostics.Process.Start("explorer", url);
        }
    }
}

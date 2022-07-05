using Microsoft.Extensions.Hosting;

namespace PriceTracker.Scraper
{
    public class ScraperService : IHostedService, IDisposable
    {
        public ScraperService()
        {

        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }
    }
}

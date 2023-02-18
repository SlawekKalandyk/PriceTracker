using MediatR;
using Microsoft.Extensions.Hosting;
using PriceTracker.Scraper.Application.Features.Products.Commands.LoadShops;
using PriceTracker.Scraper.Application.Features.Products.Commands.UpdateTrackedProducts;

namespace PriceTracker.Scraper
{
    public class ScraperHostedService : BackgroundService
    {
        private const int IntervalMinutes = 60;
        
        private readonly IMediator _mediator;

        public ScraperHostedService(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            await _mediator.Send(new LoadShopsCommand(), cancellationToken).WaitAsync(cancellationToken);

            while (!cancellationToken.IsCancellationRequested)
            {
                await _mediator.Send(new UpdateTrackedProductsCommand(), cancellationToken);
                await Task.Delay(TimeSpan.FromMinutes(IntervalMinutes), cancellationToken);
            }
        }
    }
}

using MediatR;
using Microsoft.Extensions.Hosting;

namespace PriceTracker.Notifier
{
    public class NotifierHostedService : BackgroundService
    {
        private readonly IMediator _mediator;

        public NotifierHostedService(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {

            }
        }
    }
}

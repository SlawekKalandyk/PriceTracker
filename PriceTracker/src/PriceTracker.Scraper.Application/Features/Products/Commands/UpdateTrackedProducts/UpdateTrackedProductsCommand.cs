using MediatR;
using PriceTracker.Plugins.Shared;
using PriceTracker.Scraper.Application.Features.Products.Commands.UpdateProducts;
using PriceTracker.Scraper.Application.Features.Products.Queries.GetTrackedProducts;
using PriceTracker.Shared.Application.Common.Interfaces;

namespace PriceTracker.Scraper.Application.Features.Products.Commands.UpdateTrackedProducts
{
    public record UpdateTrackedProductsCommand : IRequest<UpdateTrackedProductsCommandResponse>
    {
    }

    public record UpdateTrackedProductsCommandResponse
    {

    }

    public class UpdateTrackedProductsCommandHandler : IRequestHandler<UpdateTrackedProductsCommand, UpdateTrackedProductsCommandResponse>
    {
        private readonly IMediator _mediator;

        public UpdateTrackedProductsCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<UpdateTrackedProductsCommandResponse> Handle(UpdateTrackedProductsCommand request, CancellationToken cancellationToken)
        {
            var getTrackedProductsResponse = await _mediator.Send(new GetTrackedProductsQuery(), cancellationToken);

            var updateProductsCommand = new UpdateProductsCommand
            {
                Products = getTrackedProductsResponse.Products
            };
            await _mediator.Send(updateProductsCommand, cancellationToken);

            return new UpdateTrackedProductsCommandResponse();
        }
    }
}

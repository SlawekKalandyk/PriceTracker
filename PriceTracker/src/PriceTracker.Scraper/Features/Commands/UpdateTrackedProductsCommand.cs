﻿using MediatR;
using PriceTracker.Shared.Features.Queries;

namespace PriceTracker.Scraper.Features.Commands
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

            var updateProductsCommand = new UpdateProductsCommand(getTrackedProductsResponse.Products);
            await _mediator.Send(updateProductsCommand, cancellationToken);

            return new UpdateTrackedProductsCommandResponse();
        }
    }
}

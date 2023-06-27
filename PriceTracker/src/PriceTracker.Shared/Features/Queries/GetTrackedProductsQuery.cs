using MediatR;
using PriceTracker.Domain.Entities;

namespace PriceTracker.Shared.Features.Queries
{
    public record GetTrackedProductsQuery : IRequest<GetTrackedProductsQueryResponse>
    {
    }

    public record GetTrackedProductsQueryResponse(IQueryable<Product> Products)
    {
    }

    public class GetTrackedProductsQueryHandler : IRequestHandler<GetTrackedProductsQuery, GetTrackedProductsQueryResponse>
    {
        private readonly IMediator _mediator;

        public GetTrackedProductsQueryHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<GetTrackedProductsQueryResponse> Handle(GetTrackedProductsQuery request, CancellationToken cancellationToken)
        {
            var products = (await _mediator.Send(new GetProductsQuery(), cancellationToken))
                .Products
                .Where(p => p.IsTracked);
            return new GetTrackedProductsQueryResponse(products);
        }
    }
}

using MediatR;
using Microsoft.EntityFrameworkCore;
using PriceTracker.Domain.Entities;
using PriceTracker.Shared.Application.Common.Interfaces;

namespace PriceTracker.Shared.Application.Features.Queries
{
    public record GetTrackedProductsQuery : IRequest<GetTrackedProductsQueryResponse>
    {
    }

    public record GetTrackedProductsQueryResponse
    {
        public IQueryable<Product> Products { get; init; }
    }

    public class GetTrackedProductsQueryHandler : IRequestHandler<GetTrackedProductsQuery, GetTrackedProductsQueryResponse>
    {
        private readonly IApplicationDbContext _context;

        public GetTrackedProductsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<GetTrackedProductsQueryResponse> Handle(GetTrackedProductsQuery request, CancellationToken cancellationToken)
        {
            var products = _context.Products.Where(p => p.IsTracked)
                .Include(p => p.Shop)
                .Include(p => p.PriceHistory)
                .Include(p => p.AvailabilityHistory);
            var response = new GetTrackedProductsQueryResponse()
            {
                Products = products
            };
            return Task.FromResult(response);
        }
    }
}

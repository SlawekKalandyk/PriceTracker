using MediatR;
using Microsoft.EntityFrameworkCore;
using PriceTracker.Domain.Entities;
using PriceTracker.Shared.Common.Interfaces;

namespace PriceTracker.Shared.Features.Queries
{
    public record GetProductsQuery : IRequest<GetProductsQueryResponse>
    {
    }

    public record GetProductsQueryResponse(IQueryable<Product> Products)
    {
    }

    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, GetProductsQueryResponse>
    {
        private readonly IApplicationDbContext _context;

        public GetProductsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GetProductsQueryResponse> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = _context.Products
                .Include(p => p.Shop)
                .Include(p => p.PriceHistory)
                .Include(p => p.AvailabilityHistory);
            return new GetProductsQueryResponse(products);
        }
    }
}

using MediatR;
using Microsoft.EntityFrameworkCore;
using PriceTracker.Domain.Entities;
using PriceTracker.Shared.Common.Interfaces;

namespace PriceTracker.Api.Features.Queries
{
    public record GetProductByIdQuery(int Id) : IRequest<GetProductByIdQueryResponse>
    {
    }

    public record GetProductByIdQueryResponse(Product? Product)
    {
    }

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdQueryResponse>
    {
        private readonly IApplicationDbContext _context;

        public GetProductByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GetProductByIdQueryResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = _context.Products
                .Include(p => p.Shop)
                .Include(p => p.PriceHistory)
                .Include(p => p.AvailabilityHistory)
                .SingleOrDefault(p => p.Id == request.Id);
            return new GetProductByIdQueryResponse(product);
        }
    }
}

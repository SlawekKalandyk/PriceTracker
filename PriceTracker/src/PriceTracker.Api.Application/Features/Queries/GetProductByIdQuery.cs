using MediatR;
using Microsoft.EntityFrameworkCore;
using PriceTracker.Domain.Entities;
using PriceTracker.Shared.Application.Common.Interfaces;

namespace PriceTracker.Api.Application.Features.Queries
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

        public Task<GetProductByIdQueryResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = _context.Products
                .Include(p => p.Shop)
                .Include(p => p.PriceHistory)
                .Include(p => p.AvailabilityHistory)
                .SingleOrDefault(p => p.Id == request.Id);
            var response = new GetProductByIdQueryResponse(product);
            return Task.FromResult(response);
        }
    }
}

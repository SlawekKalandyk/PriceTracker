using MediatR;
using PriceTracker.Domain.Entities;
using PriceTracker.Scraper.Application.Common.Interfaces;

namespace PriceTracker.Scraper.Application.Features.Products.Queries.GetTrackedProducts
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
        private readonly IScraperApplicationDbContext _context;

        public GetTrackedProductsQueryHandler(IScraperApplicationDbContext context)
        {
            _context = context;
        }

        public Task<GetTrackedProductsQueryResponse> Handle(GetTrackedProductsQuery request, CancellationToken cancellationToken)
        {
            var products = _context.Products.Where(p => p.IsTracked);
            var response = new GetTrackedProductsQueryResponse()
            {
                Products = products
            };
            return Task.FromResult(response);
        }
    }
}

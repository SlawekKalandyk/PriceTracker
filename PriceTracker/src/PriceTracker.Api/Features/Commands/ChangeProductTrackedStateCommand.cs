using MediatR;
using PriceTracker.Domain.Entities;
using PriceTracker.Shared.Common.Interfaces;

namespace PriceTracker.Api.Features.Commands
{
    public record ChangeProductTrackedStateCommand(Product Product, bool IsTracked) : IRequest<ChangeProductTrackedStateCommandResponse>
    {
    }

    public record ChangeProductTrackedStateCommandResponse(Product ChangedProduct)
    {
    }

    public class ChangeProductTrackedStateCommandHandler : IRequestHandler<ChangeProductTrackedStateCommand, ChangeProductTrackedStateCommandResponse>
    {
        private readonly IApplicationDbContext _context;

        public ChangeProductTrackedStateCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ChangeProductTrackedStateCommandResponse> Handle(ChangeProductTrackedStateCommand request, CancellationToken cancellationToken)
        {
            request.Product.IsTracked = request.IsTracked;
            _context.Products.Update(request.Product);
            await _context.SaveChangesAsync(cancellationToken);
            return new ChangeProductTrackedStateCommandResponse(request.Product);
        }
    }
}

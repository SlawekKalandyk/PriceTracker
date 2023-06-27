using MediatR;
using PriceTracker.Domain.Entities;
using PriceTracker.Shared.Common.Interfaces;

namespace PriceTracker.Api.Features.Commands
{
    public record ChangeProductNotificationThresholdCommand(Product Product, decimal NewThreshold) : IRequest<ChangeProductNotificationThresholdCommandResponse>
    {
    }

    public record ChangeProductNotificationThresholdCommandResponse(Product ChangedProduct)
    {
    }

    public class ChangeProductNotificationThresholdCommandHandler : IRequestHandler<ChangeProductNotificationThresholdCommand, ChangeProductNotificationThresholdCommandResponse>
    {
        private readonly IApplicationDbContext _context;

        public ChangeProductNotificationThresholdCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ChangeProductNotificationThresholdCommandResponse> Handle(ChangeProductNotificationThresholdCommand request, CancellationToken cancellationToken)
        {
            request.Product.PriceNotificationThreshold = request.NewThreshold;
            _context.Products.Update(request.Product);
            await _context.SaveChangesAsync(cancellationToken);
            return new ChangeProductNotificationThresholdCommandResponse(request.Product);
        }
    }
}

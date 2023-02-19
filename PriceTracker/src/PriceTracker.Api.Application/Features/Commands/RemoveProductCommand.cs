using MediatR;
using PriceTracker.Domain.Entities;
using PriceTracker.Shared.Application.Common.Interfaces;

namespace PriceTracker.Api.Application.Features.Commands
{
    public record RemoveProductCommand : IRequest<RemoveProductCommandResponse>
    {
        public Product Product { get; set; }
    }

    public record RemoveProductCommandResponse
    {
    }

    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand, RemoveProductCommandResponse>
    {
        private readonly IApplicationDbContext _context;

        public RemoveProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RemoveProductCommandResponse> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            _context.Products.Remove(request.Product);
            await _context.SaveChangesAsync(cancellationToken);

            return new RemoveProductCommandResponse();
        }
    }
}

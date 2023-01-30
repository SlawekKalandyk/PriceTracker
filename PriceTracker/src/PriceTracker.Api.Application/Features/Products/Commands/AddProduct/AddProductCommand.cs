using MediatR;
using PriceTracker.Shared.Application.Common.Interfaces;

namespace PriceTracker.Api.Application.Features.Products.Commands.AddProduct
{
    public record AddProductCommand : IRequest<AddProductCommandResponse>
    {
        public string Url { get; set; }
    }

    public record AddProductCommandResponse
    {
    }

    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, AddProductCommandResponse>
    {
        private readonly IApplicationDbContext _context;

        public AddProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<AddProductCommandResponse> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

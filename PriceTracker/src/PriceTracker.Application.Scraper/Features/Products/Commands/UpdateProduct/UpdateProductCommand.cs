using MediatR;
using PriceTracker.Application.Scraper.Common.Interfaces;

namespace PriceTracker.Application.Scraper.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<UpdateProductCommandResponse>
    {

    }

    public class UpdateProductCommandResponse
    {

    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductCommandResponse>
    {
        private readonly IScraperApplicationDbContext _context;

        public UpdateProductCommandHandler(IScraperApplicationDbContext context)
        {
            _context = context;
        }

        public Task<UpdateProductCommandResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

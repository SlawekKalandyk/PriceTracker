using MediatR;
using PriceTracker.Scraper.Application.Common.Interfaces;

namespace PriceTracker.Scraper.Application.Features.Products.Commands.UpdateProduct
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

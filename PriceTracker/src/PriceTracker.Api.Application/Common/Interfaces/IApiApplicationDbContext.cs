using Microsoft.EntityFrameworkCore;
using PriceTracker.Domain.Entities;

namespace PriceTracker.Api.Application.Common.Interfaces
{
    public interface IApiApplicationDbContext
    {
        DbSet<Product> Products { get; }
        DbSet<Price> Prices { get; }
        DbSet<Availability> Availabilities { get; }
    }
}

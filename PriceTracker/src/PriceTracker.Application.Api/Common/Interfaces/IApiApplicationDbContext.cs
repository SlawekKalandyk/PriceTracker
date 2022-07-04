using Microsoft.EntityFrameworkCore;
using PriceTracker.Domain.Entities;

namespace PriceTracker.Application.Api.Common.Interfaces
{
    public interface IApiApplicationDbContext
    {
        DbSet<Product> Products { get; }
        DbSet<Price> Prices { get; }
        DbSet<Availability> Availabilities { get; }
    }
}

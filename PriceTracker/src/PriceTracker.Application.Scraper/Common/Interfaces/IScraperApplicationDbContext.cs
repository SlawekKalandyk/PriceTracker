using Microsoft.EntityFrameworkCore;
using PriceTracker.Domain.Entities;

namespace PriceTracker.Application.Scraper.Common.Interfaces
{
    public interface IScraperApplicationDbContext
    {
        DbSet<Product> Products { get; }
        DbSet<Price> Prices { get; }
        DbSet<Availability> Availabilities { get; }
    }
}

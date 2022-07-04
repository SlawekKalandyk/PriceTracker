using Microsoft.EntityFrameworkCore;
using PriceTracker.Scraper.Application.Common.Interfaces;
using PriceTracker.Domain.Entities;
using System.Reflection;

namespace PriceTracker.Scraper.Infrastructure.Persistence
{
    public class ScraperApplicationDbContext : DbContext, IScraperApplicationDbContext
    {
        public ScraperApplicationDbContext(
            DbContextOptions<ScraperApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products => Set<Product>();

        public DbSet<Price> Prices => Set<Price>();

        public DbSet<Availability> Availabilities => Set<Availability>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using PriceTracker.Domain.Entities;
using PriceTracker.Shared.Application.Common.Interfaces;
using System.Reflection;

namespace PriceTracker.Shared.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products => Set<Product>();

        public DbSet<Price> Prices => Set<Price>();

        public DbSet<Availability> Availabilities => Set<Availability>();

        public DbSet<Shop> Shops => Set<Shop>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}

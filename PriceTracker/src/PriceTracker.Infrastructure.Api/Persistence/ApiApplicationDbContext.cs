using Microsoft.EntityFrameworkCore;
using PriceTracker.Application.Api.Common.Interfaces;
using PriceTracker.Domain.Entities;
using System.Reflection;

namespace PriceTracker.Infrastructure.Api.Persistence
{
    public class ApiApplicationDbContext : DbContext, IApiApplicationDbContext
    {
        public ApiApplicationDbContext(
            DbContextOptions<ApiApplicationDbContext> options) : base(options)
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

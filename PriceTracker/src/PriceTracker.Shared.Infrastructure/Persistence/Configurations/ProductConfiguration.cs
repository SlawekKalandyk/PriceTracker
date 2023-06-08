using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PriceTracker.Domain.Entities;

namespace PriceTracker.Shared.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(product => product.Name)
                .IsRequired();

            builder.Property(product => product.Url)
                .IsRequired();

            builder.HasMany(product => product.AvailabilityHistory)
                .WithOne(availability => availability.Product);

            builder.HasMany(product => product.PriceHistory)
                .WithOne(price => price.Product);

            builder.Property(product => product.Id)
                .UseIdentityAlwaysColumn();
        }
    }
}

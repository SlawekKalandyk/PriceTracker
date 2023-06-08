using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PriceTracker.Domain.Entities;

namespace PriceTracker.Shared.Infrastructure.Persistence.Configurations
{
    public class ShopConfiguration : IEntityTypeConfiguration<Shop>
    {
        public void Configure(EntityTypeBuilder<Shop> builder)
        {
            builder.HasIndex(shop => shop.Name)
                .IsUnique();

            builder.Property(shop => shop.DomainUrls)
                .HasConversion(
                    domainUrlsArray => JsonSerializer.Serialize(domainUrlsArray, (JsonSerializerOptions)null),
                    domainUrlsSerialized => JsonSerializer.Deserialize<string[]>(domainUrlsSerialized, (JsonSerializerOptions)null),
                    new ValueComparer<string[]>(
                        (c1, c2) => c1.SequenceEqual(c2),
                        c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                        c => c.ToArray())
                )
                .IsRequired();

            builder.Property(shop => shop.Name)
                .IsRequired();

            builder.HasMany(shop => shop.Products)
                .WithOne(product => product.Shop);

            builder.Property(shop => shop.Id)
                .UseIdentityAlwaysColumn();
        }
    }
}

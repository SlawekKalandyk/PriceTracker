using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PriceTracker.Domain.Entities;

namespace PriceTracker.Infrastructure.Api.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.OwnsOne(p => p.GeneralInformation);

            builder.Property(p => p.GeneralInformation)
                .IsRequired();
        }
    }
}

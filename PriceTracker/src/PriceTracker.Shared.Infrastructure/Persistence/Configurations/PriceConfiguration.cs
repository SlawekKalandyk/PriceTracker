using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PriceTracker.Domain.Entities;

namespace PriceTracker.Shared.Infrastructure.Persistence.Configurations
{
    public class PriceConfiguration : IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> builder)
        {
            builder.Property(price => price.CurrentPrice)
                .IsRequired();

            builder.Property(price => price.TimeStamp)
                .IsRequired();

            builder.Property(price => price.Id)
                .UseIdentityAlwaysColumn();
        }
    }
}

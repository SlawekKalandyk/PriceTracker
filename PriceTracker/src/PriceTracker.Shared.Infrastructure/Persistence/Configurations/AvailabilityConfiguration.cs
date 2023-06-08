using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PriceTracker.Domain.Entities;

namespace PriceTracker.Shared.Infrastructure.Persistence.Configurations
{
    public class AvailabilityConfiguration : IEntityTypeConfiguration<Availability>
    {
        public void Configure(EntityTypeBuilder<Availability> builder)
        {
            builder.Property(availability => availability.IsAvailable)
                .IsRequired();

            builder.Property(availability => availability.TimeStamp)
                .IsRequired();

            builder.Property(availability => availability.Id)
                .UseIdentityAlwaysColumn();
        }
    }
}

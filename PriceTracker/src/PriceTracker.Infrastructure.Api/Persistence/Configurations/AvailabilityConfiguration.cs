using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PriceTracker.Domain.Entities;

namespace PriceTracker.Infrastructure.Api.Persistence.Configurations
{
    public class AvailabilityConfiguration : IEntityTypeConfiguration<Availability>
    {
        public void Configure(EntityTypeBuilder<Availability> builder)
        {

        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PriceTracker.Domain.Entities;

namespace PriceTracker.Infrastructure.Api.Persistence.Configurations
{
    public class PriceConfiguration : IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> builder)
        {

        }
    }
}

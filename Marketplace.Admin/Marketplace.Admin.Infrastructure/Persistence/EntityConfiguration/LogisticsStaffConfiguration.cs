using Marketplace.Admin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marketplace.Admin.Infrastructure.Persistence.EntityConfiguration
{
    internal class LogisticsStaffConfiguration : IEntityTypeConfiguration<LogisticsStaff>
    {
        public void Configure(EntityTypeBuilder<LogisticsStaff> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Username).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(100).IsRequired();
        }
    }
}

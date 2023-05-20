using Marketplace.Admin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marketplace.Admin.Infrastructure.Persistence.EntityConfiguration
{
    internal class ProductRatingConfiguration : IEntityTypeConfiguration<ProductRating>
    {
        public void Configure(EntityTypeBuilder<ProductRating> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Username).IsRequired();
            builder.Property(x => x.ProductName).IsRequired();
            builder.Property(x => x.ProductId).IsRequired();
            builder.Property(x => x.Comment);
            builder.Property(x => x.Rating).IsRequired();
        }
    }
}

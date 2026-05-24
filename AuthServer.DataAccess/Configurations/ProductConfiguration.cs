using AuthServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServer.DataAccess.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Description).HasMaxLength(500).HasColumnName(nameof(Product.Description)).IsRequired().HasColumnType("text");
        builder.Property(x => x.Name).HasMaxLength(200).HasColumnName(nameof(Product.Name)).IsRequired().HasColumnType("text");
        builder.Property(x => x.Price).HasColumnName(nameof(Product.Price)).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(x => x.Quantity).HasColumnName(nameof(Product.Quantity)).HasColumnType("int").IsRequired();
        builder.Property(x => x.Color).HasMaxLength(50).HasColumnName(nameof(Product.Color)).HasColumnType("text");
        builder.Property(x => x.CreatedDate).HasColumnName(nameof(Product.CreatedDate)).IsRequired().HasColumnType("timestamptz");
        builder.Property(x => x.UpdatedDate).HasColumnName(nameof(Product.UpdatedDate)).IsRequired(false).HasColumnType("timestamptz");
    }
}

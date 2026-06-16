using AuthServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServer.DataAccess.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasColumnName(nameof(Category.Name)).IsRequired().HasMaxLength(200).HasColumnType("text");
        builder.Property(x => x.CreatedDate).HasColumnName(nameof(Category.CreatedDate)).IsRequired().HasColumnType("timestamptz");
        builder.Property(x => x.UpdatedDate).HasColumnName(nameof(Category.UpdatedDate)).IsRequired(false).HasColumnType("timestamptz");

        builder.HasData
            (
                new Category
                {
                    Id = "3a158e9b-bc1f-478f-9375-c70766af4169",
                    Name = "Electronics",
                    CreatedDate = new DateTime(2026, 06, 17, 00, 00, 00, DateTimeKind.Utc),
                    UpdatedDate = null
                },
                new Category
                {
                    Id = "ca4c8e99-f97b-46b0-9239-f06041aa281d",
                    Name = "Clothing",
                    CreatedDate = new DateTime(2026, 06, 17, 00, 00, 00, DateTimeKind.Utc),
                    UpdatedDate = null
                }
            );
    }
}

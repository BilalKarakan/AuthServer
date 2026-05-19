using AuthServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServer.DataAccess.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasColumnName(nameof(Category.Name)).IsRequired().HasMaxLength(200).HasColumnType("nvarchar(200)");
        builder.Property(x => x.CreatedDate).HasColumnName(nameof(Category.CreatedDate)).IsRequired().HasColumnType("datetime2");
        builder.Property(x => x.UpdatedDate).HasColumnName(nameof(Category.UpdatedDate)).IsRequired(false).HasColumnType("datetime2");
    }
}

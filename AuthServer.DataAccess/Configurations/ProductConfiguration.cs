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

        builder.HasData
            (
                new Product
                {
                    Id = "24e4b396-aa86-4e83-a086-1d1ce0852597",
                    Name = "Product 1",
                    Description = "Description for Product 1",
                    Price = 10.99m,
                    Quantity = 100,
                    Color = "Red",
                    CategoryId = "3a158e9b-bc1f-478f-9375-c70766af4169"
                },
                new Product
                {
                    Id = "fa63ac83-a79c-4e8e-9253-1c89f71eb086",
                    Name = "Product 2",
                    Description = "Description for Product 2",
                    Price = 19.99m,
                    Quantity = 50,
                    Color = "Blue",
                    CategoryId = "3a158e9b-bc1f-478f-9375-c70766af4169"
                },
                new Product
                {
                    Id = "d1f3e5b2-8c4a-4e9b-9f1c-2d3e5b2c4a4e",
                    Name = "Product 3",
                    Description = "Description for Product 3",
                    Price = 5.99m,
                    Quantity = 200,
                    Color = "Green",
                    CategoryId = "3a158e9b-bc1f-478f-9375-c70766af4169"
                },
                new Product
                {
                    Id = "c5ce3e4f-b1ce-4af7-bede-d593cc7307e7",
                    Name = "Product 4",
                    Description = "Description for Product 4",
                    Price = 15.49m,
                    Quantity = 75,
                    Color = "Yellow",
                    CategoryId = "ca4c8e99-f97b-46b0-9239-f06041aa281d"
                },
                new Product
                {
                    Id = "93abdee3-db79-4f9e-97eb-5f3b43b2fe43",
                    Name = "Product 5",
                    Description = "Description for Product 5",
                    Price = 25.99m,
                    Quantity = 30,
                    Color = "Black",
                    CategoryId = "ca4c8e99-f97b-46b0-9239-f06041aa281d"
                },
                new Product
                {
                    Id = "c0e9c85c-70ee-4a52-9a5f-086f1c329388",
                    Name = "Product 6",
                    Description = "Description for Product 6",
                    Price = 12.99m,
                    Quantity = 120,
                    Color = "White",
                    CategoryId = "ca4c8e99-f97b-46b0-9239-f06041aa281d"
                },
                new Product
                {
                    Id = "afb48da0-9443-4f53-a090-a53c144a76f1",
                    Name = "Product 7",
                    Description = "Description for Product 7",
                    Price = 8.99m,
                    Quantity = 150,
                    Color = "Purple",
                    CategoryId = "ca4c8e99-f97b-46b0-9239-f06041aa281d"
                }
            );
    }
}

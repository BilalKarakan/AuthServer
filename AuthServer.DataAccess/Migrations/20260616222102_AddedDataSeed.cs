using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AuthServer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { "3a158e9b-bc1f-478f-9375-c70766af4169", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Electronics", null },
                    { "ca4c8e99-f97b-46b0-9239-f06041aa281d", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clothing", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Color", "CreatedDate", "Description", "Name", "Price", "Quantity", "UpdatedDate" },
                values: new object[,]
                {
                    { "24e4b396-aa86-4e83-a086-1d1ce0852597", "3a158e9b-bc1f-478f-9375-c70766af4169", "Red", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for Product 1", "Product 1", 10.99m, 100, null },
                    { "93abdee3-db79-4f9e-97eb-5f3b43b2fe43", "ca4c8e99-f97b-46b0-9239-f06041aa281d", "Black", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for Product 5", "Product 5", 25.99m, 30, null },
                    { "afb48da0-9443-4f53-a090-a53c144a76f1", "ca4c8e99-f97b-46b0-9239-f06041aa281d", "Purple", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for Product 7", "Product 7", 8.99m, 150, null },
                    { "c0e9c85c-70ee-4a52-9a5f-086f1c329388", "ca4c8e99-f97b-46b0-9239-f06041aa281d", "White", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for Product 6", "Product 6", 12.99m, 120, null },
                    { "c5ce3e4f-b1ce-4af7-bede-d593cc7307e7", "ca4c8e99-f97b-46b0-9239-f06041aa281d", "Yellow", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for Product 4", "Product 4", 15.49m, 75, null },
                    { "d1f3e5b2-8c4a-4e9b-9f1c-2d3e5b2c4a4e", "3a158e9b-bc1f-478f-9375-c70766af4169", "Green", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for Product 3", "Product 3", 5.99m, 200, null },
                    { "fa63ac83-a79c-4e8e-9253-1c89f71eb086", "3a158e9b-bc1f-478f-9375-c70766af4169", "Blue", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for Product 2", "Product 2", 19.99m, 50, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "24e4b396-aa86-4e83-a086-1d1ce0852597");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "93abdee3-db79-4f9e-97eb-5f3b43b2fe43");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "afb48da0-9443-4f53-a090-a53c144a76f1");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "c0e9c85c-70ee-4a52-9a5f-086f1c329388");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "c5ce3e4f-b1ce-4af7-bede-d593cc7307e7");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "d1f3e5b2-8c4a-4e9b-9f1c-2d3e5b2c4a4e");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "fa63ac83-a79c-4e8e-9253-1c89f71eb086");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "3a158e9b-bc1f-478f-9375-c70766af4169");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "ca4c8e99-f97b-46b0-9239-f06041aa281d");
        }
    }
}

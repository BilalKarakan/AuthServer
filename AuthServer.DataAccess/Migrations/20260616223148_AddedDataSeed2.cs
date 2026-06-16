using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthServer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedDataSeed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "3a158e9b-bc1f-478f-9375-c70766af4169",
                column: "CreatedDate",
                value: new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "ca4c8e99-f97b-46b0-9239-f06041aa281d",
                column: "CreatedDate",
                value: new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "24e4b396-aa86-4e83-a086-1d1ce0852597",
                column: "CreatedDate",
                value: new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "93abdee3-db79-4f9e-97eb-5f3b43b2fe43",
                column: "CreatedDate",
                value: new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "afb48da0-9443-4f53-a090-a53c144a76f1",
                column: "CreatedDate",
                value: new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "c0e9c85c-70ee-4a52-9a5f-086f1c329388",
                column: "CreatedDate",
                value: new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "c5ce3e4f-b1ce-4af7-bede-d593cc7307e7",
                column: "CreatedDate",
                value: new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "d1f3e5b2-8c4a-4e9b-9f1c-2d3e5b2c4a4e",
                column: "CreatedDate",
                value: new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "fa63ac83-a79c-4e8e-9253-1c89f71eb086",
                column: "CreatedDate",
                value: new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Utc));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "3a158e9b-bc1f-478f-9375-c70766af4169",
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "ca4c8e99-f97b-46b0-9239-f06041aa281d",
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "24e4b396-aa86-4e83-a086-1d1ce0852597",
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "93abdee3-db79-4f9e-97eb-5f3b43b2fe43",
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "afb48da0-9443-4f53-a090-a53c144a76f1",
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "c0e9c85c-70ee-4a52-9a5f-086f1c329388",
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "c5ce3e4f-b1ce-4af7-bede-d593cc7307e7",
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "d1f3e5b2-8c4a-4e9b-9f1c-2d3e5b2c4a4e",
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "fa63ac83-a79c-4e8e-9253-1c89f71eb086",
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

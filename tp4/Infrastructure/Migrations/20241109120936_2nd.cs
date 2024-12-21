using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace tp4.Migrations
{
    /// <inheritdoc />
    public partial class _2nd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "id", "MembershipTypeId", "age", "email", "name" },
                values: new object[,]
                {
                    { 1, 1, 12, "jhbjfdhbvj", "maram" },
                    { 2, 2, 12, "jhbjfdhbvj", "mam" },
                    { 3, 3, 12, "jhbjfdhbvj", "marm" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "id", "DateAdded", "GenreId", "PhotoPath", "name" },
                values: new object[,]
                {
                    { 1, new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "", "Inception" },
                    { 2, new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "", "The Hangover" },
                    { 3, new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "", "The Shawshank Redemption" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}

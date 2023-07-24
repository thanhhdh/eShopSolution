using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShopSolution.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHomeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("f84c11e3-1c71-4e40-b87a-1a58d1b9eb75"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3300a200-ced0-4e52-8858-dea35fdc1919", "AQAAAAIAAYagAAAAEAvTMaGujfkCVXWCVnupvwguw/I3nfI3cFKAZOkKUfBfKteIsnTnGmny5usxOEW7WA==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 21, 2, 0, 39, 229, DateTimeKind.Local).AddTicks(6929));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("f84c11e3-1c71-4e40-b87a-1a58d1b9eb75"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a71c7683-78fc-43fa-87bb-cce651c4ef28", "AQAAAAIAAYagAAAAEOx000xCm9KSZmL/MdDI5RfDiRnkANS8zR3C/UTNLWX5PqAPooQIPzC6q95/bz3aQg==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 13, 15, 24, 10, 309, DateTimeKind.Local).AddTicks(8823));
        }
    }
}

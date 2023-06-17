using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShopSolution.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedIdentityUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("f84c11e3-1c71-4e40-b87a-1a58d1b9eb75"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3368f66a-1241-403a-aa3f-4f13d90d0fab", "AQAAAAIAAYagAAAAECLrqVA1MZCLN+u2MBgUqr2xnvKGwRhPXqaZ27ulhT50ZVf9y38g773R5iIi7jPv8A==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 15, 0, 0, 26, 17, DateTimeKind.Local).AddTicks(9129));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("f84c11e3-1c71-4e40-b87a-1a58d1b9eb75"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "83fd1da2-ceac-4815-b717-18a13103a9dc", "AQAAAAIAAYagAAAAEJDJF3tBYNtsEa3lFSGS1rJB3+XEacrFrgOzLucntttjVxemgpPneRHPxaFLC+nwyQ==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 14, 23, 48, 32, 89, DateTimeKind.Local).AddTicks(16));
        }
    }
}

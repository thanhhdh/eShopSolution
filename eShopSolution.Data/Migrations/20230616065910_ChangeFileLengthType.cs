using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShopSolution.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFileLengthType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "FileSize",
                table: "ProductImages",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("f84c11e3-1c71-4e40-b87a-1a58d1b9eb75"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "66711a91-6eff-49bd-b378-669aa2573f8c", "AQAAAAIAAYagAAAAEIDVmkz+5HofcMMwWMTK5H9aczPG1pdEs7lOoQof0zKEqvcsUNfgbDEoweiRx7lWkw==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 16, 13, 59, 10, 168, DateTimeKind.Local).AddTicks(8301));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FileSize",
                table: "ProductImages",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("f84c11e3-1c71-4e40-b87a-1a58d1b9eb75"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c4a6239d-e34a-40a9-bcb7-0231d5ce4338", "AQAAAAIAAYagAAAAEDvJ/bkDkAyEt676C2CxmWU2LiNoE5pmmRLoKZbyRfTBImCh0pyfrBHTR9XXkIcFlw==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 15, 22, 4, 7, 966, DateTimeKind.Local).AddTicks(9114));
        }
    }
}

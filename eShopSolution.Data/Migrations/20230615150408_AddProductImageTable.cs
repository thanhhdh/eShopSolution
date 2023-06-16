using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShopSolution.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddProductImageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

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
    }
}

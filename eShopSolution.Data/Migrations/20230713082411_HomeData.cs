using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eShopSolution.Data.Migrations
{
    /// <inheritdoc />
    public partial class HomeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Slides",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slides", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "Slides",
                columns: new[] { "Id", "Description", "Image", "Name", "SortOrder", "Status", "Url" },
                values: new object[,]
                {
                    { 1, "Lorem Ipsum is simply dummy text of the printing and typesetting industry", "/themes/images/carousel/1.png", "Slider 1", 1, 1, "#" },
                    { 2, "Lorem Ipsum is simply dummy text of the printing and typesetting industry", "/themes/images/carousel/2.png", "Slider 1", 2, 1, "#" },
                    { 3, "Lorem Ipsum is simply dummy text of the printing and typesetting industry", "/themes/images/carousel/3.png", "Slider 1", 3, 1, "#" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Slides");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("f84c11e3-1c71-4e40-b87a-1a58d1b9eb75"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "71050af9-8899-4681-a71e-bf3798223da0", "AQAAAAIAAYagAAAAEP425By491sfcVlTS29Q8By1mREgB8fWqbU1gCXNqHgLij33an6IKFJJpRmIbdqJIw==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 7, 19, 57, 32, 61, DateTimeKind.Local).AddTicks(6864));
        }
    }
}

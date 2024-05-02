using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hotelix.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseNumber = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreatedAt", "Name", "SoftDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 2, 18, 38, 45, 280, DateTimeKind.Local).AddTicks(1847), "Bielsko-Biała", false, new DateTime(2024, 5, 2, 18, 38, 45, 280, DateTimeKind.Local).AddTicks(1890) },
                    { 2, new DateTime(2024, 5, 2, 18, 38, 45, 280, DateTimeKind.Local).AddTicks(1895), "Kraków", false, new DateTime(2024, 5, 2, 18, 38, 45, 280, DateTimeKind.Local).AddTicks(1897) },
                    { 3, new DateTime(2024, 5, 2, 18, 38, 45, 280, DateTimeKind.Local).AddTicks(1899), "Katowice", false, new DateTime(2024, 5, 2, 18, 38, 45, 280, DateTimeKind.Local).AddTicks(1900) }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CityId", "CreatedAt", "HouseNumber", "PostalCode", "SoftDeleted", "Street", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 5, 2, 18, 38, 45, 280, DateTimeKind.Local).AddTicks(1933), 10, "43-382", false, "Tańskiego", new DateTime(2024, 5, 2, 18, 38, 45, 280, DateTimeKind.Local).AddTicks(1935) },
                    { 2, 1, new DateTime(2024, 5, 2, 18, 38, 45, 280, DateTimeKind.Local).AddTicks(1938), 12, "43-345", false, "Słowackiego", new DateTime(2024, 5, 2, 18, 38, 45, 280, DateTimeKind.Local).AddTicks(1939) },
                    { 3, 2, new DateTime(2024, 5, 2, 18, 38, 45, 280, DateTimeKind.Local).AddTicks(1942), 1, "31-436", false, "Wojska polskiego", new DateTime(2024, 5, 2, 18, 38, 45, 280, DateTimeKind.Local).AddTicks(1943) },
                    { 4, 2, new DateTime(2024, 5, 2, 18, 38, 45, 280, DateTimeKind.Local).AddTicks(1945), 24, "31-450", false, "Powstańców", new DateTime(2024, 5, 2, 18, 38, 45, 280, DateTimeKind.Local).AddTicks(1946) },
                    { 5, 3, new DateTime(2024, 5, 2, 18, 38, 45, 280, DateTimeKind.Local).AddTicks(1948), 34, "40-102", false, "Węglowa", new DateTime(2024, 5, 2, 18, 38, 45, 280, DateTimeKind.Local).AddTicks(1950) },
                    { 6, 3, new DateTime(2024, 5, 2, 18, 38, 45, 280, DateTimeKind.Local).AddTicks(1953), 4, "40-304", false, "Kopalniana", new DateTime(2024, 5, 2, 18, 38, 45, 280, DateTimeKind.Local).AddTicks(1955) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_Id",
                table: "Addresses",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Id",
                table: "Cities",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}

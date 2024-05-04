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
                    { 1, new DateTime(2024, 5, 4, 20, 22, 46, 490, DateTimeKind.Local).AddTicks(4949), "Bielsko-Biała", false, new DateTime(2024, 5, 4, 20, 22, 46, 490, DateTimeKind.Local).AddTicks(4994) },
                    { 2, new DateTime(2024, 5, 4, 20, 22, 46, 490, DateTimeKind.Local).AddTicks(5001), "Kraków", false, new DateTime(2024, 5, 4, 20, 22, 46, 490, DateTimeKind.Local).AddTicks(5003) },
                    { 3, new DateTime(2024, 5, 4, 20, 22, 46, 490, DateTimeKind.Local).AddTicks(5005), "Katowice", false, new DateTime(2024, 5, 4, 20, 22, 46, 490, DateTimeKind.Local).AddTicks(5006) }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CityId", "CreatedAt", "HouseNumber", "PostalCode", "SoftDeleted", "Street", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 5, 4, 20, 22, 46, 490, DateTimeKind.Local).AddTicks(5043), 10, "43-382", false, "Tańskiego", new DateTime(2024, 5, 4, 20, 22, 46, 490, DateTimeKind.Local).AddTicks(5045) },
                    { 2, 1, new DateTime(2024, 5, 4, 20, 22, 46, 490, DateTimeKind.Local).AddTicks(5049), 12, "43-345", false, "Słowackiego", new DateTime(2024, 5, 4, 20, 22, 46, 490, DateTimeKind.Local).AddTicks(5051) },
                    { 3, 2, new DateTime(2024, 5, 4, 20, 22, 46, 490, DateTimeKind.Local).AddTicks(5053), 1, "31-436", false, "Wojska polskiego", new DateTime(2024, 5, 4, 20, 22, 46, 490, DateTimeKind.Local).AddTicks(5054) },
                    { 4, 2, new DateTime(2024, 5, 4, 20, 22, 46, 490, DateTimeKind.Local).AddTicks(5056), 24, "31-450", false, "Powstańców", new DateTime(2024, 5, 4, 20, 22, 46, 490, DateTimeKind.Local).AddTicks(5058) },
                    { 5, 3, new DateTime(2024, 5, 4, 20, 22, 46, 490, DateTimeKind.Local).AddTicks(5060), 34, "40-102", false, "Węglowa", new DateTime(2024, 5, 4, 20, 22, 46, 490, DateTimeKind.Local).AddTicks(5061) },
                    { 6, 3, new DateTime(2024, 5, 4, 20, 22, 46, 490, DateTimeKind.Local).AddTicks(5066), 4, "40-304", false, "Kopalniana", new DateTime(2024, 5, 4, 20, 22, 46, 490, DateTimeKind.Local).AddTicks(5067) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");
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

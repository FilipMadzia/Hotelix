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
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseNumber = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Addresses_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreatedAt", "Name", "SoftDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 5, 18, 33, 38, 611, DateTimeKind.Local).AddTicks(9091), "Bielsko-Biała", false, new DateTime(2024, 5, 5, 18, 33, 38, 611, DateTimeKind.Local).AddTicks(9134) },
                    { 2, new DateTime(2024, 5, 5, 18, 33, 38, 611, DateTimeKind.Local).AddTicks(9141), "Kraków", false, new DateTime(2024, 5, 5, 18, 33, 38, 611, DateTimeKind.Local).AddTicks(9142) },
                    { 3, new DateTime(2024, 5, 5, 18, 33, 38, 611, DateTimeKind.Local).AddTicks(9144), "Katowice", false, new DateTime(2024, 5, 5, 18, 33, 38, 611, DateTimeKind.Local).AddTicks(9145) }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "SoftDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 5, 18, 33, 38, 611, DateTimeKind.Local).AddTicks(9180), "Lorem Ipsum", "Hotel Prezydent", false, new DateTime(2024, 5, 5, 18, 33, 38, 611, DateTimeKind.Local).AddTicks(9181) },
                    { 2, new DateTime(2024, 5, 5, 18, 33, 38, 611, DateTimeKind.Local).AddTicks(9185), "Lorem Ipsum", "Hotel Prezes", false, new DateTime(2024, 5, 5, 18, 33, 38, 611, DateTimeKind.Local).AddTicks(9186) },
                    { 3, new DateTime(2024, 5, 5, 18, 33, 38, 611, DateTimeKind.Local).AddTicks(9188), "Lorem Ipsum", "Hotel Kierownik", false, new DateTime(2024, 5, 5, 18, 33, 38, 611, DateTimeKind.Local).AddTicks(9190) },
                    { 4, new DateTime(2024, 5, 5, 18, 33, 38, 611, DateTimeKind.Local).AddTicks(9192), "Lorem Ipsum", "Hotel Praktykant", false, new DateTime(2024, 5, 5, 18, 33, 38, 611, DateTimeKind.Local).AddTicks(9193) },
                    { 5, new DateTime(2024, 5, 5, 18, 33, 38, 611, DateTimeKind.Local).AddTicks(9195), "Lorem Ipsum", "Hotel Stażysta", false, new DateTime(2024, 5, 5, 18, 33, 38, 611, DateTimeKind.Local).AddTicks(9196) },
                    { 6, new DateTime(2024, 5, 5, 18, 33, 38, 611, DateTimeKind.Local).AddTicks(9199), "Lorem Ipsum", "Hotel Senior", false, new DateTime(2024, 5, 5, 18, 33, 38, 611, DateTimeKind.Local).AddTicks(9200) }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CityId", "CreatedAt", "HotelId", "HouseNumber", "PostalCode", "SoftDeleted", "Street", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 5, 5, 18, 33, 38, 611, DateTimeKind.Local).AddTicks(9229), 1, 10, "43-382", false, "Tańskiego", new DateTime(2024, 5, 5, 18, 33, 38, 611, DateTimeKind.Local).AddTicks(9230) },
                    { 2, 1, new DateTime(2024, 5, 5, 18, 33, 38, 611, DateTimeKind.Local).AddTicks(9236), 2, 12, "43-345", false, "Słowackiego", new DateTime(2024, 5, 5, 18, 33, 38, 611, DateTimeKind.Local).AddTicks(9237) },
                    { 3, 2, new DateTime(2024, 5, 5, 18, 33, 38, 611, DateTimeKind.Local).AddTicks(9240), 3, 1, "31-436", false, "Wojska polskiego", new DateTime(2024, 5, 5, 18, 33, 38, 611, DateTimeKind.Local).AddTicks(9241) },
                    { 4, 2, new DateTime(2024, 5, 5, 18, 33, 38, 611, DateTimeKind.Local).AddTicks(9243), 4, 24, "31-450", false, "Powstańców", new DateTime(2024, 5, 5, 18, 33, 38, 611, DateTimeKind.Local).AddTicks(9244) },
                    { 5, 3, new DateTime(2024, 5, 5, 18, 33, 38, 611, DateTimeKind.Local).AddTicks(9248), 5, 34, "40-102", false, "Węglowa", new DateTime(2024, 5, 5, 18, 33, 38, 611, DateTimeKind.Local).AddTicks(9249) },
                    { 6, 3, new DateTime(2024, 5, 5, 18, 33, 38, 611, DateTimeKind.Local).AddTicks(9252), 6, 4, "40-304", false, "Kopalniana", new DateTime(2024, 5, 5, 18, 33, 38, 611, DateTimeKind.Local).AddTicks(9253) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_HotelId",
                table: "Addresses",
                column: "HotelId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}

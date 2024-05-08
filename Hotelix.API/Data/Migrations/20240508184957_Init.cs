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

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Hotels_HotelId",
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
                    { 1, new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(1812), "Bielsko-Biała", false, new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(1868) },
                    { 2, new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(1877), "Kraków", false, new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(1880) },
                    { 3, new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(1883), "Katowice", false, new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(1884) }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "SoftDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(1936), "Lorem Ipsum", "Hotel Prezydent", false, new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(1939) },
                    { 2, new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(1946), null, "Hotel Prezes", false, new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(1948) },
                    { 3, new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(1951), "Lorem Ipsum", "Hotel Kierownik", false, new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(1953) },
                    { 4, new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(1956), null, "Hotel Praktykant", false, new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(1957) },
                    { 5, new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(1960), "Lorem Ipsum", "Hotel Stażysta", false, new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(1961) },
                    { 6, new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(1967), null, "Hotel Senior", false, new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(1969) }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CityId", "CreatedAt", "HotelId", "HouseNumber", "PostalCode", "SoftDeleted", "Street", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(2009), 1, 10, "43-382", false, "Tańskiego", new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(2012) },
                    { 2, 1, new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(2018), 2, 12, "43-345", false, "Słowackiego", new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(2021) },
                    { 3, 2, new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(2026), 3, 1, "31-436", false, "Wojska polskiego", new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(2029) },
                    { 4, 2, new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(2034), 4, 24, "31-450", false, "Powstańców", new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(2037) },
                    { 5, 3, new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(2041), 5, 34, "40-102", false, "Węglowa", new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(2044) },
                    { 6, 3, new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(2050), 6, 4, "40-304", false, "Kopalniana", new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(2053) }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "CreatedAt", "Email", "HotelId", "PhoneNumber", "SoftDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(2096), "prezydent@hotelix.pl", 1, "123 456 789", false, new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(2098) },
                    { 2, new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(2103), null, 2, "123 456 789", false, new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(2104) },
                    { 3, new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(2107), "kierownik@hotelix.pl", 3, null, false, new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(2109) },
                    { 4, new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(2112), "praktykant@hotelix.pl", 4, "123 456 789", false, new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(2115) },
                    { 5, new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(2117), null, 5, "123 456 789", false, new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(2119) },
                    { 6, new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(2123), "senior@hotelix.pl", 6, null, false, new DateTime(2024, 5, 8, 20, 49, 57, 59, DateTimeKind.Local).AddTicks(2125) }
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

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_HotelId",
                table: "Contacts",
                column: "HotelId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}

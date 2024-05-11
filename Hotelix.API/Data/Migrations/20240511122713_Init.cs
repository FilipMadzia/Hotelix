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
                    PricePerNight = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    HasInternet = table.Column<bool>(type: "bit", nullable: false),
                    HasTelevision = table.Column<bool>(type: "bit", nullable: false),
                    HasParking = table.Column<bool>(type: "bit", nullable: false),
                    HasCafeteria = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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
                    { 1, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6015), "Bielsko-Biała", false, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6059) },
                    { 2, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6066), "Kraków", false, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6068) },
                    { 3, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6070), "Katowice", false, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6071) }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "CreatedAt", "Description", "HasCafeteria", "HasInternet", "HasParking", "HasTelevision", "Name", "PricePerNight", "SoftDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6114), "Lorem Ipsum", false, true, true, false, "Hotel Prezydent", 0m, false, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6116) },
                    { 2, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6122), null, false, false, false, true, "Hotel Prezes", 0m, false, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6123) },
                    { 3, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6125), "Lorem Ipsum", true, false, true, false, "Hotel Kierownik", 0m, false, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6126) },
                    { 4, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6129), null, false, false, false, false, "Hotel Praktykant", 0m, false, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6131) },
                    { 5, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6132), "Lorem Ipsum", false, false, false, false, "Hotel Stażysta", 0m, false, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6134) },
                    { 6, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6137), null, false, true, false, false, "Hotel Senior", 0m, false, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6138) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Password", "SoftDeleted", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6302), "fikunia123", false, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6304), "FilipMadzia" },
                    { 2, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6306), "kochamBobry", false, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6308), "WojtekWróbel" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CityId", "CreatedAt", "HotelId", "HouseNumber", "PostalCode", "SoftDeleted", "Street", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6201), 1, 10, "43-382", false, "Tańskiego", new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6203) },
                    { 2, 1, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6211), 2, 12, "43-345", false, "Słowackiego", new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6212) },
                    { 3, 2, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6215), 3, 1, "31-436", false, "Wojska polskiego", new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6216) },
                    { 4, 2, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6218), 4, 24, "31-450", false, "Powstańców", new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6219) },
                    { 5, 3, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6221), 5, 34, "40-102", false, "Węglowa", new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6223) },
                    { 6, 3, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6226), 6, 4, "40-304", false, "Kopalniana", new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6228) }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "CreatedAt", "Email", "HotelId", "PhoneNumber", "SoftDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6254), "prezydent@hotelix.pl", 1, "123 456 789", false, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6256) },
                    { 2, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6260), null, 2, "123 456 789", false, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6261) },
                    { 3, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6263), "kierownik@hotelix.pl", 3, null, false, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6264) },
                    { 4, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6266), "praktykant@hotelix.pl", 4, "123 456 789", false, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6267) },
                    { 5, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6269), null, 5, "123 456 789", false, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6270) },
                    { 6, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6273), "senior@hotelix.pl", 6, null, false, new DateTime(2024, 5, 11, 14, 27, 12, 984, DateTimeKind.Local).AddTicks(6274) }
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
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}

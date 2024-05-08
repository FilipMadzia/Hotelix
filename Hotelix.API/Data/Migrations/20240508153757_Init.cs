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
                    CoverImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    { 1, new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(8847), "Bielsko-Biała", false, new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(8891) },
                    { 2, new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(8897), "Kraków", false, new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(8898) },
                    { 3, new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(8900), "Katowice", false, new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(8901) }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "CoverImagePath", "CreatedAt", "Description", "Name", "SoftDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Images\\Covers\\background.jpg", new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(8934), "Lorem Ipsum", "Hotel Prezydent", false, new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(8935) },
                    { 2, "Images\\Covers\\background2.jpg", new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(8953), null, "Hotel Prezes", false, new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(8954) },
                    { 3, "Images\\Covers\\background3.jpg", new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(8957), "Lorem Ipsum", "Hotel Kierownik", false, new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(8958) },
                    { 4, "Images\\Covers\\background4.jpg", new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(8961), null, "Hotel Praktykant", false, new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(8963) },
                    { 5, "Images\\Covers\\background5.jpg", new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(8965), "Lorem Ipsum", "Hotel Stażysta", false, new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(8966) },
                    { 6, "Images\\Covers\\background6.jpg", new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(8970), null, "Hotel Senior", false, new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(8972) }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CityId", "CreatedAt", "HotelId", "HouseNumber", "PostalCode", "SoftDeleted", "Street", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(8999), 1, 10, "43-382", false, "Tańskiego", new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9000) },
                    { 2, 1, new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9005), 2, 12, "43-345", false, "Słowackiego", new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9006) },
                    { 3, 2, new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9008), 3, 1, "31-436", false, "Wojska polskiego", new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9010) },
                    { 4, 2, new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9012), 4, 24, "31-450", false, "Powstańców", new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9013) },
                    { 5, 3, new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9015), 5, 34, "40-102", false, "Węglowa", new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9016) },
                    { 6, 3, new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9019), 6, 4, "40-304", false, "Kopalniana", new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9020) }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "CreatedAt", "Email", "HotelId", "PhoneNumber", "SoftDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9046), "prezydent@hotelix.pl", 1, "123 456 789", false, new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9047) },
                    { 2, new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9052), null, 2, "123 456 789", false, new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9053) },
                    { 3, new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9055), "kierownik@hotelix.pl", 3, null, false, new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9056) },
                    { 4, new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9058), "praktykant@hotelix.pl", 4, "123 456 789", false, new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9059) },
                    { 5, new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9061), null, 5, "123 456 789", false, new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9062) },
                    { 6, new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9065), "senior@hotelix.pl", 6, null, false, new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9066) }
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

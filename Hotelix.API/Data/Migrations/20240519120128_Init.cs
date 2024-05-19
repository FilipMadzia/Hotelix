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
                    { 1, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8593), "Bielsko-Biała", false, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8637) },
                    { 2, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8648), "Kraków", false, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8649) },
                    { 3, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8651), "Katowice", false, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8652) }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "CreatedAt", "Description", "HasCafeteria", "HasInternet", "HasParking", "HasTelevision", "Name", "PricePerNight", "SoftDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8686), "Hotel Prezydent to kwintesencja luksusu i wygody, położony w samym sercu miasta. Ten prestiżowy hotel oferuje swoim gościom nie tylko wyjątkowe wnętrza, ale również najnowocześniejsze udogodnienia, takie jak telewizja satelitarna i szybki internet bezprzewodowy. Każdy pokój w hotelu został zaprojektowany z myślą o komforcie i stylu, zapewniając idealne warunki do odpoczynku i pracy. Goście mogą delektować się wyśmienitymi daniami w eleganckiej jadalni, gdzie serwowane są potrawy przygotowane przez renomowanych szefów kuchni. Hotelowa restauracja słynie z doskonałej kuchni i obsługi na najwyższym poziomie. Hotel Prezydent jest doskonałym miejscem dla tych, którzy pragną połączyć relaks z rozrywką. Tuż obok hotelu znajduje się słynne kasyno, które przyciąga miłośników gier i emocji. To idealne miejsce na spędzenie wieczoru, próbując szczęścia w grach karcianych czy ruletce. Zapraszamy do Hotelu Prezydenta, gdzie luksus spotyka się z komfortem, a każdy pobyt staje się niezapomnianym doświadczeniem.", true, true, false, true, "Hotel Prezydent", 69.99m, false, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8688) },
                    { 2, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8696), null, false, false, false, true, "Hotel Prezes", 52.00m, false, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8698) },
                    { 3, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8700), "Hotel Kierownik to oaza spokoju i luksusu, położona na przedmieściach, z dala od miejskiego zgiełku. Ten elegancki hotel zaprasza gości do przestronnych i komfortowo urządzonych pokoi, gdzie każdy detal został dopracowany z największą starannością. Centralnym punktem hotelu jest luksusowa jadalnia, która zachwyca nie tylko wykwintnym menu, ale również wyrafinowanym wystrojem. To tutaj, wśród delikatnych tkanin i lśniącego srebra, goście mogą cieszyć się wyjątkowymi daniami kuchni międzynarodowej i lokalnej, przygotowywanymi przez doświadczonych szefów kuchni. Hotel Kierownik szczyci się również przestronnym parkingiem, który zapewnia wygodę i bezpieczeństwo dla wszystkich odwiedzających. Dzięki temu goście mogą bez problemu podróżować własnym samochodem i cieszyć się łatwym dostępem do hotelu. Położony wśród zielonych terenów przedmieścia, hotel stanowi idealne miejsce dla tych, którzy szukają ciszy i relaksu, jednocześnie pragnąc zachować łatwy dostęp do atrakcji miejskich. Hotel Kierownik to wyjątkowe miejsce, które zapewnia niezapomniane wrażenia i najwyższy standard obsługi.", true, false, true, false, "Hotel Kierownik", 40.00m, false, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8701) },
                    { 4, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8704), null, false, false, false, false, "Hotel Praktykant", 1.99m, false, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8705) },
                    { 5, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8707), null, false, true, false, false, "Hotel Stażysta", 0.99m, false, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8708) },
                    { 6, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8711), "Hotel Senior to synonim wygody i spokoju, idealnie dostosowany do potrzeb osób starszych. Położony w cichej i bezpiecznej okolicy, hotel zapewnia swoim gościom komfortowy i dostojny wypoczynek. Wnętrza hotelu są przestronne i łatwo dostępne, co gwarantuje wygodę użytkowania przez osoby w każdym wieku. W jadalni hotelowej goście mogą cieszyć się bogatym wyborem potraw, które są nie tylko smaczne, ale również dostosowane do różnorodnych diet i potrzeb żywieniowych. Każdy posiłek jest przygotowywany z myślą o zdrowiu i zadowoleniu gości, co czyni jadalnię sercem hotelu. Hotel Senior oferuje również rozrywkę dzięki telewizji satelitarnej z mnóstwem kanałów, które umożliwiają dostęp do ulubionych programów, filmów i seriali. To idealne rozwiązanie dla tych, którzy cenią sobie relaks przy dobrej telewizji. Z myślą o pełnym komforcie, hotel zapewnia szereg udogodnień, takich jak obsługa pokoju, pomoc w organizacji czasu wolnego oraz transport do pobliskich atrakcji. Hotel Senior to miejsce, gdzie tradycja gościnności łączy się z nowoczesnymi rozwiązaniami, tworząc idealne warunki dla seniorów pragnących spędzić czas w przyjaznej i eleganckiej atmosferze.", true, false, false, true, "Hotel Senior", 15.99m, false, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8713) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Password", "SoftDeleted", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8913), "fikunia123", false, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8915), "FilipMadzia" },
                    { 2, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8918), "kochamBobry", false, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8919), "WojtekWróbel" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CityId", "CreatedAt", "HotelId", "HouseNumber", "PostalCode", "SoftDeleted", "Street", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8744), 1, 10, "43-382", false, "Tańskiego", new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8812) },
                    { 2, 1, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8818), 2, 12, "43-345", false, "Słowackiego", new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8819) },
                    { 3, 2, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8822), 3, 1, "31-436", false, "Wojska polskiego", new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8823) },
                    { 4, 2, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8825), 4, 24, "31-450", false, "Powstańców", new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8826) },
                    { 5, 3, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8828), 5, 34, "40-102", false, "Węglowa", new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8829) },
                    { 6, 3, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8832), 6, 4, "40-304", false, "Kopalniana", new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8834) }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "CreatedAt", "Email", "HotelId", "PhoneNumber", "SoftDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8867), "prezydent@hotelix.pl", 1, "123 456 789", false, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8869) },
                    { 2, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8873), null, 2, "123 456 789", false, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8874) },
                    { 3, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8876), "kierownik@hotelix.pl", 3, null, false, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8877) },
                    { 4, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8879), "praktykant@hotelix.pl", 4, "123 456 789", false, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8880) },
                    { 5, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8882), null, 5, "123 456 789", false, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8883) },
                    { 6, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8886), "senior@hotelix.pl", 6, null, false, new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8887) }
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

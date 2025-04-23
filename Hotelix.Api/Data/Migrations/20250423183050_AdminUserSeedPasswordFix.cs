using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hotelix.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdminUserSeedPasswordFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af3149d7-4d9e-4ebe-955e-146901e400f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d56148c9-c6a5-4569-9389-1034d05b6f56");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6ea2ca20-b617-45e7-9e63-48310a1d4a69", "d499bbc9-891e-4982-ada3-f3ab894ccc3f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ea2ca20-b617-45e7-9e63-48310a1d4a69");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d499bbc9-891e-4982-ada3-f3ab894ccc3f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "42e3e43c-c3de-4fc6-a020-3f43ccec7d7b", "6794c240-227e-4b49-9a7a-a60ab896e9de", "HotelManager", "HOTELMANAGER" },
                    { "4f833339-9179-48da-a7ae-6d27ba33ac3a", "b51582e8-8047-4a61-96ad-7b8fc070adac", "HotelWorker", "HOTELWORKER" },
                    { "62b76ff3-a1d7-45be-b069-3cdeee3c22e7", "60f54b64-1bf0-4770-9e5d-3af8051014ca", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SoftDeleted", "TwoFactorEnabled", "UserName" },
                values: new object[] { "be36a3cc-def2-41a2-848a-b08d79dcafc1", 0, "90828777-0678-488b-9d8c-523c94d78170", "admin@admin.admin", false, false, null, "ADMIN@ADMIN.ADMIN", "ADMIN@ADMIN.ADMIN", "AQAAAAIAAYagAAAAEHVrDy6KLa5wa8KmcbwC/y3geq+LjQLN4u+B3iPHm/j0vCyBpLf4cdPT8NNWgSBTTw==", null, false, "9f5bd4da-cbd6-44cf-b0a7-4bb73a8cdb79", false, false, "admin@admin.admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "62b76ff3-a1d7-45be-b069-3cdeee3c22e7", "be36a3cc-def2-41a2-848a-b08d79dcafc1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42e3e43c-c3de-4fc6-a020-3f43ccec7d7b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f833339-9179-48da-a7ae-6d27ba33ac3a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "62b76ff3-a1d7-45be-b069-3cdeee3c22e7", "be36a3cc-def2-41a2-848a-b08d79dcafc1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62b76ff3-a1d7-45be-b069-3cdeee3c22e7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "be36a3cc-def2-41a2-848a-b08d79dcafc1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6ea2ca20-b617-45e7-9e63-48310a1d4a69", "75b6634b-8b8f-4c27-bad1-ea02a8b8f535", "Administrator", "ADMINISTRATOR" },
                    { "af3149d7-4d9e-4ebe-955e-146901e400f8", "fae1e366-b460-4b33-af78-ad3185e0cd89", "HotelWorker", "HOTELWORKER" },
                    { "d56148c9-c6a5-4569-9389-1034d05b6f56", "a06ee5d4-6e99-4f60-9840-533a1caeb352", "HotelManager", "HOTELMANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SoftDeleted", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d499bbc9-891e-4982-ada3-f3ab894ccc3f", 0, "5d8bf105-0f38-40ab-92b6-4543a03f3a75", "admin@admin.admin", false, false, null, "ADMIN@ADMIN.ADMIN", "ADMIN@ADMIN.ADMIN", null, null, false, "0195ef8c-a783-4427-9a40-419d24303360", false, false, "admin@admin.admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6ea2ca20-b617-45e7-9e63-48310a1d4a69", "d499bbc9-891e-4982-ada3-f3ab894ccc3f" });
        }
    }
}

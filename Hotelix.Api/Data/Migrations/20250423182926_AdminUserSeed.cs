using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hotelix.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdminUserSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f55f154-1d83-406e-8953-b90c30c4c77e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5e545e4-255a-4398-80f9-70a7a63d51d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7c84a39-8c1e-4f98-afa2-3267bc0f3c8a");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "1f55f154-1d83-406e-8953-b90c30c4c77e", "764706a3-3229-4fa7-893b-c035f08ea249", "Administrator", "ADMINISTRATOR" },
                    { "a5e545e4-255a-4398-80f9-70a7a63d51d7", "855b6c7f-f093-4874-8d21-6ee37ddd843b", "HotelWorker", "HOTELWORKER" },
                    { "f7c84a39-8c1e-4f98-afa2-3267bc0f3c8a", "5552ac83-22a7-4c61-89b3-4f7ce24c5cd8", "HotelManager", "HOTELMANAGER" }
                });
        }
    }
}

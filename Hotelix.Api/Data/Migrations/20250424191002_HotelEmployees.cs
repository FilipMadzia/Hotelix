using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hotelix.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class HotelEmployees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "HotelId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "298b4a92-c625-42fe-9286-e1f13d6caa70", "d7f86b40-18a9-4fbd-a864-20df4611323c", "Administrator", "ADMINISTRATOR" },
                    { "6b2dcedd-3fb2-4a8b-9c07-5ef680d70ea3", "2d314191-2289-45da-95ed-315090d9507c", "HotelWorker", "HOTELWORKER" },
                    { "f99cd219-bf4a-493b-975d-b1f9951caa84", "0376f368-e026-40fb-8620-c8350d858e27", "HotelManager", "HOTELMANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "HotelId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SoftDeleted", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5a4f282c-d31e-45cc-9ca6-bc7bd9500a7d", 0, "505ad5ae-7e9d-4220-a21e-b9eee6b725ca", "admin@admin.admin", false, null, false, null, "ADMIN@ADMIN.ADMIN", "ADMIN@ADMIN.ADMIN", "AQAAAAIAAYagAAAAELnHaiKTkGH9t88RWX1lXh+alPzm+fPpOuvKWRFWecb3/u3t+6rXbvmKTsSA8vLEEw==", null, false, "67f5aeca-57ab-4fbd-8749-4d42c94a75bf", false, false, "admin@admin.admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "298b4a92-c625-42fe-9286-e1f13d6caa70", "5a4f282c-d31e-45cc-9ca6-bc7bd9500a7d" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_HotelId",
                table: "AspNetUsers",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Hotels_HotelId",
                table: "AspNetUsers",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Hotels_HotelId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_HotelId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b2dcedd-3fb2-4a8b-9c07-5ef680d70ea3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f99cd219-bf4a-493b-975d-b1f9951caa84");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "298b4a92-c625-42fe-9286-e1f13d6caa70", "5a4f282c-d31e-45cc-9ca6-bc7bd9500a7d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "298b4a92-c625-42fe-9286-e1f13d6caa70");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a4f282c-d31e-45cc-9ca6-bc7bd9500a7d");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "AspNetUsers");

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
    }
}

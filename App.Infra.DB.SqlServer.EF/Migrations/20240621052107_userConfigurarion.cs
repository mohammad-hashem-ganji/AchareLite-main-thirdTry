using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infra.DB.SqlServer.EF.Migrations
{
    public partial class userConfigurarion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "4b248aa0-420f-48ac-b811-e4bb3a5ff273", "Admin", "ADMIN" },
                    { 2, "d3efe057-e6bc-4827-9e5a-0f70fa79a242", "Customer", "CUSTOMER" },
                    { 3, "396d9142-3ec8-4428-a936-0d8a08ba462e", "expert", "EXPERT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "96ab7b01-e796-4834-8ebc-6e9cd93a6c85", "admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEAJQDhI9W97MsUa1xZu4niZ0764txR8Yrg1hEyKgJiO6r+7W4SLHBejuKEmRq6xxBg==", "09179197331", false, "2ce38d89-b5b8-4604-b236-469ba4911f1d", false, "admin" },
                    { 2, 0, "ee7ed3da-a3ef-49a0-a3e2-dd0bd51c207c", "mohammad@gmail.com", false, false, null, "MOHAMMAD@GMAIL.COM", "MOHAMMAD", "AQAAAAEAACcQAAAAELpDm21QRmnRJotpJcVo/ZdEkbEchYaycPxU8KK6C+Mwcmx0IascX229VnItxaVyfQ==", "09179197331", false, "2c64eeba-32cd-44e8-b49a-6136dd40417c", false, "mohammad" },
                    { 3, 0, "902f93d9-0264-497f-820b-19c15d9cfcaa", "expert@gmail.com", false, false, null, "EXPERT@GMAIL.COM", "EXPERT", "AQAAAAEAACcQAAAAEC1b1i96C0TuES3j13v34ewzjxyNU7CsPCkP/JtPIcgrGZq6oqn9xSJ5kooQl7rfFQ==", "09179197331", false, "cdaf8ac9-8285-4821-b090-c5f7c4bffde9", false, "expert" },
                    { 4, 0, "ed52f21e-7050-413e-90d7-4cde134f32ae", "negin@gmail.com", false, false, null, "NEGIN@GMAIL.COM", "NEGIN", "AQAAAAEAACcQAAAAENATUtnXfXoSmNCUmwfkZv5XDzTJpU5FDRBxlP48UEvKFeIqd+Tf4NLDAY4U4zj7JQ==", "09179197331", false, "7f6578a1-94e8-4db0-bae6-4707a0b1ca91", false, "negin" },
                    { 5, 0, "6de94538-226c-4096-a631-be7e62e35932", "ahmad@gmail.com", false, false, null, "AHMAD@GMAIL.COM", "AHMAD", "AQAAAAEAACcQAAAAEJItY7TpdYyVjrp3G/7d05y6dnYASloOvgL26B2JU2C5cUOPjZdso9ZPeKk6JXDfcQ==", "09179197331", false, "331134bb-8a92-4e38-885e-04164f669839", false, "ahmad" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 2, 4 },
                    { 3, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}

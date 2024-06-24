using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infra.DB.SqlServer.EF.Migrations
{
    public partial class l : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NCode",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Mobile",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "User",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "0a942074-3636-4be7-a2ec-d8b2fb9c68f9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "3fc4adad-2c09-45f1-a50b-d01a04fa3225");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "91deefd2-6a9b-411b-ac08-9a4e8662831f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f19a960-0177-4272-92ea-b962cdcdb2eb", "AQAAAAEAACcQAAAAEGcBJsh+3haXakhyRSR90z0NGi9r4sRvYEOqCrtABlP+W6Gxe7yISEj+SAKSO69WCA==", "0486a712-6d0d-42b3-b9bc-ed046fc74766" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f34d4d5-2785-46c1-b63b-a3739d18cd38", "AQAAAAEAACcQAAAAEAqgr22u3mT2HF3TBRNLXjJbRVjIif0PulUXyLLDO1gDJ44VPDnMUi2D0qX6jF1WIw==", "5fbf916b-5540-4db2-a6a7-853b70427725" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a31f41c9-93e6-4d4f-a17a-56a7566cfd4e", "AQAAAAEAACcQAAAAEIMPdHfig1TZ3bSbkJso1qvJT04lUukWl/IDHCJET3MhnQ1aIgNnFvFWYiZOUBqovw==", "efd16ec0-56aa-4f4a-9b54-20a3b8d9b367" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6c0cdf7-c6b3-4cd3-83c4-2704c77f73fe", "AQAAAAEAACcQAAAAEP48yzjKw+l3UGok9jp/VpsMMu5MVMhjGqfvsOhhpyDmvLDU744RPZuEu6IMgjCnig==", "3d4ef384-c691-4e3d-b59b-76c6fcacc5e5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d1553977-c183-49ff-9cd7-4ba19cd37c1f", "AQAAAAEAACcQAAAAEPDZtfCJ1hz7oNIUP3D0vS1nlSo0mgGF5fO8HP3HizvOzeBxAsDzA/8P2kH36bVeBw==", "53d790a9-63f0-4cf8-a9af-87107fd32eae" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NCode",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mobile",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "4b248aa0-420f-48ac-b811-e4bb3a5ff273");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "d3efe057-e6bc-4827-9e5a-0f70fa79a242");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "396d9142-3ec8-4428-a936-0d8a08ba462e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96ab7b01-e796-4834-8ebc-6e9cd93a6c85", "AQAAAAEAACcQAAAAEAJQDhI9W97MsUa1xZu4niZ0764txR8Yrg1hEyKgJiO6r+7W4SLHBejuKEmRq6xxBg==", "2ce38d89-b5b8-4604-b236-469ba4911f1d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee7ed3da-a3ef-49a0-a3e2-dd0bd51c207c", "AQAAAAEAACcQAAAAELpDm21QRmnRJotpJcVo/ZdEkbEchYaycPxU8KK6C+Mwcmx0IascX229VnItxaVyfQ==", "2c64eeba-32cd-44e8-b49a-6136dd40417c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "902f93d9-0264-497f-820b-19c15d9cfcaa", "AQAAAAEAACcQAAAAEC1b1i96C0TuES3j13v34ewzjxyNU7CsPCkP/JtPIcgrGZq6oqn9xSJ5kooQl7rfFQ==", "cdaf8ac9-8285-4821-b090-c5f7c4bffde9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed52f21e-7050-413e-90d7-4cde134f32ae", "AQAAAAEAACcQAAAAENATUtnXfXoSmNCUmwfkZv5XDzTJpU5FDRBxlP48UEvKFeIqd+Tf4NLDAY4U4zj7JQ==", "7f6578a1-94e8-4db0-bae6-4707a0b1ca91" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6de94538-226c-4096-a631-be7e62e35932", "AQAAAAEAACcQAAAAEJItY7TpdYyVjrp3G/7d05y6dnYASloOvgL26B2JU2C5cUOPjZdso9ZPeKk6JXDfcQ==", "331134bb-8a92-4e38-885e-04164f669839" });
        }
    }
}

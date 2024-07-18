using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infra.DB.SqlServer.EF.Migrations
{
    public partial class unAcceptedStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "f810fdc1-d837-4acc-9cf4-14b5676f69ec");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "d9d88d6b-1157-410d-bb73-b08d9bc81762");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "f251cc15-2ffd-4a88-8c91-7101cd31a2aa");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b32f3c26-41af-44d0-83c3-cec44fd1c69e", "AQAAAAEAACcQAAAAEDPcvx6qt+qib/A0V3WQILcG8rFhxRIjhw2O5HC4Bq6DlaQuCo1hruGMXT2vRIHKUg==", "d63abe00-ad9f-45c2-b8fd-502a9d7284e8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "542971b1-bdf0-4a08-8508-a9e5faadec01", "AQAAAAEAACcQAAAAEOLk/3zjNOJUUUV+wEn193Go3xNZ9/QOx9OTXnFGJoCuB1zLAN7QdrNMgvKJdTBEyQ==", "832bb7a4-a796-4f1b-96ed-f577d985275a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba2a4865-bfe7-4fed-ad16-0433e25e2990", "AQAAAAEAACcQAAAAEGrJS9W/xLOa7hJjVKmMKUehdF3iqdveroEgGdEhHxd4SpUS5xb+O2alGfMrF6I7ew==", "b5813e6c-f862-4aa9-aa1d-efeafe57dc27" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f87bc4f-40a4-4d88-b3b0-556b80dd09a6", "AQAAAAEAACcQAAAAEDuYi0QJprm3wkmdR7X9unA1iF9pyoWqQG3muVxFIxwRergqtafVPCvdUmoUAU1rZg==", "8f2fc1f7-88e6-42f8-aca0-11402dc35884" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8928b902-a74a-46b5-96d3-65363f1d01d4", "AQAAAAEAACcQAAAAEBjP4wL/aqfv0jqHfrK/DzvAo+uKOnxv8yziWaDR6C9iPXUBZykVQZCUXmZ21sb6gw==", "bb760ac9-02fc-4156-bcf7-d85402c2c864" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "8012da68-0161-4b4e-89cf-bae907f7e563");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "300eee12-6831-4b82-b111-f73f0c6a8c61");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "936dcc54-07b7-4886-9c82-9d473d7c621f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df95a7da-b02d-4e97-9c5a-3700bbd5b693", "AQAAAAEAACcQAAAAENqsbds52kkZnWIbXXEhaHF9BoMIn0dhttV/vmKaa5mmFPLs/5u7XrnBzPlepiuCjg==", "5d06bc3f-c445-4de2-8e5d-0225405a3f03" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb26108d-9ad7-4293-816e-77198f034d09", "AQAAAAEAACcQAAAAEFRGQNB0ys0NCbhW2am6NH8xL2nox60LNzNp1uug6Kp3hs5+qIk5t4ikFKVB/IWVEw==", "17a6347b-681f-48e3-9fd6-a7f63c7a66d5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e16f082-ba75-415b-8cd9-e113e731d49c", "AQAAAAEAACcQAAAAEAS66VpOZQ74mj4L/V3XG3KzTLTgSVHibGb6VjT+QE9xlbswTAJgMq539OgC7WlaGw==", "403b00d0-28b5-4e32-ae83-a1c486ff5a2a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c04fd01-1de6-43a3-a5d3-92db90d15e20", "AQAAAAEAACcQAAAAEDHuHgHsjOXhMU9074/PJiZiGJsEKwiQwGX3m9rW82A6YEafcLA81TFapO2Gznt5qg==", "5b708be8-4736-4cc6-b8f4-4631edfdc4dd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f33d3ef-8187-474f-b611-84e39dfa0cde", "AQAAAAEAACcQAAAAEHmWEEnBSwmS0EewqkBXkoRkpV1ehFArLKxnvdxJIO2gQNxHZgwrVkMGi4lQ3jIlog==", "b52d0012-3a44-4c5a-a929-7e29e44587fd" });
        }
    }
}

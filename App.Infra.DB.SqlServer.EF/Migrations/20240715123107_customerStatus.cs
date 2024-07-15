using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infra.DB.SqlServer.EF.Migrations
{
    public partial class customerStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "132ccf5e-6064-4ecf-aad9-7340bd696c08");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "fc7752d1-3337-47d8-a249-6c019413bb32");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "c1625ff8-cae8-4825-ab15-4fb045878c11");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "56dddb1d-09cc-4073-be1c-2df516b4b76c", "AQAAAAEAACcQAAAAELnqzTRp6uXoxQQY+kIX3R4bwQ7r1u5gQecBh0xw3T0L6Pf0ZDYtgMQx7IfDz8qcmw==", "1f2de366-dc63-4bff-8a71-0731b461e8b2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3af725dd-0a34-4f27-b833-dc553fed28b9", "AQAAAAEAACcQAAAAEE2ecj29IA5WoRgtTZLrPPdNJh5sqCMosTN6NHED6h56ew7ug5ZWFHVTqe9nTd8PeQ==", "74999a25-d348-48e9-a35b-f54b20139aaa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a15d81d4-8389-48e4-8533-7de527b05bc0", "AQAAAAEAACcQAAAAEF2lpehCoDvYFX961mvrNL+9LvK/ydYSRZ4nouOee1+6OheqHbu4AEc6sHav0gnhkQ==", "952dc0b9-959c-427f-af24-8fb228172d74" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b1f145b-2d33-452b-96df-2a1fdb05d6a7", "AQAAAAEAACcQAAAAEKW47+qA20Ww0xDkuJ3oVYipCtbuFJ1Jn9kbibo9+ASIcLggCA8ZgzXE4PB/SpMa7w==", "2bc33a6c-656a-4c2c-a176-b2b76724b36a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c77462d7-e08e-4240-8aba-d69e20271248", "AQAAAAEAACcQAAAAEE89tzNV7IVlWqIlFI8w9eOjGnC0NGaRgqtPlQfk0P/YpHJxEEB11uSnqlzi/G/hDA==", "23ace7ee-bee3-4aae-ac01-ca1377d61692" });
        }
    }
}

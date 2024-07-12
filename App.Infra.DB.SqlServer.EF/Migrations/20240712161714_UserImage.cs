using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infra.DB.SqlServer.EF.Migrations
{
    public partial class UserImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "User",
                type: "varbinary(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "User");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "d1870927-6cbc-4a30-a9b7-4d6ef89f4f5d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "0b502aec-83a7-42cb-af0d-adc1ff888e6b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "5061bd10-7a05-49c6-ad8f-9582b00fd487");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce4dec20-694d-4902-bc6e-52e724b62939", "AQAAAAEAACcQAAAAEDVCT6EdbcByysPXHD9QR/6jQfXtKl+z1UqaOmvfG1NlnAEeLbwkFv8z4XT8s1KO6w==", "15de5ded-3a26-492e-b637-7466f52e4ae1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7aaa09dc-705c-4728-af11-38ec6c2891fe", "AQAAAAEAACcQAAAAEFw16BrfDJGcwgs85Ka5hYQ0Gu43LqqLMVvc55NLDhAanq8JVES4vMMpX7eoGBRerg==", "1b6e6954-189c-447f-9d66-25e73b87a57d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff1234ea-e87b-4953-8e5e-1e13d883127d", "AQAAAAEAACcQAAAAEFs4BTxbfAd5dU7vdk9waBztuHq1I/VfZfC08Vdym3HYDTP2VL76Fd2LgSDZ6LgQ0g==", "a526d9c0-f87a-4c77-9dec-065d584ab2b7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4b544420-5c0f-4375-911d-812f25cfb96b", "AQAAAAEAACcQAAAAEPK9LU2cgMFYN27e4Rqn5GU0Y6CYNjRracnbJyAldWIW29YdgvU2wXROw4Eof5d5vQ==", "cb219049-7838-42e5-a852-333c9b1099d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83dd74a2-74bf-4a0f-93c7-f4c98a6f1e23", "AQAAAAEAACcQAAAAEM5mymHfte9e3ewWxz+vBulx8jldl335xQEqr1l2iPMjfAxtDlIZD6cB5AqG0INnFA==", "63ae19d4-f195-4b1b-bf61-945eb1bc8244" });
        }
    }
}

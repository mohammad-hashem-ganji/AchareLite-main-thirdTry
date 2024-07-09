using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infra.DB.SqlServer.EF.Migrations
{
    public partial class BidDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Bids",
                type: "nvarchar(max)",
                nullable: true);

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
                columns: new[] { "ConcurrencyStamp", "Name" },
                values: new object[] { "5061bd10-7a05-49c6-ad8f-9582b00fd487", "Expert" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Bids");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "21ac65a3-af9b-46f3-a6f4-885046997eeb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "0bae8393-7e99-4a17-ac80-6b45b5d9445a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "Name" },
                values: new object[] { "28525c14-133e-4e88-b5e3-8eb42118389a", "expert" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ab1f1cb-6e01-40cf-b550-d242b8d10d5f", "AQAAAAEAACcQAAAAEC3QdpU/NhfRkHNYttYKt52USfx9CJ9r2LV19MMObGBkCOUOFv6xpGo6MVf1tY7c9w==", "b1b60ba7-4cda-4050-ae03-5939e770e46a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2a40870-3c6c-4dc1-a7ce-e3b86a8feb68", "AQAAAAEAACcQAAAAEJvpFalFKOeavB7RMkIIyZW7SVVO998l9alZbnsM8MIUcSkLce7pscopBmhnS6BM6A==", "61f80f7e-574e-4592-ba07-adb2c8e1c4b0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0deb8ed-bf60-41df-a31c-9c135ffe2daa", "AQAAAAEAACcQAAAAEJ4mNtyd5mYnq2gO1ospd9qsBncuRRgzn8q6eZZyWcirkOmOAS+aend5+sfNVTKhHA==", "8227e9e7-f0c4-4d9f-ad78-dcbbd7d4dfb6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a1f6e26-49e7-42d3-98a1-00290ee6a165", "AQAAAAEAACcQAAAAEDPsdA7bOnGsBQO8M+QqHVXeFoP0LiT8dgArqQYg+3+OqQM40A+O066x/k2BQXh4Dg==", "5d131f52-9744-472d-88e2-287e20618d7e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac0f82d9-7554-4ae0-9c15-b03c6909f3c6", "AQAAAAEAACcQAAAAEOiv46Zrk6MFM3vgTvXgKjnX+QYIN+RNM+rkE2FJwQcDixbmeHZIw+33JwGpkSLVfQ==", "af725ecf-7a1a-4be5-ba10-89c1f316e96e" });
        }
    }
}

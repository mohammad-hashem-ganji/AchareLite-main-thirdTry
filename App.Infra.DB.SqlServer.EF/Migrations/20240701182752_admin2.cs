using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infra.DB.SqlServer.EF.Migrations
{
    public partial class admin2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                column: "ConcurrencyStamp",
                value: "28525c14-133e-4e88-b5e3-8eb42118389a");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "bf971178-32df-496d-810c-1bce4b2af391");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "b8eb3cda-9809-464a-a138-63c2bfc0f569");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "76e099ff-59cb-4a11-a9f9-c3508debd714");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f7b463dd-db00-4d2c-acde-ad213035e5c1", "AQAAAAEAACcQAAAAEMbamtk+twBejB2JRmPJCvD+gGsjFVFOGpSfAseVATUkaPuesnF8soH+cbQum6CLTw==", "956bfae7-400d-4322-bb13-5f723bcd276c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b83876db-d7e9-41a5-a2e8-7f27dc515641", "AQAAAAEAACcQAAAAEDgv2n264PsybDfzndRsuu4aL4L9jWEK4gqc8Lv0RDFDE/iUTLUPjivh6GdgfP7MZA==", "8ff8f808-d601-43d1-b808-de15c187a52e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac962b2f-b8d6-4fbd-a59c-a40ad9deae61", "AQAAAAEAACcQAAAAEB8+AOCIpmNXmgxvKe15jDBQ/JytVwEFxlvjSXZQr5RecMg1+dQuauQ/N4wwS9CXIA==", "69aea6cb-0113-466d-bf70-13774497493b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "762b8cdc-4a25-4348-83c7-88b8d08adf10", "AQAAAAEAACcQAAAAEAxLZV40bSH2Ep8iKdl1w3ksz/Q293Pu5s3jjBqlYfoD4dz9h2nNAfdYZWgyiNAc/g==", "f476d6c2-6fd6-4c40-9670-ea5080f01cce" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0055d262-da09-4b5a-8fd8-9a6f9fa49c22", "AQAAAAEAACcQAAAAEOtntfFOILzehlvMRYlOeJiZCK8AasShSUjRKail98POwscsO7UPsNkIUf+4MkqE4A==", "3f2e3529-0d1f-4e78-b156-63de982e907b" });
        }
    }
}

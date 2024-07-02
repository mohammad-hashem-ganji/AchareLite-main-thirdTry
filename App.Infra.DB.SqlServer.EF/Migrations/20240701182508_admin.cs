using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infra.DB.SqlServer.EF.Migrations
{
    public partial class admin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "8131124c-e38b-4b88-bf1e-12b6686b9c28");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "fa2e9c06-abd3-4212-9469-ec709de2b09e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "376c4d01-9672-4fa0-99b3-136ed2c64b2c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "47752025-927b-45c5-9532-671bc1c92a1d", "AQAAAAEAACcQAAAAEIR+kvQNvGPnmSD60RLEFXaJnVosJzHAAurHT9/TdNpT0Th/0IBDJX7Z6/EkXVSjXw==", "e995f0dd-7b8c-46b9-8a0c-831bc56fa96f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5144776-2041-4f66-be34-5d68930071cc", "AQAAAAEAACcQAAAAEGTOiOdmMJmjQ9LBV8/+eHCI0MO0csSnyN7nrLzgJWm2XZ+XUv2VOFm8GgxxQ4EK9Q==", "d8f6988e-4d1e-4e27-b96b-8176afa0cb9f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3890ec4b-a3fb-440b-9549-ded675ff4816", "AQAAAAEAACcQAAAAEOh4+zFefl5DE4TIU9hoEihPFejZltH1+pW7JkrzxhsVkHwm7s8wCuy/cIz1msSDjg==", "e275d39c-b98d-4946-bc67-59383a0ad4db" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84b47e40-bf30-4c1a-b408-8f3044817a00", "AQAAAAEAACcQAAAAEDaxtD4CzQWFBm2xfAhRKerMsoDDNE1XVQyte+kjqWxyAl1WBMmcyvsbuGTk5527oQ==", "7d0246ba-f2f8-4376-8194-10f860034058" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e87b6fe2-c134-4cdd-a27b-e702b63f543b", "AQAAAAEAACcQAAAAEDLE1QPyACyYCqusNjqBDT8uuCh8hU6iykP0JgT9dibCBphqh5fk+ieVxKaRQD2hZA==", "75cb3165-ef08-47dd-8597-24080267e910" });
        }
    }
}

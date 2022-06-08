using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eRestoran.WebAPI.Migrations
{
    public partial class added_columns_datumTransakcije_brojTransakcije_table_Uplata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BrojTransakcije",
                table: "Uplata",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumTransakcije",
                table: "Uplata",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Drzava",
                columns: new[] { "Id", "Naziv" },
                values: new object[] { 2, "Test" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "rDEPtSFBJDTdiU9UDDlQP91clpYcq5LUIeUWoU7S134=", "phzA+nctd0u9yWY7w4h9xw==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "peVsycdT/s0A+yZBMdrgGNpeHAO2JqkfhkcnH8jnvpI=", "pFtLSSxOAfiUGrJzEjS7qA==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "BlouC47PYmgibrpTRzqHP0iYtBA5CZcC2LPM4/6Zvd4=", "nzHvrGo1/oFpyTCdLOQSwA==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "4By3U21zPO2Ml+VAXRNcYvkMrI1hN6W4AOpLBSMCzl8=", "1dHqc3t/DvzLGBz3PySslg==" });

            migrationBuilder.UpdateData(
                table: "Narudzba",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatumNarudzbe",
                value: new DateTime(2022, 6, 8, 16, 48, 56, 715, DateTimeKind.Local).AddTicks(864));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Drzava",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "BrojTransakcije",
                table: "Uplata");

            migrationBuilder.DropColumn(
                name: "DatumTransakcije",
                table: "Uplata");

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "sOrM9/gW6Ii5cPXfMwb/UfaW8+Vnz8f5JPSF4wFcBtQ=", "BypDNOOgqk4jTqg/gZRpyA==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "NAIoac1b6wNbFQlZC8aSKLNoilCQ6LVWH8nAL8H2Fuk=", "NE58KO+F4ExrsdTnt84b9A==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "LSO8NCEHi8tj3Iz2EELFv//8uKHsmIiA8VAHcdx+Q34=", "T5kZZgkPZz9O2a1K0u6dLg==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "cfe++DX9NzrRsBBIZ/Orp82Jr/f6kocNpI4/5+jGIjc=", "vBZJjxgmDQ9Zp9KYI8Bv7g==" });

            migrationBuilder.UpdateData(
                table: "Narudzba",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatumNarudzbe",
                value: new DateTime(2022, 6, 4, 21, 58, 39, 227, DateTimeKind.Local).AddTicks(6984));
        }
    }
}

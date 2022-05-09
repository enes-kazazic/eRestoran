using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eRestoran.WebAPI.Migrations
{
    public partial class nova : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Kategorija",
                columns: new[] { "Id", "Naziv", "Opis" },
                values: new object[,]
                {
                    { 1, "Predjelo", "Opis k1" },
                    { 2, "Glavno Jelo", "Opis k2" },
                    { 3, "Desert", "Opis k3" }
                });

            migrationBuilder.InsertData(
                table: "Korisnik",
                columns: new[] { "Id", "Ime", "KorisnickoIme", "LozinkaHash", "LozinkaSalt", "Prezime" },
                values: new object[,]
                {
                    { 1, "Admin", "admin", "XjftMOLw7GzP8trxfjP0izVlr6DCclm29/rtPZH+fIk=", "jP0xJI36/FI8/gGJ+75o+g==", "admin" },
                    { 2, "test", "test", "punH46fsnKi3oy+dVcgKlBJIzP//IQUnyAse9NnPOEs=", "LL1K9BxhEV54lfT1EtjjOg==", "test" }
                });

            migrationBuilder.InsertData(
                table: "StatusNarudzbe",
                columns: new[] { "Id", "Naziv" },
                values: new object[,]
                {
                    { 1, "Primljena" },
                    { 2, "U pripremi" },
                    { 3, "Isporucena" }
                });

            migrationBuilder.InsertData(
                table: "Jelo",
                columns: new[] { "Id", "Cijena", "KategorijaId", "Naziv", "Opis", "Slika" },
                values: new object[,]
                {
                    { 1, 5m, 1, "Hamburger", "Opis za hamburger", null },
                    { 2, 6m, 1, "Cevapi", "Opis za Cevapi", null },
                    { 3, 4m, 2, "Test", "Opis test", null }
                });

            migrationBuilder.InsertData(
                table: "Narudzba",
                columns: new[] { "Id", "DatumNarudzbe", "KorisnikId", "StatusNarudzbeId" },
                values: new object[] { 1, new DateTime(2022, 5, 9, 11, 59, 11, 898, DateTimeKind.Local).AddTicks(6825), 1, 1 });

            migrationBuilder.InsertData(
                table: "Recenzija",
                columns: new[] { "Id", "JeloId", "KorisnikId", "Ocjena", "Opis" },
                values: new object[,]
                {
                    { 1, 1, 1, 3, "abc123" },
                    { 3, 1, 2, 4, "def123" },
                    { 2, 2, 1, 3, "cba123" },
                    { 4, 2, 2, 4, "fed123" }
                });

            migrationBuilder.InsertData(
                table: "StavkeNarudzbe",
                columns: new[] { "Id", "Cijena", "JeloId", "Kolicina", "NarudzbaId" },
                values: new object[] { 1, 5, 1, 2, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Jelo",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Kategorija",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Recenzija",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recenzija",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Recenzija",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Recenzija",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StatusNarudzbe",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StatusNarudzbe",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StavkeNarudzbe",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Jelo",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Jelo",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Kategorija",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Korisnik",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Narudzba",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Kategorija",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Korisnik",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StatusNarudzbe",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}

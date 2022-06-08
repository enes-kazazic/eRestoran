using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eRestoran.WebAPI.Migrations
{
    public partial class added_tables_Grad_Drzava_Uplata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DrzavaId",
                table: "Korisnik",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GradId",
                table: "Korisnik",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uplata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Iznos = table.Column<double>(type: "float", nullable: false),
                    KorisnikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uplata", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uplata_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Drzava",
                columns: new[] { "Id", "Naziv" },
                values: new object[] { 1, "Bosna i Hercegovina" });

            migrationBuilder.InsertData(
                table: "Grad",
                columns: new[] { "Id", "Naziv" },
                values: new object[,]
                {
                    { 1, "Mostar" },
                    { 2, "Sarajevo" },
                    { 3, "Tuzla" }
                });

            migrationBuilder.UpdateData(
                table: "Narudzba",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatumNarudzbe",
                value: new DateTime(2022, 6, 4, 21, 58, 39, 227, DateTimeKind.Local).AddTicks(6984));

            migrationBuilder.InsertData(
                table: "Uplata",
                columns: new[] { "Id", "Iznos", "KorisnikId" },
                values: new object[,]
                {
                    { 1, 10.0, 1 },
                    { 2, 10.0, 1 },
                    { 3, 20.0, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DrzavaId", "GradId", "LozinkaHash", "LozinkaSalt" },
                values: new object[] { 1, 2, "sOrM9/gW6Ii5cPXfMwb/UfaW8+Vnz8f5JPSF4wFcBtQ=", "BypDNOOgqk4jTqg/gZRpyA==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DrzavaId", "GradId", "LozinkaHash", "LozinkaSalt" },
                values: new object[] { 1, 2, "NAIoac1b6wNbFQlZC8aSKLNoilCQ6LVWH8nAL8H2Fuk=", "NE58KO+F4ExrsdTnt84b9A==" });

            migrationBuilder.InsertData(
                table: "Korisnik",
                columns: new[] { "Id", "DrzavaId", "GradId", "Ime", "KorisnickoIme", "LozinkaHash", "LozinkaSalt", "Prezime" },
                values: new object[,]
                {
                    { 3, 1, 2, "John", "johnDoe", "LSO8NCEHi8tj3Iz2EELFv//8uKHsmIiA8VAHcdx+Q34=", "T5kZZgkPZz9O2a1K0u6dLg==", "Doe" },
                    { 4, 1, 2, "Some", "myUsername", "cfe++DX9NzrRsBBIZ/Orp82Jr/f6kocNpI4/5+jGIjc=", "vBZJjxgmDQ9Zp9KYI8Bv7g==", "User" }
                });

            migrationBuilder.InsertData(
                table: "Uplata",
                columns: new[] { "Id", "Iznos", "KorisnikId" },
                values: new object[] { 4, 5.0, 3 });

            migrationBuilder.InsertData(
                table: "Uplata",
                columns: new[] { "Id", "Iznos", "KorisnikId" },
                values: new object[] { 5, 7.0, 4 });

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_DrzavaId",
                table: "Korisnik",
                column: "DrzavaId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_GradId",
                table: "Korisnik",
                column: "GradId");

            migrationBuilder.CreateIndex(
                name: "IX_Uplata_KorisnikId",
                table: "Uplata",
                column: "KorisnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnik_Drzava_DrzavaId",
                table: "Korisnik",
                column: "DrzavaId",
                principalTable: "Drzava",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnik_Grad_GradId",
                table: "Korisnik",
                column: "GradId",
                principalTable: "Grad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Korisnik_Drzava_DrzavaId",
                table: "Korisnik");

            migrationBuilder.DropForeignKey(
                name: "FK_Korisnik_Grad_GradId",
                table: "Korisnik");

            migrationBuilder.DropTable(
                name: "Drzava");

            migrationBuilder.DropTable(
                name: "Grad");

            migrationBuilder.DropTable(
                name: "Uplata");

            migrationBuilder.DropIndex(
                name: "IX_Korisnik_DrzavaId",
                table: "Korisnik");

            migrationBuilder.DropIndex(
                name: "IX_Korisnik_GradId",
                table: "Korisnik");

            migrationBuilder.DeleteData(
                table: "Korisnik",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Korisnik",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "DrzavaId",
                table: "Korisnik");

            migrationBuilder.DropColumn(
                name: "GradId",
                table: "Korisnik");

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "XjftMOLw7GzP8trxfjP0izVlr6DCclm29/rtPZH+fIk=", "jP0xJI36/FI8/gGJ+75o+g==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "punH46fsnKi3oy+dVcgKlBJIzP//IQUnyAse9NnPOEs=", "LL1K9BxhEV54lfT1EtjjOg==" });

            migrationBuilder.UpdateData(
                table: "Narudzba",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatumNarudzbe",
                value: new DateTime(2022, 5, 9, 11, 59, 11, 898, DateTimeKind.Local).AddTicks(6825));
        }
    }
}

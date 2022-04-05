using Microsoft.EntityFrameworkCore.Migrations;

namespace eRestoran.WebAPI.Migrations
{
    public partial class table_recenzija_column_jelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JeloId",
                table: "Recenzija",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Recenzija_JeloId",
                table: "Recenzija",
                column: "JeloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recenzija_Jelo_JeloId",
                table: "Recenzija",
                column: "JeloId",
                principalTable: "Jelo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recenzija_Jelo_JeloId",
                table: "Recenzija");

            migrationBuilder.DropIndex(
                name: "IX_Recenzija_JeloId",
                table: "Recenzija");

            migrationBuilder.DropColumn(
                name: "JeloId",
                table: "Recenzija");
        }
    }
}

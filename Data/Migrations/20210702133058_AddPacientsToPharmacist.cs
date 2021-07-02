using Microsoft.EntityFrameworkCore.Migrations;

namespace ProiectFinal.Data.Migrations
{
    public partial class AddPacientsToPharmacist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PharmacistId",
                table: "Pacients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pacients_PharmacistId",
                table: "Pacients",
                column: "PharmacistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacients_Pharmacists_PharmacistId",
                table: "Pacients",
                column: "PharmacistId",
                principalTable: "Pharmacists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacients_Pharmacists_PharmacistId",
                table: "Pacients");

            migrationBuilder.DropIndex(
                name: "IX_Pacients_PharmacistId",
                table: "Pacients");

            migrationBuilder.DropColumn(
                name: "PharmacistId",
                table: "Pacients");
        }
    }
}

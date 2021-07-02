using Microsoft.EntityFrameworkCore.Migrations;

namespace ProiectFinal.Data.Migrations
{
    public partial class AddProductToPacient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PacientProduct",
                columns: table => new
                {
                    PacientsId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacientProduct", x => new { x.PacientsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_PacientProduct_Pacients_PacientsId",
                        column: x => x.PacientsId,
                        principalTable: "Pacients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PacientProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PacientProduct_ProductsId",
                table: "PacientProduct",
                column: "ProductsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PacientProduct");
        }
    }
}

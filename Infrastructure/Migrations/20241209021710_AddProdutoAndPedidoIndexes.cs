using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDePedidos.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProdutoAndPedidoIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Categoria",
                table: "Produto",
                column: "Categoria");

            migrationBuilder.CreateIndex(
                name: "IX_Status",
                table: "Acompanhamento",
                column: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Categoria",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Status",
                table: "Acompanhamento");
        }
    }
}

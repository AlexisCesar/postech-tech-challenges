using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDePedidos.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCpfAndEmailAsValueObjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Cliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Preco",
                table: "Produto",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Cliente",
                type: "text",
                nullable: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleProdutos.Migrations
{
    /// <inheritdoc />
    public partial class atualizacaoClasseProdutoCorrecaoColunaUNIDADE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unidade",
                schema: "conprod",
                table: "tbproduto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Unidade",
                schema: "conprod",
                table: "tbproduto",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}

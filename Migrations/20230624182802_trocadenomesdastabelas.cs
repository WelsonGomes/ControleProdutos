using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleProdutos.Migrations
{
    /// <inheritdoc />
    public partial class trocadenomesdastabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Unidade",
                schema: "ControleProdutos",
                table: "Unidade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produto",
                schema: "ControleProdutos",
                table: "Produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LogErros",
                schema: "ControleProdutos",
                table: "LogErros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliente",
                schema: "ControleProdutos",
                table: "Cliente");

            migrationBuilder.EnsureSchema(
                name: "conprod");

            migrationBuilder.RenameTable(
                name: "Unidade",
                schema: "ControleProdutos",
                newName: "tbunidade",
                newSchema: "conprod");

            migrationBuilder.RenameTable(
                name: "Produto",
                schema: "ControleProdutos",
                newName: "tbproduto",
                newSchema: "conprod");

            migrationBuilder.RenameTable(
                name: "LogErros",
                schema: "ControleProdutos",
                newName: "tblogerros",
                newSchema: "conprod");

            migrationBuilder.RenameTable(
                name: "Cliente",
                schema: "ControleProdutos",
                newName: "tbcliente",
                newSchema: "conprod");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbunidade",
                schema: "conprod",
                table: "tbunidade",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbproduto",
                schema: "conprod",
                table: "tbproduto",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblogerros",
                schema: "conprod",
                table: "tblogerros",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbcliente",
                schema: "conprod",
                table: "tbcliente",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbunidade",
                schema: "conprod",
                table: "tbunidade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbproduto",
                schema: "conprod",
                table: "tbproduto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblogerros",
                schema: "conprod",
                table: "tblogerros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbcliente",
                schema: "conprod",
                table: "tbcliente");

            migrationBuilder.EnsureSchema(
                name: "ControleProdutos");

            migrationBuilder.RenameTable(
                name: "tbunidade",
                schema: "conprod",
                newName: "Unidade",
                newSchema: "ControleProdutos");

            migrationBuilder.RenameTable(
                name: "tbproduto",
                schema: "conprod",
                newName: "Produto",
                newSchema: "ControleProdutos");

            migrationBuilder.RenameTable(
                name: "tblogerros",
                schema: "conprod",
                newName: "LogErros",
                newSchema: "ControleProdutos");

            migrationBuilder.RenameTable(
                name: "tbcliente",
                schema: "conprod",
                newName: "Cliente",
                newSchema: "ControleProdutos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Unidade",
                schema: "ControleProdutos",
                table: "Unidade",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produto",
                schema: "ControleProdutos",
                table: "Produto",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LogErros",
                schema: "ControleProdutos",
                table: "LogErros",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente",
                schema: "ControleProdutos",
                table: "Cliente",
                column: "Id");
        }
    }
}

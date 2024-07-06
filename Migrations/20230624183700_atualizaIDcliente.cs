﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleProdutos.Migrations
{
    /// <inheritdoc />
    public partial class atualizaIDcliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "conprod",
                table: "tbcliente",
                newName: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                schema: "conprod",
                table: "tbcliente",
                newName: "Id");
        }
    }
}
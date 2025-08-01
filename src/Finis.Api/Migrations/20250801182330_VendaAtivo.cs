using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finis.Api.Migrations
{
    /// <inheritdoc />
    public partial class VendaAtivo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VendaAtivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompraId = table.Column<int>(type: "int", nullable: false),
                    AtivoId = table.Column<int>(type: "int", nullable: false),
                    QtdCotas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DtVenda = table.Column<DateOnly>(type: "date", nullable: false),
                    ValorVenda = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalTaxas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorLucro = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorLucroReais = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorRecebido = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FlBolsa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendaAtivos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VendaAtivos");
        }
    }
}

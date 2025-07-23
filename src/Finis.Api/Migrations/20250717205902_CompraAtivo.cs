using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finis.Api.Migrations
{
    /// <inheritdoc />
    public partial class CompraAtivo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompraAtivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AtivoId = table.Column<int>(type: "int", nullable: false),
                    NomeAtivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtCompra = table.Column<DateOnly>(type: "date", nullable: false),
                    ValorCompra = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EstimativaVenda = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorCota = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QtdCotas = table.Column<int>(type: "int", nullable: false),
                    FlVendido = table.Column<bool>(type: "bit", nullable: false),
                    FlBolsa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Corretora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estrategia = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraAtivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompraAtivos_Ativos_AtivoId",
                        column: x => x.AtivoId,
                        principalTable: "Ativos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompraAtivos_AtivoId",
                table: "CompraAtivos",
                column: "AtivoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompraAtivos");
        }
    }
}

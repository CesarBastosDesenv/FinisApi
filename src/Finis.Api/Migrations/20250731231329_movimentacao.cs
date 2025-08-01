using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finis.Api.Migrations
{
    /// <inheritdoc />
    public partial class movimentacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movimentacaoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoGasto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtMovimentacao = table.Column<DateOnly>(type: "date", nullable: false),
                    FlMovimentacao = table.Column<int>(type: "int", nullable: false),
                    ContaId = table.Column<int>(type: "int", nullable: false),
                    DescricaoMovimentacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorMovimentacao = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentacaoes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimentacaoes");
        }
    }
}

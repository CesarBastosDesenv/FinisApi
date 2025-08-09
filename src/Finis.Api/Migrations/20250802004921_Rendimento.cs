using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finis.Api.Migrations
{
    /// <inheritdoc />
    public partial class Rendimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rendimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AtivoId = table.Column<int>(type: "int", nullable: false),
                    TipoId = table.Column<int>(type: "int", nullable: false),
                    AnoRendimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MesRendimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QtdCotas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorRendimento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorRendimentoReais = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FlBolsa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Corretora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtRendimento = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rendimentos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rendimentos");
        }
    }
}

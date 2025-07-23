using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finis.Api.Migrations
{
    /// <inheritdoc />
    public partial class TabelaAtivos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ativos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeAtivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeAtivoCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeguimentoAtivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QtdCotas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlVendido = table.Column<bool>(type: "bit", nullable: false),
                    DtCadastro = table.Column<DateOnly>(type: "date", nullable: false),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoAtivoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ativos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ativos_TipoAtivos_TipoAtivoId",
                        column: x => x.TipoAtivoId,
                        principalTable: "TipoAtivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ativos_TipoAtivoId",
                table: "Ativos",
                column: "TipoAtivoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ativos");
        }
    }
}

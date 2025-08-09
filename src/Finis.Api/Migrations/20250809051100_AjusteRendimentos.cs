using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finis.Api.Migrations
{
    /// <inheritdoc />
    public partial class AjusteRendimentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoId",
                table: "Rendimentos");

            migrationBuilder.CreateIndex(
                name: "IX_Rendimentos_AtivoId",
                table: "Rendimentos",
                column: "AtivoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rendimentos_Ativos_AtivoId",
                table: "Rendimentos",
                column: "AtivoId",
                principalTable: "Ativos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rendimentos_Ativos_AtivoId",
                table: "Rendimentos");

            migrationBuilder.DropIndex(
                name: "IX_Rendimentos_AtivoId",
                table: "Rendimentos");

            migrationBuilder.AddColumn<int>(
                name: "TipoId",
                table: "Rendimentos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

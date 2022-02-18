using Microsoft.EntityFrameworkCore.Migrations;

namespace Marfriing.Data.Migrations
{
    public partial class _008 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnimalId",
                table: "CompraGadoItem",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompraGadoId",
                table: "CompraGadoItem",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PecuaristaId",
                table: "CompraGado",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompraGadoItem_AnimalId",
                table: "CompraGadoItem",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_CompraGadoItem_CompraGadoId",
                table: "CompraGadoItem",
                column: "CompraGadoId");

            migrationBuilder.CreateIndex(
                name: "IX_CompraGado_PecuaristaId",
                table: "CompraGado",
                column: "PecuaristaId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompraGado_Pecuarista_PecuaristaId",
                table: "CompraGado",
                column: "PecuaristaId",
                principalTable: "Pecuarista",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompraGadoItem_Animal_AnimalId",
                table: "CompraGadoItem",
                column: "AnimalId",
                principalTable: "Animal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompraGadoItem_CompraGado_CompraGadoId",
                table: "CompraGadoItem",
                column: "CompraGadoId",
                principalTable: "CompraGado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompraGado_Pecuarista_PecuaristaId",
                table: "CompraGado");

            migrationBuilder.DropForeignKey(
                name: "FK_CompraGadoItem_Animal_AnimalId",
                table: "CompraGadoItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CompraGadoItem_CompraGado_CompraGadoId",
                table: "CompraGadoItem");

            migrationBuilder.DropIndex(
                name: "IX_CompraGadoItem_AnimalId",
                table: "CompraGadoItem");

            migrationBuilder.DropIndex(
                name: "IX_CompraGadoItem_CompraGadoId",
                table: "CompraGadoItem");

            migrationBuilder.DropIndex(
                name: "IX_CompraGado_PecuaristaId",
                table: "CompraGado");

            migrationBuilder.DropColumn(
                name: "AnimalId",
                table: "CompraGadoItem");

            migrationBuilder.DropColumn(
                name: "CompraGadoId",
                table: "CompraGadoItem");

            migrationBuilder.DropColumn(
                name: "PecuaristaId",
                table: "CompraGado");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionGanadera.WebApiV2.Migrations
{
    /// <inheritdoc />
    public partial class FKSinCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovimientoLotes_Lotes_LoteId",
                table: "MovimientoLotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Pesajes_Lotes_LoteId",
                table: "Pesajes");

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientoLotes_Lotes_LoteId",
                table: "MovimientoLotes",
                column: "LoteId",
                principalTable: "Lotes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pesajes_Lotes_LoteId",
                table: "Pesajes",
                column: "LoteId",
                principalTable: "Lotes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovimientoLotes_Lotes_LoteId",
                table: "MovimientoLotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Pesajes_Lotes_LoteId",
                table: "Pesajes");

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientoLotes_Lotes_LoteId",
                table: "MovimientoLotes",
                column: "LoteId",
                principalTable: "Lotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pesajes_Lotes_LoteId",
                table: "Pesajes",
                column: "LoteId",
                principalTable: "Lotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

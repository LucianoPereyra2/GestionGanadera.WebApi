using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionGanadera.WebApiV2.Migrations
{
    /// <inheritdoc />
    public partial class EspecieAnimalYClaves : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Especie",
                table: "Lotes",
                newName: "EspecieAnimalId");

            migrationBuilder.CreateTable(
                name: "EspeciesAnimales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspeciesAnimales", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lotes_ClienteId",
                table: "Lotes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Lotes_EspecieAnimalId",
                table: "Lotes",
                column: "EspecieAnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lotes_Clientes_ClienteId",
                table: "Lotes",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Lotes_EspeciesAnimales_EspecieAnimalId",
                table: "Lotes",
                column: "EspecieAnimalId",
                principalTable: "EspeciesAnimales",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lotes_Clientes_ClienteId",
                table: "Lotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Lotes_EspeciesAnimales_EspecieAnimalId",
                table: "Lotes");

            migrationBuilder.DropTable(
                name: "EspeciesAnimales");

            migrationBuilder.DropIndex(
                name: "IX_Lotes_ClienteId",
                table: "Lotes");

            migrationBuilder.DropIndex(
                name: "IX_Lotes_EspecieAnimalId",
                table: "Lotes");

            migrationBuilder.RenameColumn(
                name: "EspecieAnimalId",
                table: "Lotes",
                newName: "Especie");
        }
    }
}

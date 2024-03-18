using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Veterinario.DAL.Migrations
{
    /// <inheritdoc />
    public partial class veterinariomascota : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VeterinarioId",
                table: "Mascota",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mascota_VeterinarioId",
                table: "Mascota",
                column: "VeterinarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mascota_Veterinario_VeterinarioId",
                table: "Mascota",
                column: "VeterinarioId",
                principalTable: "Veterinario",
                principalColumn: "VeterinarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mascota_Veterinario_VeterinarioId",
                table: "Mascota");

            migrationBuilder.DropIndex(
                name: "IX_Mascota_VeterinarioId",
                table: "Mascota");

            migrationBuilder.DropColumn(
                name: "VeterinarioId",
                table: "Mascota");
        }
    }
}

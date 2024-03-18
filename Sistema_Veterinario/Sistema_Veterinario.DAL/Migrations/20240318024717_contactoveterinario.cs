using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Veterinario.DAL.Migrations
{
    /// <inheritdoc />
    public partial class contactoveterinario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VeterinarioId",
                table: "Contacto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacto_VeterinarioId",
                table: "Contacto",
                column: "VeterinarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacto_Veterinario_VeterinarioId",
                table: "Contacto",
                column: "VeterinarioId",
                principalTable: "Veterinario",
                principalColumn: "VeterinarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacto_Veterinario_VeterinarioId",
                table: "Contacto");

            migrationBuilder.DropIndex(
                name: "IX_Contacto_VeterinarioId",
                table: "Contacto");

            migrationBuilder.DropColumn(
                name: "VeterinarioId",
                table: "Contacto");
        }
    }
}

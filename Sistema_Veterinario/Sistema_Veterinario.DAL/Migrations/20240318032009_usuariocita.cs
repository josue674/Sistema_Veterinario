using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Veterinario.DAL.Migrations
{
    /// <inheritdoc />
    public partial class usuariocita : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Padecimiento_Mascota_MascotaId",
                table: "Padecimiento");

            migrationBuilder.DropIndex(
                name: "IX_Padecimiento_MascotaId",
                table: "Padecimiento");

            migrationBuilder.DropColumn(
                name: "MascotaId",
                table: "Padecimiento");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Cita",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cita_UsuarioId",
                table: "Cita",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cita_Usuario_UsuarioId",
                table: "Cita",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cita_Usuario_UsuarioId",
                table: "Cita");

            migrationBuilder.DropIndex(
                name: "IX_Cita_UsuarioId",
                table: "Cita");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Cita");

            migrationBuilder.AddColumn<int>(
                name: "MascotaId",
                table: "Padecimiento",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Padecimiento_MascotaId",
                table: "Padecimiento",
                column: "MascotaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Padecimiento_Mascota_MascotaId",
                table: "Padecimiento",
                column: "MascotaId",
                principalTable: "Mascota",
                principalColumn: "MascotaId");
        }
    }
}

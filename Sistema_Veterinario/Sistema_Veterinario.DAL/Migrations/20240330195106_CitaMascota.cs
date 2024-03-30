using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Veterinario.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CitaMascota : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MascotaIdMascota",
                table: "Cita",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cita_MascotaIdMascota",
                table: "Cita",
                column: "MascotaIdMascota");

            migrationBuilder.AddForeignKey(
                name: "FK_Cita_Mascota_MascotaIdMascota",
                table: "Cita",
                column: "MascotaIdMascota",
                principalTable: "Mascota",
                principalColumn: "IdMascota");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cita_Mascota_MascotaIdMascota",
                table: "Cita");

            migrationBuilder.DropIndex(
                name: "IX_Cita_MascotaIdMascota",
                table: "Cita");

            migrationBuilder.DropColumn(
                name: "MascotaIdMascota",
                table: "Cita");
        }
    }
}

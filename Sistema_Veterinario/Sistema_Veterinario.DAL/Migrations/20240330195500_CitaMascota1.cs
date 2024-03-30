using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Veterinario.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CitaMascota1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "CitaIdCita",
                table: "Mascota",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mascota_CitaIdCita",
                table: "Mascota",
                column: "CitaIdCita");

            migrationBuilder.AddForeignKey(
                name: "FK_Mascota_Cita_CitaIdCita",
                table: "Mascota",
                column: "CitaIdCita",
                principalTable: "Cita",
                principalColumn: "IdCita");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mascota_Cita_CitaIdCita",
                table: "Mascota");

            migrationBuilder.DropIndex(
                name: "IX_Mascota_CitaIdCita",
                table: "Mascota");

            migrationBuilder.DropColumn(
                name: "CitaIdCita",
                table: "Mascota");

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
    }
}

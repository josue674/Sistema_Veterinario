using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Veterinario.DAL.Migrations
{
    /// <inheritdoc />
    public partial class cuarta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_MascotaUsuarioAcciones_MascotaUsuarioAccionID",
                table: "Mascotas");

            migrationBuilder.DropIndex(
                name: "IX_Mascotas_MascotaUsuarioAccionID",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "MascotaUsuarioAccionID",
                table: "Mascotas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MascotaUsuarioAccionID",
                table: "Mascotas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_MascotaUsuarioAccionID",
                table: "Mascotas",
                column: "MascotaUsuarioAccionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_MascotaUsuarioAcciones_MascotaUsuarioAccionID",
                table: "Mascotas",
                column: "MascotaUsuarioAccionID",
                principalTable: "MascotaUsuarioAcciones",
                principalColumn: "MascotaID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

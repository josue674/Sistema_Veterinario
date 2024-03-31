using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Veterinario.DAL.Migrations
{
    /// <inheritdoc />
    public partial class tercera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_MascotaUsuarioAcciones_MascotaUsuarioAccionID",
                table: "Mascotas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MascotaUsuarioAcciones",
                table: "MascotaUsuarioAcciones");

            migrationBuilder.DropIndex(
                name: "IX_MascotaUsuarioAcciones_MascotaID",
                table: "MascotaUsuarioAcciones");

            migrationBuilder.DropColumn(
                name: "MascotaUsuarioAccionID",
                table: "MascotaUsuarioAcciones");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MascotaUsuarioAcciones",
                table: "MascotaUsuarioAcciones",
                column: "MascotaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_MascotaUsuarioAcciones_MascotaUsuarioAccionID",
                table: "Mascotas",
                column: "MascotaUsuarioAccionID",
                principalTable: "MascotaUsuarioAcciones",
                principalColumn: "MascotaID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_MascotaUsuarioAcciones_MascotaUsuarioAccionID",
                table: "Mascotas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MascotaUsuarioAcciones",
                table: "MascotaUsuarioAcciones");

            migrationBuilder.AddColumn<int>(
                name: "MascotaUsuarioAccionID",
                table: "MascotaUsuarioAcciones",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MascotaUsuarioAcciones",
                table: "MascotaUsuarioAcciones",
                column: "MascotaUsuarioAccionID");

            migrationBuilder.CreateIndex(
                name: "IX_MascotaUsuarioAcciones_MascotaID",
                table: "MascotaUsuarioAcciones",
                column: "MascotaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_MascotaUsuarioAcciones_MascotaUsuarioAccionID",
                table: "Mascotas",
                column: "MascotaUsuarioAccionID",
                principalTable: "MascotaUsuarioAcciones",
                principalColumn: "MascotaUsuarioAccionID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Veterinario.DAL.Migrations
{
    /// <inheritdoc />
    public partial class TipoMascota : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoMascota",
                columns: table => new
                {
                    IdTipoMascota = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipoMascota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MascotaIdMascota = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMascota", x => x.IdTipoMascota);
                    table.ForeignKey(
                        name: "FK_TipoMascota_Mascota_MascotaIdMascota",
                        column: x => x.MascotaIdMascota,
                        principalTable: "Mascota",
                        principalColumn: "IdMascota");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TipoMascota_MascotaIdMascota",
                table: "TipoMascota",
                column: "MascotaIdMascota");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoMascota");
        }
    }
}

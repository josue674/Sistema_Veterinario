using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Veterinario.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Raza : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RazaMascota",
                columns: table => new
                {
                    IdRazaMascota = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipoMascota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoMascotaIdTipoMascota = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RazaMascota", x => x.IdRazaMascota);
                    table.ForeignKey(
                        name: "FK_RazaMascota_TipoMascota_TipoMascotaIdTipoMascota",
                        column: x => x.TipoMascotaIdTipoMascota,
                        principalTable: "TipoMascota",
                        principalColumn: "IdTipoMascota");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RazaMascota_TipoMascotaIdTipoMascota",
                table: "RazaMascota",
                column: "TipoMascotaIdTipoMascota");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RazaMascota");
        }
    }
}

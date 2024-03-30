using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Veterinario.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Padecimiento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Padecimiento",
                columns: table => new
                {
                    IdPadecimiento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcionPadecimiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MascotaIdMascota = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Padecimiento", x => x.IdPadecimiento);
                    table.ForeignKey(
                        name: "FK_Padecimiento_Mascota_MascotaIdMascota",
                        column: x => x.MascotaIdMascota,
                        principalTable: "Mascota",
                        principalColumn: "IdMascota");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Padecimiento_MascotaIdMascota",
                table: "Padecimiento",
                column: "MascotaIdMascota");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Padecimiento");
        }
    }
}

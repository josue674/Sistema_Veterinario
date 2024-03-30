using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Veterinario.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Tratamiento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tratamiento",
                columns: table => new
                {
                    IdTratamiento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcionTratamiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CitaIdCita = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tratamiento", x => x.IdTratamiento);
                    table.ForeignKey(
                        name: "FK_Tratamiento_Cita_CitaIdCita",
                        column: x => x.CitaIdCita,
                        principalTable: "Cita",
                        principalColumn: "IdCita");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tratamiento_CitaIdCita",
                table: "Tratamiento",
                column: "CitaIdCita");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tratamiento");
        }
    }
}

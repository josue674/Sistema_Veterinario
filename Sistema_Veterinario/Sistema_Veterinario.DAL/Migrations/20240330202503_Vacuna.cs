using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Veterinario.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Vacuna : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vacuna",
                columns: table => new
                {
                    IdVacuna = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaVacuna = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tipoVacuna = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcionVacuna = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MascotaIdMascota = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacuna", x => x.IdVacuna);
                    table.ForeignKey(
                        name: "FK_Vacuna_Mascota_MascotaIdMascota",
                        column: x => x.MascotaIdMascota,
                        principalTable: "Mascota",
                        principalColumn: "IdMascota");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vacuna_MascotaIdMascota",
                table: "Vacuna",
                column: "MascotaIdMascota");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vacuna");
        }
    }
}

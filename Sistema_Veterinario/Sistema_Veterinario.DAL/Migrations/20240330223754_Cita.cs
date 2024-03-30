using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Veterinario.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Cita : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    CitaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MascotaID = table.Column<int>(type: "int", nullable: false),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VeterinarioPrincipalID = table.Column<int>(type: "int", nullable: false),
                    VeterinarioSecundarioID = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diagnostico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.CitaID);
                    table.ForeignKey(
                        name: "FK_Citas_Mascotas_MascotaID",
                        column: x => x.MascotaID,
                        principalTable: "Mascotas",
                        principalColumn: "MascotaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Citas_Usuarios_VeterinarioPrincipalID",
                        column: x => x.VeterinarioPrincipalID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Citas_Usuarios_VeterinarioSecundarioID",
                        column: x => x.VeterinarioSecundarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citas_MascotaID",
                table: "Citas",
                column: "MascotaID");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_VeterinarioPrincipalID",
                table: "Citas",
                column: "VeterinarioPrincipalID");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_VeterinarioSecundarioID",
                table: "Citas",
                column: "VeterinarioSecundarioID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Citas");
        }
    }
}

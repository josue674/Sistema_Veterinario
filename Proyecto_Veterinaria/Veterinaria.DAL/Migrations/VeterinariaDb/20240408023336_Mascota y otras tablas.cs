using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Veterinaria.DAL.Migrations.VeterinariaDb
{
    /// <inheritdoc />
    public partial class Mascotayotrastablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    GenroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoGenero = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.GenroId);
                });

            migrationBuilder.InsertData(
                table: "Genero",
                columns: new[] { "GenroId", "TipoGenero" },
                values: new object[,]
                {
                        { 1, "Macho" },
                        { 2, "Hembra" }
                });

            migrationBuilder.CreateTable(
                name: "TipoMascota",
                columns: table => new
                {
                    TipoMascotaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionTipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMascota", x => x.TipoMascotaID);
                });

            migrationBuilder.InsertData(
                table: "TipoMascota",
                columns: new[] { "TipoMascotaID", "DescripcionTipo" },
                values: new object[,]
                {
                        { 1, "Perro" },
                        { 2, "Gato" }
                });

            migrationBuilder.CreateTable(
                name: "Raza",
                columns: table => new
                {
                    RazaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionRaza = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TipoMascotaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raza", x => x.RazaID);
                    table.ForeignKey(
                        name: "FK_Raza_TipoMascota_TipoMascotaID",
                        column: x => x.TipoMascotaID,
                        principalTable: "TipoMascota",
                        principalColumn: "TipoMascotaID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.InsertData(
                table: "Raza",
                columns: new[] { "RazaID", "DescripcionRaza", "TipoMascotaID" },
                values: new object[,]
                {
                        { 1, "Labrador",1 },
                        { 2, "Persa",2 }
                });

            migrationBuilder.CreateTable(
                name: "Mascota",
                columns: table => new
                {
                    MascotaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreMascota = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TipoMascotaId = table.Column<int>(type: "int", nullable: false),
                    RazaId = table.Column<int>(type: "int", nullable: false),
                    GeneroId = table.Column<int>(type: "int", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Peso = table.Column<float>(type: "real", nullable: false),
                    UsuarioCreacionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UsuarioModificacionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UsuarioDuenoId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ImagenMascota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mascota", x => x.MascotaID);
                    table.ForeignKey(
                        name: "FK_Mascota_AspNetUsers_UsuarioCreacionId",
                        column: x => x.UsuarioCreacionId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Mascota_AspNetUsers_UsuarioModificacionId",
                        column: x => x.UsuarioModificacionId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Mascota_AspNetUsers_UsuarioDuenoId",
                        column: x => x.UsuarioDuenoId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Mascota_Genero_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Genero",
                        principalColumn: "GenroId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mascota_Raza_RazaId",
                        column: x => x.RazaId,
                        principalTable: "Raza",
                        principalColumn: "RazaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mascota_TipoMascota_TipoMascotaId",
                        column: x => x.TipoMascotaId,
                        principalTable: "TipoMascota",
                        principalColumn: "TipoMascotaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mascota_GeneroId",
                table: "Mascota",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_Mascota_RazaId",
                table: "Mascota",
                column: "RazaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mascota_TipoMascotaId",
                table: "Mascota",
                column: "TipoMascotaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mascota_UsuarioCreacionId",
                table: "Mascota",
                column: "UsuarioCreacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Mascota_UsuarioModificacionId",
                table: "Mascota",
                column: "UsuarioModificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Mascota_UsuarioDuenoId",
                table: "Mascota",
                column: "UsuarioDuenoId");

            migrationBuilder.CreateIndex(
                name: "IX_Raza_TipoMascotaID",
                table: "Raza",
                column: "TipoMascotaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mascota");

            migrationBuilder.DropTable(
                name: "Genero");

            migrationBuilder.DropTable(
                name: "Raza");

            migrationBuilder.DropTable(
                name: "TipoMascota");
        }
    }
}

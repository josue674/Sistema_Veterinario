using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Veterinaria.DAL.Migrations.VeterinariaDb
{
    /// <inheritdoc />
    public partial class Creaciontablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mascota_Genero_GeneroId",
                table: "Mascota");

            migrationBuilder.DropForeignKey(
                name: "FK_Mascota_Raza_RazaId",
                table: "Mascota");

            migrationBuilder.DropForeignKey(
                name: "FK_Mascota_TipoMascota_TipoMascotaId",
                table: "Mascota");

            migrationBuilder.DropForeignKey(
                name: "FK_Raza_TipoMascota_TipoMascotaID",
                table: "Raza");

            //migrationBuilder.AddColumn<string>(
            //    name: "UsuarioDuenoId",
            //    table: "Mascota",
            //    type: "nvarchar(450)",
            //    nullable: true);

            migrationBuilder.CreateTable(
                name: "DesparasitacionVacunas",
                columns: table => new
                {
                    DesparasitacionVacunaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MascotaID = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Producto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesparasitacionVacunas", x => x.DesparasitacionVacunaID);
                    table.ForeignKey(
                        name: "FK_DesparasitacionVacunas_Mascota_MascotaID",
                        column: x => x.MascotaID,
                        principalTable: "Mascota",
                        principalColumn: "MascotaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EstadoCitas",
                columns: table => new
                {
                    EstadoCitaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoCitaNombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoCitas", x => x.EstadoCitaID);
                });

            migrationBuilder.InsertData(
                table: "EstadoCitas",
                columns: new[] { "EstadoCitaID", "EstadoCitaNombre" },
                values: new object[,]
                {
                        { 1, "Agendada" },
                        { 2, "Cancelada" },
                        { 3, "En Curso" },
                        { 4, "Finalizada)" }
                });

            migrationBuilder.CreateTable(
                name: "Medicamentos",
                columns: table => new
                {
                    MedicamentoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreMedicamento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamentos", x => x.MedicamentoID);
                });

            migrationBuilder.InsertData(
                table: "Medicamentos",
                columns: new[] { "MedicamentoID", "NombreMedicamento", "Descripcion" },
                values: new object[,]
                {
                        { 1, "Paracetamol","Para el dolor" },
                        { 2, "Acetaminofen", "Para la infeccio" }
                });


            migrationBuilder.CreateTable(
                name: "Padecimientos",
                columns: table => new
                {
                    PadecimientoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MascotaID = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Padecimientos", x => x.PadecimientoID);
                    table.ForeignKey(
                        name: "FK_Padecimientos_Mascota_MascotaID",
                        column: x => x.MascotaID,
                        principalTable: "Mascota",
                        principalColumn: "MascotaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    CitaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MascotaID = table.Column<int>(type: "int", nullable: false),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VeterinarioPrincipalID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    VeterinarioSecundarioID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diagnostico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoCitaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.CitaID);
                    table.ForeignKey(
                        name: "FK_Citas_AspNetUsers_VeterinarioPrincipalID",
                        column: x => x.VeterinarioPrincipalID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Citas_AspNetUsers_VeterinarioSecundarioID",
                        column: x => x.VeterinarioSecundarioID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Citas_EstadoCitas_EstadoCitaID",
                        column: x => x.EstadoCitaID,
                        principalTable: "EstadoCitas",
                        principalColumn: "EstadoCitaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Citas_Mascota_MascotaID",
                        column: x => x.MascotaID,
                        principalTable: "Mascota",
                        principalColumn: "MascotaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicamentoCita",
                columns: table => new
                {
                    MedicamentoCitaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CitaID = table.Column<int>(type: "int", nullable: false),
                    MedicamentoID = table.Column<int>(type: "int", nullable: false),
                    Dosis = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicamentoCita", x => x.MedicamentoCitaID);
                    table.ForeignKey(
                        name: "FK_MedicamentoCita_Citas_CitaID",
                        column: x => x.CitaID,
                        principalTable: "Citas",
                        principalColumn: "CitaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicamentoCita_Medicamentos_MedicamentoID",
                        column: x => x.MedicamentoID,
                        principalTable: "Medicamentos",
                        principalColumn: "MedicamentoID",
                        onDelete: ReferentialAction.Restrict);
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Mascota_ UsuarioDuenoId",
            //    table: "Mascota",
            //    column: "UsuarioDuenoId");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_EstadoCitaID",
                table: "Citas",
                column: "EstadoCitaID");

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

            migrationBuilder.CreateIndex(
                name: "IX_DesparasitacionVacunas_MascotaID",
                table: "DesparasitacionVacunas",
                column: "MascotaID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicamentoCita_CitaID",
                table: "MedicamentoCita",
                column: "CitaID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicamentoCita_MedicamentoID",
                table: "MedicamentoCita",
                column: "MedicamentoID");

            migrationBuilder.CreateIndex(
                name: "IX_Padecimientos_MascotaID",
                table: "Padecimientos",
                column: "MascotaID");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Mascota_AspNetUsers_UsuarioDuenoId",
            //    table: "Mascota",
            //    column: "UsuarioDuenoId",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mascota_Genero_GeneroId",
                table: "Mascota",
                column: "GeneroId",
                principalTable: "Genero",
                principalColumn: "GenroId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mascota_Raza_RazaId",
                table: "Mascota",
                column: "RazaId",
                principalTable: "Raza",
                principalColumn: "RazaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mascota_TipoMascota_TipoMascotaId",
                table: "Mascota",
                column: "TipoMascotaId",
                principalTable: "TipoMascota",
                principalColumn: "TipoMascotaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Raza_TipoMascota_TipoMascotaID",
                table: "Raza",
                column: "TipoMascotaID",
                principalTable: "TipoMascota",
                principalColumn: "TipoMascotaID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Mascota_AspNetUsers_UsuarioDuenoId",
            //    table: "Mascota");

            migrationBuilder.DropForeignKey(
                name: "FK_Mascota_Genero_GeneroId",
                table: "Mascota");

            migrationBuilder.DropForeignKey(
                name: "FK_Mascota_Raza_RazaId",
                table: "Mascota");

            migrationBuilder.DropForeignKey(
                name: "FK_Mascota_TipoMascota_TipoMascotaId",
                table: "Mascota");

            migrationBuilder.DropForeignKey(
                name: "FK_Raza_TipoMascota_TipoMascotaID",
                table: "Raza");

            migrationBuilder.DropTable(
                name: "DesparasitacionVacunas");

            migrationBuilder.DropTable(
                name: "MedicamentoCita");

            migrationBuilder.DropTable(
                name: "Padecimientos");

            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "Medicamentos");

            migrationBuilder.DropTable(
                name: "EstadoCitas");

            //migrationBuilder.DropIndex(
            //    name: "IX_Mascota_ UsuarioDuenoId",
            //    table: "Mascota");

            //migrationBuilder.DropColumn(
            //    name: "UsuarioDuenoId",
            //    table: "Mascota");

            migrationBuilder.AddForeignKey(
                name: "FK_Mascota_Genero_GeneroId",
                table: "Mascota",
                column: "GeneroId",
                principalTable: "Genero",
                principalColumn: "GenroId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mascota_Raza_RazaId",
                table: "Mascota",
                column: "RazaId",
                principalTable: "Raza",
                principalColumn: "RazaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mascota_TipoMascota_TipoMascotaId",
                table: "Mascota",
                column: "TipoMascotaId",
                principalTable: "TipoMascota",
                principalColumn: "TipoMascotaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Raza_TipoMascota_TipoMascotaID",
                table: "Raza",
                column: "TipoMascotaID",
                principalTable: "TipoMascota",
                principalColumn: "TipoMascotaID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

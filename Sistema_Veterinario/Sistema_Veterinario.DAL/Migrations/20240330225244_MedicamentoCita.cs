using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Veterinario.DAL.Migrations
{
    /// <inheritdoc />
    public partial class MedicamentoCita : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicamentoCitas",
                columns: table => new
                {
                    MedicamentoCitaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CitaID = table.Column<int>(type: "int", nullable: false),
                    MedicamentoID = table.Column<int>(type: "int", nullable: false),
                    Dosis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicamentoCitas", x => x.MedicamentoCitaID);
                    table.ForeignKey(
                        name: "FK_MedicamentoCitas_Citas_CitaID",
                        column: x => x.CitaID,
                        principalTable: "Citas",
                        principalColumn: "CitaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicamentoCitas_Medicamentos_MedicamentoID",
                        column: x => x.MedicamentoID,
                        principalTable: "Medicamentos",
                        principalColumn: "MedicamentoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_DueñoID",
                table: "Mascotas",
                column: "DueñoID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicamentoCitas_CitaID",
                table: "MedicamentoCitas",
                column: "CitaID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicamentoCitas_MedicamentoID",
                table: "MedicamentoCitas",
                column: "MedicamentoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_Usuarios_DueñoID",
                table: "Mascotas",
                column: "DueñoID",
                principalTable: "Usuarios",
                principalColumn: "UsuarioID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_Usuarios_DueñoID",
                table: "Mascotas");

            migrationBuilder.DropTable(
                name: "MedicamentoCitas");

            migrationBuilder.DropIndex(
                name: "IX_Mascotas_DueñoID",
                table: "Mascotas");
        }
    }
}

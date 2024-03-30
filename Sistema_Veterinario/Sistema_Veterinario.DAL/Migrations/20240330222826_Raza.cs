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
                name: "Razas",
                columns: table => new
                {
                    RazaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionRaza = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoMascotaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Razas", x => x.RazaID);
                    table.ForeignKey(
                        name: "FK_Razas_TiposMascota_TipoMascotaID",
                        column: x => x.TipoMascotaID,
                        principalTable: "TiposMascota",
                        principalColumn: "TipoMascotaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_RazaID",
                table: "Mascotas",
                column: "RazaID");

            migrationBuilder.CreateIndex(
                name: "IX_Razas_TipoMascotaID",
                table: "Razas",
                column: "TipoMascotaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_Razas_RazaID",
                table: "Mascotas",
                column: "RazaID",
                principalTable: "Razas",
                principalColumn: "RazaID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_Razas_RazaID",
                table: "Mascotas");

            migrationBuilder.DropTable(
                name: "Razas");

            migrationBuilder.DropIndex(
                name: "IX_Mascotas_RazaID",
                table: "Mascotas");
        }
    }
}

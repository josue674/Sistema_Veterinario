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
                name: "TiposMascota",
                columns: table => new
                {
                    TipoMascotaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionTipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposMascota", x => x.TipoMascotaID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_TipoMascotaID",
                table: "Mascotas",
                column: "TipoMascotaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_TiposMascota_TipoMascotaID",
                table: "Mascotas",
                column: "TipoMascotaID",
                principalTable: "TiposMascota",
                principalColumn: "TipoMascotaID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_TiposMascota_TipoMascotaID",
                table: "Mascotas");

            migrationBuilder.DropTable(
                name: "TiposMascota");

            migrationBuilder.DropIndex(
                name: "IX_Mascotas_TipoMascotaID",
                table: "Mascotas");
        }
    }
}

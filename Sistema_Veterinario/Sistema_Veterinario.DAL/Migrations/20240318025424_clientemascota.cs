using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Veterinario.DAL.Migrations
{
    /// <inheritdoc />
    public partial class clientemascota : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Mascota",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mascota_ClienteId",
                table: "Mascota",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mascota_Cliente_ClienteId",
                table: "Mascota",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mascota_Cliente_ClienteId",
                table: "Mascota");

            migrationBuilder.DropIndex(
                name: "IX_Mascota_ClienteId",
                table: "Mascota");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Mascota");
        }
    }
}

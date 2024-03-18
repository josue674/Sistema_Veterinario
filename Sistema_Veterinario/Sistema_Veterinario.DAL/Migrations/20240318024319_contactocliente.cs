using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Veterinario.DAL.Migrations
{
    /// <inheritdoc />
    public partial class contactocliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Contacto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacto_ClienteId",
                table: "Contacto",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacto_Cliente_ClienteId",
                table: "Contacto",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacto_Cliente_ClienteId",
                table: "Contacto");

            migrationBuilder.DropIndex(
                name: "IX_Contacto_ClienteId",
                table: "Contacto");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Contacto");
        }
    }
}

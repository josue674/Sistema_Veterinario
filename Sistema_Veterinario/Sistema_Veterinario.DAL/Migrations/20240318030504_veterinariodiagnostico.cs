using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Veterinario.DAL.Migrations
{
    /// <inheritdoc />
    public partial class veterinariodiagnostico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiagnosticoId",
                table: "Veterinario",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Veterinario_DiagnosticoId",
                table: "Veterinario",
                column: "DiagnosticoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Veterinario_Diagnostico_DiagnosticoId",
                table: "Veterinario",
                column: "DiagnosticoId",
                principalTable: "Diagnostico",
                principalColumn: "DiagnosticoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veterinario_Diagnostico_DiagnosticoId",
                table: "Veterinario");

            migrationBuilder.DropIndex(
                name: "IX_Veterinario_DiagnosticoId",
                table: "Veterinario");

            migrationBuilder.DropColumn(
                name: "DiagnosticoId",
                table: "Veterinario");
        }
    }
}

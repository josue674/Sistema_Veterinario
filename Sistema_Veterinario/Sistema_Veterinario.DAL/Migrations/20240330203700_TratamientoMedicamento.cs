using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Veterinario.DAL.Migrations
{
    /// <inheritdoc />
    public partial class TratamientoMedicamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TratamientoIdTratamiento",
                table: "Medicamento",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medicamento_TratamientoIdTratamiento",
                table: "Medicamento",
                column: "TratamientoIdTratamiento");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicamento_Tratamiento_TratamientoIdTratamiento",
                table: "Medicamento",
                column: "TratamientoIdTratamiento",
                principalTable: "Tratamiento",
                principalColumn: "IdTratamiento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicamento_Tratamiento_TratamientoIdTratamiento",
                table: "Medicamento");

            migrationBuilder.DropIndex(
                name: "IX_Medicamento_TratamientoIdTratamiento",
                table: "Medicamento");

            migrationBuilder.DropColumn(
                name: "TratamientoIdTratamiento",
                table: "Medicamento");
        }
    }
}

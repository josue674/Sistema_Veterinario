using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Veterinario.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Rolusuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rol",
                table: "Usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "ImagenUsuario",
                table: "Usuarios",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AddColumn<int>(
                name: "RolUsuarioID",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RolUsuarios",
                columns: table => new
                {
                    RolUsuarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreRol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolUsuarios", x => x.RolUsuarioID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolUsuarioID",
                table: "Usuarios",
                column: "RolUsuarioID");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_RolUsuarios_RolUsuarioID",
                table: "Usuarios",
                column: "RolUsuarioID",
                principalTable: "RolUsuarios",
                principalColumn: "RolUsuarioID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_RolUsuarios_RolUsuarioID",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "RolUsuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_RolUsuarioID",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "RolUsuarioID",
                table: "Usuarios");

            migrationBuilder.AlterColumn<byte[]>(
                name: "ImagenUsuario",
                table: "Usuarios",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Rol",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

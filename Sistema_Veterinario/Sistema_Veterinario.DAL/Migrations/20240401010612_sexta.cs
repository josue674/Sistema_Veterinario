using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Veterinario.DAL.Migrations
{
    /// <inheritdoc />
    public partial class sexta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Usuarios_VeterinarioPrincipalID",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Usuarios_VeterinarioSecundarioID",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_Usuarios_DuenoID",
                table: "Mascotas");

            migrationBuilder.DropForeignKey(
                name: "FK_MascotaUsuarioAcciones_Mascotas_MascotaID",
                table: "MascotaUsuarioAcciones");

            migrationBuilder.DropForeignKey(
                name: "FK_MascotaUsuarioAcciones_Usuarios_UsuarioCreacionID",
                table: "MascotaUsuarioAcciones");

            migrationBuilder.DropForeignKey(
                name: "FK_MascotaUsuarioAcciones_Usuarios_UsuarioModificacionID",
                table: "MascotaUsuarioAcciones");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Mascotas_DuenoID",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "DuenoID",
                table: "Mascotas");

            migrationBuilder.RenameColumn(
                name: "UsuarioModificacionID",
                table: "MascotaUsuarioAcciones",
                newName: "UsuarioModificacionId");

            migrationBuilder.RenameColumn(
                name: "UsuarioCreacionID",
                table: "MascotaUsuarioAcciones",
                newName: "UsuarioCreacionId");

            migrationBuilder.RenameColumn(
                name: "MascotaID",
                table: "MascotaUsuarioAcciones",
                newName: "MascotaId");

            migrationBuilder.RenameIndex(
                name: "IX_MascotaUsuarioAcciones_UsuarioModificacionID",
                table: "MascotaUsuarioAcciones",
                newName: "IX_MascotaUsuarioAcciones_UsuarioModificacionId");

            migrationBuilder.RenameIndex(
                name: "IX_MascotaUsuarioAcciones_UsuarioCreacionID",
                table: "MascotaUsuarioAcciones",
                newName: "IX_MascotaUsuarioAcciones_UsuarioCreacionId");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioModificacionId",
                table: "MascotaUsuarioAcciones",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioCreacionId",
                table: "MascotaUsuarioAcciones",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioCreacionId",
                table: "Mascotas",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "VeterinarioSecundarioID",
                table: "Citas",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "VeterinarioPrincipalID",
                table: "Citas",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_UsuarioCreacionId",
                table: "Mascotas",
                column: "UsuarioCreacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_AspNetUsers_VeterinarioPrincipalID",
                table: "Citas",
                column: "VeterinarioPrincipalID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_AspNetUsers_VeterinarioSecundarioID",
                table: "Citas",
                column: "VeterinarioSecundarioID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_AspNetUsers_UsuarioCreacionId",
                table: "Mascotas",
                column: "UsuarioCreacionId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MascotaUsuarioAcciones_AspNetUsers_UsuarioCreacionId",
                table: "MascotaUsuarioAcciones",
                column: "UsuarioCreacionId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MascotaUsuarioAcciones_AspNetUsers_UsuarioModificacionId",
                table: "MascotaUsuarioAcciones",
                column: "UsuarioModificacionId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MascotaUsuarioAcciones_Mascotas_MascotaId",
                table: "MascotaUsuarioAcciones",
                column: "MascotaId",
                principalTable: "Mascotas",
                principalColumn: "MascotaID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_AspNetUsers_VeterinarioPrincipalID",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_AspNetUsers_VeterinarioSecundarioID",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_AspNetUsers_UsuarioCreacionId",
                table: "Mascotas");

            migrationBuilder.DropForeignKey(
                name: "FK_MascotaUsuarioAcciones_AspNetUsers_UsuarioCreacionId",
                table: "MascotaUsuarioAcciones");

            migrationBuilder.DropForeignKey(
                name: "FK_MascotaUsuarioAcciones_AspNetUsers_UsuarioModificacionId",
                table: "MascotaUsuarioAcciones");

            migrationBuilder.DropForeignKey(
                name: "FK_MascotaUsuarioAcciones_Mascotas_MascotaId",
                table: "MascotaUsuarioAcciones");

            migrationBuilder.DropIndex(
                name: "IX_Mascotas_UsuarioCreacionId",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "UsuarioCreacionId",
                table: "Mascotas");

            migrationBuilder.RenameColumn(
                name: "UsuarioModificacionId",
                table: "MascotaUsuarioAcciones",
                newName: "UsuarioModificacionID");

            migrationBuilder.RenameColumn(
                name: "UsuarioCreacionId",
                table: "MascotaUsuarioAcciones",
                newName: "UsuarioCreacionID");

            migrationBuilder.RenameColumn(
                name: "MascotaId",
                table: "MascotaUsuarioAcciones",
                newName: "MascotaID");

            migrationBuilder.RenameIndex(
                name: "IX_MascotaUsuarioAcciones_UsuarioModificacionId",
                table: "MascotaUsuarioAcciones",
                newName: "IX_MascotaUsuarioAcciones_UsuarioModificacionID");

            migrationBuilder.RenameIndex(
                name: "IX_MascotaUsuarioAcciones_UsuarioCreacionId",
                table: "MascotaUsuarioAcciones",
                newName: "IX_MascotaUsuarioAcciones_UsuarioCreacionID");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioModificacionID",
                table: "MascotaUsuarioAcciones",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioCreacionID",
                table: "MascotaUsuarioAcciones",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "DuenoID",
                table: "Mascotas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "VeterinarioSecundarioID",
                table: "Citas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "VeterinarioPrincipalID",
                table: "Citas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RolID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolID = table.Column<int>(type: "int", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    ImagenUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreUsuario = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UltimaConexion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioID);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_RolID",
                        column: x => x.RolID,
                        principalTable: "Roles",
                        principalColumn: "RolID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_DuenoID",
                table: "Mascotas",
                column: "DuenoID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolID",
                table: "Usuarios",
                column: "RolID");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Usuarios_VeterinarioPrincipalID",
                table: "Citas",
                column: "VeterinarioPrincipalID",
                principalTable: "Usuarios",
                principalColumn: "UsuarioID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Usuarios_VeterinarioSecundarioID",
                table: "Citas",
                column: "VeterinarioSecundarioID",
                principalTable: "Usuarios",
                principalColumn: "UsuarioID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_Usuarios_DuenoID",
                table: "Mascotas",
                column: "DuenoID",
                principalTable: "Usuarios",
                principalColumn: "UsuarioID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MascotaUsuarioAcciones_Mascotas_MascotaID",
                table: "MascotaUsuarioAcciones",
                column: "MascotaID",
                principalTable: "Mascotas",
                principalColumn: "MascotaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MascotaUsuarioAcciones_Usuarios_UsuarioCreacionID",
                table: "MascotaUsuarioAcciones",
                column: "UsuarioCreacionID",
                principalTable: "Usuarios",
                principalColumn: "UsuarioID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MascotaUsuarioAcciones_Usuarios_UsuarioModificacionID",
                table: "MascotaUsuarioAcciones",
                column: "UsuarioModificacionID",
                principalTable: "Usuarios",
                principalColumn: "UsuarioID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

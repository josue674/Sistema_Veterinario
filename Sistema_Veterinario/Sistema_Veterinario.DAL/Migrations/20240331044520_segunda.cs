using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Veterinario.DAL.Migrations
{
    /// <inheritdoc />
    public partial class segunda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Citas");

            migrationBuilder.AddColumn<int>(
                name: "MascotaUsuarioAccionID",
                table: "Mascotas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstadoCitaID",
                table: "Citas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EstadoCitas",
                columns: table => new
                {
                    EstadoCitaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoCitaNombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoCitas", x => x.EstadoCitaID);
                });

            // Insertar roles
            migrationBuilder.InsertData(
                table: "EstadoCitas",
                columns: new[] { "EstadoCitaID", "EstadoCitaNombre" },
                values: new object[,]
                {
                    { 1, "Pendiente" },
                    { 2, "En Curso" },
                    { 3, "Terminado" }
                });

            migrationBuilder.CreateTable(
                name: "MascotaUsuarioAcciones",
                columns: table => new
                {
                    MascotaUsuarioAccionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MascotaID = table.Column<int>(type: "int", nullable: false),
                    UsuarioModificacionID = table.Column<int>(type: "int", nullable: false),
                    UsuarioCreacionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MascotaUsuarioAcciones", x => x.MascotaUsuarioAccionID);
                    table.ForeignKey(
                        name: "FK_MascotaUsuarioAcciones_Mascotas_MascotaID",
                        column: x => x.MascotaID,
                        principalTable: "Mascotas",
                        principalColumn: "MascotaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MascotaUsuarioAcciones_Usuarios_UsuarioCreacionID",
                        column: x => x.UsuarioCreacionID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MascotaUsuarioAcciones_Usuarios_UsuarioModificacionID",
                        column: x => x.UsuarioModificacionID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_MascotaUsuarioAccionID",
                table: "Mascotas",
                column: "MascotaUsuarioAccionID");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_EstadoCitaID",
                table: "Citas",
                column: "EstadoCitaID");

            migrationBuilder.CreateIndex(
                name: "IX_MascotaUsuarioAcciones_MascotaID",
                table: "MascotaUsuarioAcciones",
                column: "MascotaID");

            migrationBuilder.CreateIndex(
                name: "IX_MascotaUsuarioAcciones_UsuarioCreacionID",
                table: "MascotaUsuarioAcciones",
                column: "UsuarioCreacionID");

            migrationBuilder.CreateIndex(
                name: "IX_MascotaUsuarioAcciones_UsuarioModificacionID",
                table: "MascotaUsuarioAcciones",
                column: "UsuarioModificacionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_EstadoCitas_EstadoCitaID",
                table: "Citas",
                column: "EstadoCitaID",
                principalTable: "EstadoCitas",
                principalColumn: "EstadoCitaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_MascotaUsuarioAcciones_MascotaUsuarioAccionID",
                table: "Mascotas",
                column: "MascotaUsuarioAccionID",
                principalTable: "MascotaUsuarioAcciones",
                principalColumn: "MascotaUsuarioAccionID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_EstadoCitas_EstadoCitaID",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_MascotaUsuarioAcciones_MascotaUsuarioAccionID",
                table: "Mascotas");

            migrationBuilder.DropTable(
                name: "EstadoCitas");

            migrationBuilder.DropTable(
                name: "MascotaUsuarioAcciones");

            migrationBuilder.DropIndex(
                name: "IX_Mascotas_MascotaUsuarioAccionID",
                table: "Mascotas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_EstadoCitaID",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "MascotaUsuarioAccionID",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "EstadoCitaID",
                table: "Citas");

            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "Citas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

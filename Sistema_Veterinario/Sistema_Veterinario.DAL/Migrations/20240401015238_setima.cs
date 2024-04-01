using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Veterinario.DAL.Migrations
{
    /// <inheritdoc />
    public partial class setima : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_AspNetUsers_VeterinarioPrincipalID",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_AspNetUsers_VeterinarioSecundarioID",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_EstadoCitas_EstadoCitaID",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Mascotas_MascotaID",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_DesparasitacionVacunas_Mascotas_MascotaID",
                table: "DesparasitacionVacunas");

            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_AspNetUsers_UsuarioCreacionId",
                table: "Mascotas");

            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_Razas_RazaID",
                table: "Mascotas");

            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_TipoMascotas_TipoMascotaID",
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

            migrationBuilder.DropForeignKey(
                name: "FK_MedicamentoCita_Citas_CitaID",
                table: "MedicamentoCita");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicamentoCita_Medicamentos_MedicamentoID",
                table: "MedicamentoCita");

            migrationBuilder.DropForeignKey(
                name: "FK_Padecimientos_Mascotas_MascotaID",
                table: "Padecimientos");

            migrationBuilder.DropForeignKey(
                name: "FK_Razas_TipoMascotas_TipoMascotaID",
                table: "Razas");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioModificacionId",
                table: "Mascotas",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_UsuarioModificacionId",
                table: "Mascotas",
                column: "UsuarioModificacionId");

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
                name: "FK_Citas_EstadoCitas_EstadoCitaID",
                table: "Citas",
                column: "EstadoCitaID",
                principalTable: "EstadoCitas",
                principalColumn: "EstadoCitaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Mascotas_MascotaID",
                table: "Citas",
                column: "MascotaID",
                principalTable: "Mascotas",
                principalColumn: "MascotaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DesparasitacionVacunas_Mascotas_MascotaID",
                table: "DesparasitacionVacunas",
                column: "MascotaID",
                principalTable: "Mascotas",
                principalColumn: "MascotaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_AspNetUsers_UsuarioCreacionId",
                table: "Mascotas",
                column: "UsuarioCreacionId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_AspNetUsers_UsuarioModificacionId",
                table: "Mascotas",
                column: "UsuarioModificacionId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_Razas_RazaID",
                table: "Mascotas",
                column: "RazaID",
                principalTable: "Razas",
                principalColumn: "RazaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_TipoMascotas_TipoMascotaID",
                table: "Mascotas",
                column: "TipoMascotaID",
                principalTable: "TipoMascotas",
                principalColumn: "TipoMascotaID",
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

            migrationBuilder.AddForeignKey(
                name: "FK_MedicamentoCita_Citas_CitaID",
                table: "MedicamentoCita",
                column: "CitaID",
                principalTable: "Citas",
                principalColumn: "CitaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicamentoCita_Medicamentos_MedicamentoID",
                table: "MedicamentoCita",
                column: "MedicamentoID",
                principalTable: "Medicamentos",
                principalColumn: "MedicamentoID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Padecimientos_Mascotas_MascotaID",
                table: "Padecimientos",
                column: "MascotaID",
                principalTable: "Mascotas",
                principalColumn: "MascotaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Razas_TipoMascotas_TipoMascotaID",
                table: "Razas",
                column: "TipoMascotaID",
                principalTable: "TipoMascotas",
                principalColumn: "TipoMascotaID",
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
                name: "FK_Citas_EstadoCitas_EstadoCitaID",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Mascotas_MascotaID",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_DesparasitacionVacunas_Mascotas_MascotaID",
                table: "DesparasitacionVacunas");

            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_AspNetUsers_UsuarioCreacionId",
                table: "Mascotas");

            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_AspNetUsers_UsuarioModificacionId",
                table: "Mascotas");

            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_Razas_RazaID",
                table: "Mascotas");

            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_TipoMascotas_TipoMascotaID",
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

            migrationBuilder.DropForeignKey(
                name: "FK_MedicamentoCita_Citas_CitaID",
                table: "MedicamentoCita");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicamentoCita_Medicamentos_MedicamentoID",
                table: "MedicamentoCita");

            migrationBuilder.DropForeignKey(
                name: "FK_Padecimientos_Mascotas_MascotaID",
                table: "Padecimientos");

            migrationBuilder.DropForeignKey(
                name: "FK_Razas_TipoMascotas_TipoMascotaID",
                table: "Razas");

            migrationBuilder.DropIndex(
                name: "IX_Mascotas_UsuarioModificacionId",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "UsuarioModificacionId",
                table: "Mascotas");

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
                name: "FK_Citas_EstadoCitas_EstadoCitaID",
                table: "Citas",
                column: "EstadoCitaID",
                principalTable: "EstadoCitas",
                principalColumn: "EstadoCitaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Mascotas_MascotaID",
                table: "Citas",
                column: "MascotaID",
                principalTable: "Mascotas",
                principalColumn: "MascotaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DesparasitacionVacunas_Mascotas_MascotaID",
                table: "DesparasitacionVacunas",
                column: "MascotaID",
                principalTable: "Mascotas",
                principalColumn: "MascotaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_AspNetUsers_UsuarioCreacionId",
                table: "Mascotas",
                column: "UsuarioCreacionId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_Razas_RazaID",
                table: "Mascotas",
                column: "RazaID",
                principalTable: "Razas",
                principalColumn: "RazaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_TipoMascotas_TipoMascotaID",
                table: "Mascotas",
                column: "TipoMascotaID",
                principalTable: "TipoMascotas",
                principalColumn: "TipoMascotaID",
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

            migrationBuilder.AddForeignKey(
                name: "FK_MedicamentoCita_Citas_CitaID",
                table: "MedicamentoCita",
                column: "CitaID",
                principalTable: "Citas",
                principalColumn: "CitaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicamentoCita_Medicamentos_MedicamentoID",
                table: "MedicamentoCita",
                column: "MedicamentoID",
                principalTable: "Medicamentos",
                principalColumn: "MedicamentoID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Padecimientos_Mascotas_MascotaID",
                table: "Padecimientos",
                column: "MascotaID",
                principalTable: "Mascotas",
                principalColumn: "MascotaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Razas_TipoMascotas_TipoMascotaID",
                table: "Razas",
                column: "TipoMascotaID",
                principalTable: "TipoMascotas",
                principalColumn: "TipoMascotaID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

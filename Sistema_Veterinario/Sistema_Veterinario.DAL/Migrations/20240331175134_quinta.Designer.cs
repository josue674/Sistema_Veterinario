﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sistema_Veterinario.DAL;

#nullable disable

namespace Sistema_Veterinario.DAL.Migrations
{
    [DbContext(typeof(Sistema_VeterinarioDbContext))]
    [Migration("20240331175134_quinta")]
    partial class quinta
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Sistema_Veterinario.DAL.Cita", b =>
                {
                    b.Property<int>("CitaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CitaID"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Diagnostico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstadoCitaID")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaHora")
                        .HasColumnType("datetime2");

                    b.Property<int>("MascotaID")
                        .HasColumnType("int");

                    b.Property<int>("VeterinarioPrincipalID")
                        .HasColumnType("int");

                    b.Property<int>("VeterinarioSecundarioID")
                        .HasColumnType("int");

                    b.HasKey("CitaID");

                    b.HasIndex("EstadoCitaID");

                    b.HasIndex("MascotaID");

                    b.HasIndex("VeterinarioPrincipalID");

                    b.HasIndex("VeterinarioSecundarioID");

                    b.ToTable("Citas");
                });

            modelBuilder.Entity("Sistema_Veterinario.DAL.DesparasitacionVacuna", b =>
                {
                    b.Property<int>("DesparasitacionVacunaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DesparasitacionVacunaID"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("MascotaID")
                        .HasColumnType("int");

                    b.Property<string>("Producto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DesparasitacionVacunaID");

                    b.HasIndex("MascotaID");

                    b.ToTable("DesparasitacionVacunas");
                });

            modelBuilder.Entity("Sistema_Veterinario.DAL.EstadoCita", b =>
                {
                    b.Property<int>("EstadoCitaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstadoCitaID"));

                    b.Property<string>("EstadoCitaNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstadoCitaID");

                    b.ToTable("EstadoCitas");
                });

            modelBuilder.Entity("Sistema_Veterinario.DAL.Mascota", b =>
                {
                    b.Property<int>("MascotaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MascotaID"));

                    b.Property<int>("DuenoID")
                        .HasColumnType("int");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("ImagenMascota")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreMascota")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<float>("Peso")
                        .HasColumnType("real");

                    b.Property<int>("RazaID")
                        .HasColumnType("int");

                    b.Property<int>("TipoMascotaID")
                        .HasColumnType("int");

                    b.HasKey("MascotaID");

                    b.HasIndex("DuenoID");

                    b.HasIndex("RazaID");

                    b.HasIndex("TipoMascotaID");

                    b.ToTable("Mascotas");
                });

            modelBuilder.Entity("Sistema_Veterinario.DAL.MascotaUsuarioAccion", b =>
                {
                    b.Property<int>("MascotaID")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioCreacionID")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioModificacionID")
                        .HasColumnType("int");

                    b.HasKey("MascotaID");

                    b.HasIndex("UsuarioCreacionID");

                    b.HasIndex("UsuarioModificacionID");

                    b.ToTable("MascotaUsuarioAcciones");
                });

            modelBuilder.Entity("Sistema_Veterinario.DAL.Medicamento", b =>
                {
                    b.Property<int>("MedicamentoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicamentoID"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("NombreMedicamento")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MedicamentoID");

                    b.ToTable("Medicamentos");
                });

            modelBuilder.Entity("Sistema_Veterinario.DAL.MedicamentoCita", b =>
                {
                    b.Property<int>("MedicamentoCitaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicamentoCitaID"));

                    b.Property<int>("CitaID")
                        .HasColumnType("int");

                    b.Property<int>("Dosis")
                        .HasColumnType("int");

                    b.Property<int>("MedicamentoID")
                        .HasColumnType("int");

                    b.HasKey("MedicamentoCitaID");

                    b.HasIndex("CitaID");

                    b.HasIndex("MedicamentoID");

                    b.ToTable("MedicamentoCita");
                });

            modelBuilder.Entity("Sistema_Veterinario.DAL.Padecimiento", b =>
                {
                    b.Property<int>("PadecimientoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PadecimientoID"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MascotaID")
                        .HasColumnType("int");

                    b.HasKey("PadecimientoID");

                    b.HasIndex("MascotaID");

                    b.ToTable("Padecimientos");
                });

            modelBuilder.Entity("Sistema_Veterinario.DAL.Raza", b =>
                {
                    b.Property<int>("RazaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RazaID"));

                    b.Property<string>("DescripcionRaza")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TipoMascotaID")
                        .HasColumnType("int");

                    b.HasKey("RazaID");

                    b.HasIndex("TipoMascotaID");

                    b.ToTable("Razas");
                });

            modelBuilder.Entity("Sistema_Veterinario.DAL.Rol", b =>
                {
                    b.Property<int>("RolID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RolID"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RolID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Sistema_Veterinario.DAL.TipoMascota", b =>
                {
                    b.Property<int>("TipoMascotaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoMascotaID"));

                    b.Property<string>("DescripcionTipo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TipoMascotaID");

                    b.ToTable("TipoMascotas");
                });

            modelBuilder.Entity("Sistema_Veterinario.DAL.Usuario", b =>
                {
                    b.Property<int>("UsuarioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioID"));

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("ImagenUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("RolID")
                        .HasColumnType("int");

                    b.Property<DateTime>("UltimaConexion")
                        .HasColumnType("datetime2");

                    b.HasKey("UsuarioID");

                    b.HasIndex("RolID");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Sistema_Veterinario.DAL.Cita", b =>
                {
                    b.HasOne("Sistema_Veterinario.DAL.EstadoCita", "EstadoCita")
                        .WithMany("Citas")
                        .HasForeignKey("EstadoCitaID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Sistema_Veterinario.DAL.Mascota", "Mascota")
                        .WithMany("Citas")
                        .HasForeignKey("MascotaID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Sistema_Veterinario.DAL.Usuario", "VeterinarioPrincipal")
                        .WithMany()
                        .HasForeignKey("VeterinarioPrincipalID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Sistema_Veterinario.DAL.Usuario", "VeterinarioSecundario")
                        .WithMany()
                        .HasForeignKey("VeterinarioSecundarioID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("EstadoCita");

                    b.Navigation("Mascota");

                    b.Navigation("VeterinarioPrincipal");

                    b.Navigation("VeterinarioSecundario");
                });

            modelBuilder.Entity("Sistema_Veterinario.DAL.DesparasitacionVacuna", b =>
                {
                    b.HasOne("Sistema_Veterinario.DAL.Mascota", "Mascota")
                        .WithMany("DesparasitacionesVacunas")
                        .HasForeignKey("MascotaID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Mascota");
                });

            modelBuilder.Entity("Sistema_Veterinario.DAL.Mascota", b =>
                {
                    b.HasOne("Sistema_Veterinario.DAL.Usuario", "Dueno")
                        .WithMany("Mascotas")
                        .HasForeignKey("DuenoID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Sistema_Veterinario.DAL.Raza", "Raza")
                        .WithMany("Mascotas")
                        .HasForeignKey("RazaID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Sistema_Veterinario.DAL.TipoMascota", "TipoMascota")
                        .WithMany("Mascotas")
                        .HasForeignKey("TipoMascotaID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Dueno");

                    b.Navigation("Raza");

                    b.Navigation("TipoMascota");
                });

            modelBuilder.Entity("Sistema_Veterinario.DAL.MascotaUsuarioAccion", b =>
                {
                    b.HasOne("Sistema_Veterinario.DAL.Mascota", "Mascota")
                        .WithMany()
                        .HasForeignKey("MascotaID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Sistema_Veterinario.DAL.Usuario", "UsuarioCreacion")
                        .WithMany()
                        .HasForeignKey("UsuarioCreacionID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Sistema_Veterinario.DAL.Usuario", "UsuarioModificacion")
                        .WithMany()
                        .HasForeignKey("UsuarioModificacionID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Mascota");

                    b.Navigation("UsuarioCreacion");

                    b.Navigation("UsuarioModificacion");
                });

            modelBuilder.Entity("Sistema_Veterinario.DAL.MedicamentoCita", b =>
                {
                    b.HasOne("Sistema_Veterinario.DAL.Cita", "Cita")
                        .WithMany("MedicamentosCita")
                        .HasForeignKey("CitaID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Sistema_Veterinario.DAL.Medicamento", "Medicamento")
                        .WithMany("MedicamentosCita")
                        .HasForeignKey("MedicamentoID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cita");

                    b.Navigation("Medicamento");
                });

            modelBuilder.Entity("Sistema_Veterinario.DAL.Padecimiento", b =>
                {
                    b.HasOne("Sistema_Veterinario.DAL.Mascota", "Mascota")
                        .WithMany("Padecimientos")
                        .HasForeignKey("MascotaID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Mascota");
                });

            modelBuilder.Entity("Sistema_Veterinario.DAL.Raza", b =>
                {
                    b.HasOne("Sistema_Veterinario.DAL.TipoMascota", "TipoMascota")
                        .WithMany("Razas")
                        .HasForeignKey("TipoMascotaID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TipoMascota");
                });

            modelBuilder.Entity("Sistema_Veterinario.DAL.Usuario", b =>
                {
                    b.HasOne("Sistema_Veterinario.DAL.Rol", "Rol")
                        .WithMany("Usuarios")
                        .HasForeignKey("RolID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Sistema_Veterinario.DAL.Cita", b =>
                {
                    b.Navigation("MedicamentosCita");
                });

            modelBuilder.Entity("Sistema_Veterinario.DAL.EstadoCita", b =>
                {
                    b.Navigation("Citas");
                });

            modelBuilder.Entity("Sistema_Veterinario.DAL.Mascota", b =>
                {
                    b.Navigation("Citas");

                    b.Navigation("DesparasitacionesVacunas");

                    b.Navigation("Padecimientos");
                });

            modelBuilder.Entity("Sistema_Veterinario.DAL.Medicamento", b =>
                {
                    b.Navigation("MedicamentosCita");
                });

            modelBuilder.Entity("Sistema_Veterinario.DAL.Raza", b =>
                {
                    b.Navigation("Mascotas");
                });

            modelBuilder.Entity("Sistema_Veterinario.DAL.Rol", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Sistema_Veterinario.DAL.TipoMascota", b =>
                {
                    b.Navigation("Mascotas");

                    b.Navigation("Razas");
                });

            modelBuilder.Entity("Sistema_Veterinario.DAL.Usuario", b =>
                {
                    b.Navigation("Mascotas");
                });
#pragma warning restore 612, 618
        }
    }
}

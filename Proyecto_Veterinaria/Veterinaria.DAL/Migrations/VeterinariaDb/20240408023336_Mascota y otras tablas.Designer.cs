﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Veterinaria.DAL;

#nullable disable

namespace Veterinaria.DAL.Migrations.VeterinariaDb
{
    [DbContext(typeof(VeterinariaDbContext))]
    [Migration("20240408023336_Mascota y otras tablas")]
    partial class Mascotayotrastablas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Veterinaria.DAL.Genero", b =>
                {
                    b.Property<int>("GenroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenroId"));

                    b.Property<string>("TipoGenero")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("GenroId");

                    b.ToTable("Genero");
                });

            modelBuilder.Entity("Veterinaria.DAL.Mascota", b =>
                {
                    b.Property<int>("MascotaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MascotaID"));

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("GeneroId")
                        .HasColumnType("int");

                    b.Property<string>("ImagenMascota")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreMascota")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<float>("Peso")
                        .HasColumnType("real");

                    b.Property<int>("RazaId")
                        .HasColumnType("int");

                    b.Property<int>("TipoMascotaId")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioCreacionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UsuarioModificacionId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MascotaID");

                    b.HasIndex("GeneroId");

                    b.HasIndex("RazaId");

                    b.HasIndex("TipoMascotaId");

                    b.HasIndex("UsuarioCreacionId");

                    b.HasIndex("UsuarioModificacionId");

                    b.ToTable("Mascota");
                });

            modelBuilder.Entity("Veterinaria.DAL.Raza", b =>
                {
                    b.Property<int>("RazaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RazaID"));

                    b.Property<string>("DescripcionRaza")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TipoMascotaID")
                        .HasColumnType("int");

                    b.HasKey("RazaID");

                    b.HasIndex("TipoMascotaID");

                    b.ToTable("Raza");
                });

            modelBuilder.Entity("Veterinaria.DAL.TipoMascota", b =>
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

                    b.ToTable("TipoMascota");
                });

            modelBuilder.Entity("Veterinaria.DAL.Usuario", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<byte[]>("ImagenUsuario")
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("PrimerApellido")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SegundoApellido")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UltimaConexion")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Veterinaria.DAL.Mascota", b =>
                {
                    b.HasOne("Veterinaria.DAL.Genero", "Genr")
                        .WithMany("Mascotas")
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Veterinaria.DAL.Raza", "Raza")
                        .WithMany("Mascotas")
                        .HasForeignKey("RazaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Veterinaria.DAL.TipoMascota", "TipoMascota")
                        .WithMany("Mascotas")
                        .HasForeignKey("TipoMascotaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Veterinaria.DAL.Usuario", "UsuarioCreacion")
                        .WithMany()
                        .HasForeignKey("UsuarioCreacionId");

                    b.HasOne("Veterinaria.DAL.Usuario", "UsuarioModificacion")
                        .WithMany()
                        .HasForeignKey("UsuarioModificacionId");

                    b.Navigation("Genr");

                    b.Navigation("Raza");

                    b.Navigation("TipoMascota");

                    b.Navigation("UsuarioCreacion");

                    b.Navigation("UsuarioModificacion");
                });

            modelBuilder.Entity("Veterinaria.DAL.Raza", b =>
                {
                    b.HasOne("Veterinaria.DAL.TipoMascota", "TipoMascota")
                        .WithMany("Razas")
                        .HasForeignKey("TipoMascotaID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TipoMascota");
                });

            modelBuilder.Entity("Veterinaria.DAL.Genero", b =>
                {
                    b.Navigation("Mascotas");
                });

            modelBuilder.Entity("Veterinaria.DAL.Raza", b =>
                {
                    b.Navigation("Mascotas");
                });

            modelBuilder.Entity("Veterinaria.DAL.TipoMascota", b =>
                {
                    b.Navigation("Mascotas");

                    b.Navigation("Razas");
                });
#pragma warning restore 612, 618
        }
    }
}

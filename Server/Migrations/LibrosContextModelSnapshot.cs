﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoFinal.Server.DAL;

#nullable disable

namespace ProyectoFinal.Server.Migrations
{
    [DbContext(typeof(LibrosContext))]
    partial class LibrosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("ProyectoFinal.Shared.Models.Libros", b =>
                {
                    b.Property<int>("LibroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Imagen")
                        .HasColumnType("BLOB");

                    b.Property<string>("Link")
                        .HasColumnType("TEXT");

                    b.Property<int>("Puntuacion")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Resena")
                        .HasColumnType("TEXT");

                    b.Property<int>("TipoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LibroId");

                    b.ToTable("Libros");
                });

            modelBuilder.Entity("ProyectoFinal.Shared.Models.LibrosDetalle", b =>
                {
                    b.Property<int>("DetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Autor")
                        .HasColumnType("TEXT");

                    b.Property<int>("Disponible")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LibroId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("LoginId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TipoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DetalleId");

                    b.HasIndex("LibroId");

                    b.HasIndex("LoginId");

                    b.ToTable("Detalle");
                });

            modelBuilder.Entity("ProyectoFinal.Shared.Models.Login", b =>
                {
                    b.Property<int>("LoginId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<int>("Rol")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Salt")
                        .HasColumnType("TEXT");

                    b.HasKey("LoginId");

                    b.ToTable("Login");

                    b.HasData(
                        new
                        {
                            LoginId = 1,
                            Email = "loraorlando3713@gmail.com",
                            NombreCompleto = "Orlando Lora",
                            NombreUsuario = "Admin",
                            Password = "admin123",
                            PasswordHash = "246edd79917c961849c0bb9445bf0e927ff568e9c344bcfad7268f48ba49ffff",
                            Rol = 1
                        });
                });

            modelBuilder.Entity("ProyectoFinal.Shared.Models.Roles", b =>
                {
                    b.Property<int>("RolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("NombreRol")
                        .HasColumnType("TEXT");

                    b.HasKey("RolId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RolId = 1,
                            NombreRol = "Administrador"
                        },
                        new
                        {
                            RolId = 2,
                            NombreRol = "Profesor"
                        },
                        new
                        {
                            RolId = 3,
                            NombreRol = "Estudiante"
                        });
                });

            modelBuilder.Entity("ProyectoFinal.Shared.Models.TipoLibro", b =>
                {
                    b.Property<int>("TipoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Disponible")
                        .HasColumnType("INTEGER");

                    b.HasKey("TipoId");

                    b.ToTable("TipoLibro");

                    b.HasData(
                        new
                        {
                            TipoId = 1,
                            Autor = "",
                            Categoria = "Poesía",
                            Disponible = 0
                        },
                        new
                        {
                            TipoId = 2,
                            Autor = "",
                            Categoria = "Ficción",
                            Disponible = 0
                        },
                        new
                        {
                            TipoId = 3,
                            Autor = "",
                            Categoria = "Autoayuda y desarrollo personal",
                            Disponible = 0
                        },
                        new
                        {
                            TipoId = 4,
                            Autor = "",
                            Categoria = "Política y sociedad",
                            Disponible = 0
                        },
                        new
                        {
                            TipoId = 5,
                            Autor = "",
                            Categoria = "Religión y espiritualidad",
                            Disponible = 0
                        },
                        new
                        {
                            TipoId = 6,
                            Autor = "",
                            Categoria = "Historietas y cómics",
                            Disponible = 0
                        },
                        new
                        {
                            TipoId = 7,
                            Autor = "",
                            Categoria = "Viajes y aventuras",
                            Disponible = 0
                        },
                        new
                        {
                            TipoId = 8,
                            Autor = "",
                            Categoria = "Infantil y juvenil",
                            Disponible = 0
                        });
                });

            modelBuilder.Entity("ProyectoFinal.Shared.Models.LibrosDetalle", b =>
                {
                    b.HasOne("ProyectoFinal.Shared.Models.Libros", null)
                        .WithMany("libroDetalle")
                        .HasForeignKey("LibroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoFinal.Shared.Models.Login", null)
                        .WithMany("LibroLoginDetalle")
                        .HasForeignKey("LoginId");
                });

            modelBuilder.Entity("ProyectoFinal.Shared.Models.Libros", b =>
                {
                    b.Navigation("libroDetalle");
                });

            modelBuilder.Entity("ProyectoFinal.Shared.Models.Login", b =>
                {
                    b.Navigation("LibroLoginDetalle");
                });
#pragma warning restore 612, 618
        }
    }
}

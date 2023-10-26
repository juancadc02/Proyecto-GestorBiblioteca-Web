﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(gestorBibliotecaDbContext))]
    [Migration("20231026123646_primera")]
    partial class primera
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DAL.Modelo.Accesos", b =>
                {
                    b.Property<int>("id_acceso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id_acceso"));

                    b.Property<string>("codigo_acceso")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("descripcion_acceso")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id_acceso");

                    b.ToTable("Accesos");
                });

            modelBuilder.Entity("DAL.Modelo.Autores", b =>
                {
                    b.Property<int>("id_autor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id_autor"));

                    b.Property<string>("apellidos_autor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("nombre_autor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id_autor");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("DAL.Modelo.Colecciones", b =>
                {
                    b.Property<int>("id_colecciones")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id_colecciones"));

                    b.Property<string>("nombre_coleccion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id_colecciones");

                    b.ToTable("Colecciones");
                });

            modelBuilder.Entity("DAL.Modelo.Editoriales", b =>
                {
                    b.Property<int>("id_editoriales")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id_editoriales"));

                    b.Property<string>("nombre_editorial")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id_editoriales");

                    b.ToTable("Editoriales");
                });

            modelBuilder.Entity("DAL.Modelo.Generos", b =>
                {
                    b.Property<int>("id_genero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id_genero"));

                    b.Property<string>("descripcion_genero")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("nombre_genero")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id_genero");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("DAL.Modelo.Libros", b =>
                {
                    b.Property<int>("id_libro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id_libro"));

                    b.Property<string>("edicion_libro")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("id_coleccion")
                        .HasColumnType("integer");

                    b.Property<int>("id_editorial")
                        .HasColumnType("integer");

                    b.Property<int>("id_genero")
                        .HasColumnType("integer");

                    b.Property<string>("isbn_libro")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("nombre_libro")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id_libro");

                    b.HasIndex("id_editorial");

                    b.ToTable("Libros");
                });

            modelBuilder.Entity("DAL.Modelo.Prestamos", b =>
                {
                    b.Property<int>("id_prestamos")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id_prestamos"));

                    b.Property<DateTime>("fch_entrega_prestamo")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("fch_fin_prestamo")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("fch_inicio_prestamo")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("id_estado_prestamo")
                        .HasColumnType("integer");

                    b.Property<int>("id_libro")
                        .HasColumnType("integer");

                    b.Property<int>("id_usuario")
                        .HasColumnType("integer");

                    b.HasKey("id_prestamos");

                    b.HasIndex("id_libro");

                    b.HasIndex("id_usuario");

                    b.ToTable("Prestamos");
                });

            modelBuilder.Entity("DAL.Modelo.Rel_Autores_Libros", b =>
                {
                    b.Property<int>("id_rel_autores_libros")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id_rel_autores_libros"));

                    b.Property<int>("autoresid_autor")
                        .HasColumnType("integer");

                    b.Property<int>("id_autor")
                        .HasColumnType("integer");

                    b.Property<int>("id_libro")
                        .HasColumnType("integer");

                    b.Property<int>("librosid_libro")
                        .HasColumnType("integer");

                    b.HasKey("id_rel_autores_libros");

                    b.HasIndex("autoresid_autor");

                    b.HasIndex("librosid_libro");

                    b.ToTable("Rel_Autores_Libros");
                });

            modelBuilder.Entity("DAL.Modelo.Usuarios", b =>
                {
                    b.Property<int>("id_usuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id_usuario"));

                    b.Property<string>("apellidos_usuario")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("clave_usuario")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("dni_usuario")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("email_usuario")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("estaBloqueado_usuario")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("fch_alta_usuario")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("fch_baja_usuario")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("fch_fin_bloqueo_usuario")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("id_acceso")
                        .HasColumnType("integer");

                    b.Property<string>("nombre_usuario")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("tlf_usuario")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id_usuario");

                    b.HasIndex("id_acceso");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("DAL.Modelo.Libros", b =>
                {
                    b.HasOne("DAL.Modelo.Editoriales", "editoriales")
                        .WithMany("Libros")
                        .HasForeignKey("id_editorial")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("editoriales");
                });

            modelBuilder.Entity("DAL.Modelo.Prestamos", b =>
                {
                    b.HasOne("DAL.Modelo.Libros", "libro")
                        .WithMany()
                        .HasForeignKey("id_libro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Modelo.Usuarios", "usuario")
                        .WithMany()
                        .HasForeignKey("id_usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("libro");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("DAL.Modelo.Rel_Autores_Libros", b =>
                {
                    b.HasOne("DAL.Modelo.Autores", "autores")
                        .WithMany("Rel_Autores_Libros")
                        .HasForeignKey("autoresid_autor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Modelo.Libros", "libros")
                        .WithMany("RelacionesAutoresLibros")
                        .HasForeignKey("librosid_libro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("autores");

                    b.Navigation("libros");
                });

            modelBuilder.Entity("DAL.Modelo.Usuarios", b =>
                {
                    b.HasOne("DAL.Modelo.Accesos", "accesos")
                        .WithMany()
                        .HasForeignKey("id_acceso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("accesos");
                });

            modelBuilder.Entity("DAL.Modelo.Autores", b =>
                {
                    b.Navigation("Rel_Autores_Libros");
                });

            modelBuilder.Entity("DAL.Modelo.Editoriales", b =>
                {
                    b.Navigation("Libros");
                });

            modelBuilder.Entity("DAL.Modelo.Libros", b =>
                {
                    b.Navigation("RelacionesAutoresLibros");
                });
#pragma warning restore 612, 618
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class o : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accesos",
                columns: table => new
                {
                    id_acceso = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    codigo_acceso = table.Column<string>(type: "text", nullable: false),
                    descripcion_acceso = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accesos", x => x.id_acceso);
                });

            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    id_autor = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre_autor = table.Column<string>(type: "text", nullable: false),
                    apellidos_autor = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.id_autor);
                });

            migrationBuilder.CreateTable(
                name: "Colecciones",
                columns: table => new
                {
                    id_colecciones = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre_coleccion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colecciones", x => x.id_colecciones);
                });

            migrationBuilder.CreateTable(
                name: "Editoriales",
                columns: table => new
                {
                    id_editoriales = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre_editorial = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editoriales", x => x.id_editoriales);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    id_genero = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre_genero = table.Column<string>(type: "text", nullable: false),
                    descripcion_genero = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.id_genero);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dni_usuario = table.Column<string>(type: "text", nullable: false),
                    nombre_usuario = table.Column<string>(type: "text", nullable: false),
                    apellidos_usuario = table.Column<string>(type: "text", nullable: false),
                    tlf_usuario = table.Column<string>(type: "text", nullable: false),
                    email_usuario = table.Column<string>(type: "text", nullable: false),
                    clave_usuario = table.Column<string>(type: "text", nullable: false),
                    id_acceso = table.Column<int>(type: "integer", nullable: false),
                    estaBloqueado_usuario = table.Column<bool>(type: "boolean", nullable: false),
                    fch_fin_bloqueo_usuario = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fch_alta_usuario = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fch_baja_usuario = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id_usuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Accesos_id_acceso",
                        column: x => x.id_acceso,
                        principalTable: "Accesos",
                        principalColumn: "id_acceso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    id_libro = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    isbn_libro = table.Column<string>(type: "text", nullable: false),
                    nombre_libro = table.Column<string>(type: "text", nullable: false),
                    edicion_libro = table.Column<string>(type: "text", nullable: false),
                    id_editorial = table.Column<int>(type: "integer", nullable: false),
                    id_genero = table.Column<int>(type: "integer", nullable: false),
                    id_coleccion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.id_libro);
                    table.ForeignKey(
                        name: "FK_Libros_Colecciones_id_coleccion",
                        column: x => x.id_coleccion,
                        principalTable: "Colecciones",
                        principalColumn: "id_colecciones",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Libros_Editoriales_id_editorial",
                        column: x => x.id_editorial,
                        principalTable: "Editoriales",
                        principalColumn: "id_editoriales",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Libros_Generos_id_genero",
                        column: x => x.id_genero,
                        principalTable: "Generos",
                        principalColumn: "id_genero",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    id_prestamos = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_libro = table.Column<int>(type: "integer", nullable: false),
                    id_usuario = table.Column<int>(type: "integer", nullable: false),
                    fch_inicio_prestamo = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fch_fin_prestamo = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fch_entrega_prestamo = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    id_estado_prestamo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.id_prestamos);
                    table.ForeignKey(
                        name: "FK_Prestamos_Libros_id_libro",
                        column: x => x.id_libro,
                        principalTable: "Libros",
                        principalColumn: "id_libro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prestamos_Usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "Usuarios",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rel_Autores_Libros",
                columns: table => new
                {
                    id_rel_autores_libros = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_autor = table.Column<int>(type: "integer", nullable: false),
                    id_libro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rel_Autores_Libros", x => x.id_rel_autores_libros);
                    table.ForeignKey(
                        name: "FK_Rel_Autores_Libros_Autores_id_autor",
                        column: x => x.id_autor,
                        principalTable: "Autores",
                        principalColumn: "id_autor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rel_Autores_Libros_Libros_id_libro",
                        column: x => x.id_libro,
                        principalTable: "Libros",
                        principalColumn: "id_libro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libros_id_coleccion",
                table: "Libros",
                column: "id_coleccion");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_id_editorial",
                table: "Libros",
                column: "id_editorial");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_id_genero",
                table: "Libros",
                column: "id_genero");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_id_libro",
                table: "Prestamos",
                column: "id_libro");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_id_usuario",
                table: "Prestamos",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Rel_Autores_Libros_id_autor",
                table: "Rel_Autores_Libros",
                column: "id_autor");

            migrationBuilder.CreateIndex(
                name: "IX_Rel_Autores_Libros_id_libro",
                table: "Rel_Autores_Libros",
                column: "id_libro");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_id_acceso",
                table: "Usuarios",
                column: "id_acceso");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Rel_Autores_Libros");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "Libros");

            migrationBuilder.DropTable(
                name: "Accesos");

            migrationBuilder.DropTable(
                name: "Colecciones");

            migrationBuilder.DropTable(
                name: "Editoriales");

            migrationBuilder.DropTable(
                name: "Generos");
        }
    }
}

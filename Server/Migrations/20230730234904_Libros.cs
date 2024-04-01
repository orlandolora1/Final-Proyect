using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProyectoFinal.Server.Migrations
{
    /// <inheritdoc />
    public partial class Libros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    LibroId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Imagen = table.Column<byte[]>(type: "BLOB", nullable: true),
                    Titulo = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Puntuacion = table.Column<int>(type: "INTEGER", nullable: false),
                    Resena = table.Column<string>(type: "TEXT", nullable: true),
                    Link = table.Column<string>(type: "TEXT", nullable: true),
                    TipoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.LibroId);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    LoginId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreCompleto = table.Column<string>(type: "TEXT", nullable: false),
                    NombreUsuario = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    Salt = table.Column<string>(type: "TEXT", nullable: true),
                    Rol = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.LoginId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreRol = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "TipoLibro",
                columns: table => new
                {
                    TipoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Categoria = table.Column<string>(type: "TEXT", nullable: false),
                    Disponible = table.Column<int>(type: "INTEGER", nullable: false),
                    Autor = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoLibro", x => x.TipoId);
                });

            migrationBuilder.CreateTable(
                name: "Detalle",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LibroId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Disponible = table.Column<int>(type: "INTEGER", nullable: false),
                    Autor = table.Column<string>(type: "TEXT", nullable: true),
                    LoginId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_Detalle_Libros_LibroId",
                        column: x => x.LibroId,
                        principalTable: "Libros",
                        principalColumn: "LibroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Detalle_Login_LoginId",
                        column: x => x.LoginId,
                        principalTable: "Login",
                        principalColumn: "LoginId");
                });

            migrationBuilder.InsertData(
                table: "Login",
                columns: new[] { "LoginId", "Email", "NombreCompleto", "NombreUsuario", "Password", "PasswordHash", "Rol", "Salt" },
                values: new object[] { 1, "Loraorlando3713@gmail.com", "Orlando Lora", "Admin", "admin123", "246edd79917c961849c0bb9445bf0e927ff568e9c344bcfad7268f48ba49ffff", 1, null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RolId", "NombreRol" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Profesor" },
                    { 3, "Estudiante" }
                });

            migrationBuilder.InsertData(
                table: "TipoLibro",
                columns: new[] { "TipoId", "Autor", "Categoria", "Disponible" },
                values: new object[,]
                {
                    { 1, "", "Poesía", 0 },
                    { 2, "", "Ficción", 0 },
                    { 3, "", "Autoayuda y desarrollo personal", 0 },
                    { 4, "", "Política y sociedad", 0 },
                    { 5, "", "Religión y espiritualidad", 0 },
                    { 6, "", "Historietas y cómics", 0 },
                    { 7, "", "Viajes y aventuras", 0 },
                    { 8, "", "Infantil y juvenil", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_LibroId",
                table: "Detalle",
                column: "LibroId");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_LoginId",
                table: "Detalle",
                column: "LoginId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalle");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "TipoLibro");

            migrationBuilder.DropTable(
                name: "Libros");

            migrationBuilder.DropTable(
                name: "Login");
        }
    }
}

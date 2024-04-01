using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProyectoFinal.Server.Migrations.Olimpiadas
{
    /// <inheritdoc />
    public partial class Olimpiada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Olimpiadas",
                columns: table => new
                {
                    PeliculaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Imagen = table.Column<byte[]>(type: "BLOB", nullable: true),
                    Titulo = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Puntuacion = table.Column<int>(type: "INTEGER", nullable: false),
                    Resena = table.Column<string>(type: "TEXT", nullable: true),
                    Trailer = table.Column<string>(type: "TEXT", nullable: true),
                    TipoPeliculaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.PeliculaId);
                });

            migrationBuilder.CreateTable(
                name: "TipoOlimpiada",
                columns: table => new
                {
                    TipoPeliculaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Categoria = table.Column<string>(type: "TEXT", nullable: false),
                    Disponible = table.Column<int>(type: "INTEGER", nullable: false),
                    Actores = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPelicula", x => x.TipoPeliculaId);
                });

            migrationBuilder.CreateTable(
                name: "OlimpiadaDetalle",
                columns: table => new
                {
                    DetallePeliculaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PeliculaId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoPeliculaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Disponible = table.Column<int>(type: "INTEGER", nullable: false),
                    Actores = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculaDetalle", x => x.DetallePeliculaId);
                    table.ForeignKey(
                        name: "FK_PeliculaDetalle_Peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Olimpiadas",
                        principalColumn: "OlimpiadaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TipoOlimpiada",
                columns: new[] { "TipoOlimpiadaId", "Participantes", "Categoria", "Disponible" },
                values: new object[,]
                {
                    { 1, "", "Poesia", 0 },
                    { 2, "", "Ficcion", 0 },
                    { 3, "", "Auto ayuda y Desarrollo Personal", 0 },
                    { 4, "", "Politica y Sociedad", 0 },
                    { 5, "", "Religion y Espiritualidad", 0 },
                    { 6, "", "Historietas y Comics", 0 },
                    { 7, "", "Viajes y Aventuras", 0 },
                    { 8, "", "Infantil y Juvenil", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeliculaDetalle_PeliculaId",
                table: "OlimpiadaDetalle",
                column: "OlimpiadaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OlimpiadaDetalle");

            migrationBuilder.DropTable(
                name: "TipoOlimpiada");

            migrationBuilder.DropTable(
                name: "Olimpiadas");
        }
    }
}

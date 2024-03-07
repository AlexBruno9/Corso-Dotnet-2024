using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dischi2.Migrations
{
    /// <inheritdoc />
    public partial class AggRelazioni : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artisti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artisti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Generi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dischi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titolo = table.Column<string>(type: "TEXT", nullable: true),
                    Anno = table.Column<int>(type: "INTEGER", nullable: false),
                    Prezzo = table.Column<double>(type: "REAL", nullable: false),
                    Id_artista = table.Column<int>(type: "INTEGER", nullable: false),
                    ArtistaId = table.Column<int>(type: "INTEGER", nullable: true),
                    Id_genere = table.Column<int>(type: "INTEGER", nullable: false),
                    GenereId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dischi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dischi_Artisti_ArtistaId",
                        column: x => x.ArtistaId,
                        principalTable: "Artisti",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Dischi_Generi_GenereId",
                        column: x => x.GenereId,
                        principalTable: "Generi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dischi_ArtistaId",
                table: "Dischi",
                column: "ArtistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Dischi_GenereId",
                table: "Dischi",
                column: "GenereId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dischi");

            migrationBuilder.DropTable(
                name: "Artisti");

            migrationBuilder.DropTable(
                name: "Generi");
        }
    }
}

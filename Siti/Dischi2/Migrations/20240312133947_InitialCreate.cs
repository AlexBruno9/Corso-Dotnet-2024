using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dischi2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    ArtistaId = table.Column<int>(type: "INTEGER", nullable: false),
                    GenereId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dischi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dischi_Artisti_ArtistaId",
                        column: x => x.ArtistaId,
                        principalTable: "Artisti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dischi_Generi_GenereId",
                        column: x => x.GenereId,
                        principalTable: "Generi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Canzoni",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titolo = table.Column<string>(type: "TEXT", nullable: true),
                    ArtistaId = table.Column<int>(type: "INTEGER", nullable: false),
                    DiscoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canzoni", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Canzoni_Artisti_ArtistaId",
                        column: x => x.ArtistaId,
                        principalTable: "Artisti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Canzoni_Dischi_DiscoId",
                        column: x => x.DiscoId,
                        principalTable: "Dischi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Playlist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomePlaylist = table.Column<string>(type: "TEXT", nullable: true),
                    CanzoneId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Playlist_Canzoni_CanzoneId",
                        column: x => x.CanzoneId,
                        principalTable: "Canzoni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Canzoni_ArtistaId",
                table: "Canzoni",
                column: "ArtistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Canzoni_DiscoId",
                table: "Canzoni",
                column: "DiscoId");

            migrationBuilder.CreateIndex(
                name: "IX_Dischi_ArtistaId",
                table: "Dischi",
                column: "ArtistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Dischi_GenereId",
                table: "Dischi",
                column: "GenereId");

            migrationBuilder.CreateIndex(
                name: "IX_Playlist_CanzoneId",
                table: "Playlist",
                column: "CanzoneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Playlist");

            migrationBuilder.DropTable(
                name: "Canzoni");

            migrationBuilder.DropTable(
                name: "Dischi");

            migrationBuilder.DropTable(
                name: "Artisti");

            migrationBuilder.DropTable(
                name: "Generi");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dischi2.Migrations
{
    /// <inheritdoc />
    public partial class FixRel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dischi_Artisti_ArtistaId",
                table: "Dischi");

            migrationBuilder.DropForeignKey(
                name: "FK_Dischi_Generi_GenereId",
                table: "Dischi");

            migrationBuilder.DropColumn(
                name: "Id_artista",
                table: "Dischi");

            migrationBuilder.DropColumn(
                name: "Id_genere",
                table: "Dischi");

            migrationBuilder.AlterColumn<int>(
                name: "GenereId",
                table: "Dischi",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ArtistaId",
                table: "Dischi",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dischi_Artisti_ArtistaId",
                table: "Dischi",
                column: "ArtistaId",
                principalTable: "Artisti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dischi_Generi_GenereId",
                table: "Dischi",
                column: "GenereId",
                principalTable: "Generi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dischi_Artisti_ArtistaId",
                table: "Dischi");

            migrationBuilder.DropForeignKey(
                name: "FK_Dischi_Generi_GenereId",
                table: "Dischi");

            migrationBuilder.AlterColumn<int>(
                name: "GenereId",
                table: "Dischi",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "ArtistaId",
                table: "Dischi",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "Id_artista",
                table: "Dischi",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_genere",
                table: "Dischi",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Dischi_Artisti_ArtistaId",
                table: "Dischi",
                column: "ArtistaId",
                principalTable: "Artisti",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dischi_Generi_GenereId",
                table: "Dischi",
                column: "GenereId",
                principalTable: "Generi",
                principalColumn: "Id");
        }
    }
}

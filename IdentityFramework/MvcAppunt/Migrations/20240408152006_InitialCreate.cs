using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcAppunt.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StatoAttivo",
                table: "AspNetUsers",
                newName: "Stato");

            migrationBuilder.RenameColumn(
                name: "CodiceFornitore",
                table: "AspNetUsers",
                newName: "Codice");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Stato",
                table: "AspNetUsers",
                newName: "StatoAttivo");

            migrationBuilder.RenameColumn(
                name: "Codice",
                table: "AspNetUsers",
                newName: "CodiceFornitore");
        }
    }
}

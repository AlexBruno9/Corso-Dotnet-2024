using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppMvcProva.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Accounts",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeProfilo",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accounts",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NomeProfilo",
                table: "AspNetUsers");
        }
    }
}

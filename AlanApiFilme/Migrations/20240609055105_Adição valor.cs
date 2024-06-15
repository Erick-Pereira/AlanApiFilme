using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlanApiFilme.Migrations
{
    /// <inheritdoc />
    public partial class Adiçãovalor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Participante",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "Valor",
                table: "FILMES",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valor",
                table: "FILMES");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Participante",
                newName: "Id");
        }
    }
}

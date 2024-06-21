using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlanApiFilme.Migrations
{
    /// <inheritdoc />
    public partial class inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FILMES",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", unicode: false, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoriaID = table.Column<Guid>(type: "char(36)", unicode: false, nullable: false, collation: "ascii_general_ci"),
                    ClassificacaoID = table.Column<Guid>(type: "char(36)", unicode: false, nullable: false, collation: "ascii_general_ci"),
                    Valor = table.Column<int>(type: "int", nullable: false),
                    GeneroID = table.Column<Guid>(type: "char(36)", unicode: false, nullable: false, collation: "ascii_general_ci"),
                    MidiaID = table.Column<Guid>(type: "char(36)", unicode: false, nullable: false, collation: "ascii_general_ci"),
                    TipoMidiaID = table.Column<Guid>(type: "char(36)", unicode: false, nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FILMES", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Participante",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participante", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FilmeParticipante",
                columns: table => new
                {
                    FilmesID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Participantesid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmeParticipante", x => new { x.FilmesID, x.Participantesid });
                    table.ForeignKey(
                        name: "FK_FilmeParticipante_FILMES_FilmesID",
                        column: x => x.FilmesID,
                        principalTable: "FILMES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmeParticipante_Participante_Participantesid",
                        column: x => x.Participantesid,
                        principalTable: "Participante",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_FilmeParticipante_Participantesid",
                table: "FilmeParticipante",
                column: "Participantesid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmeParticipante");

            migrationBuilder.DropTable(
                name: "FILMES");

            migrationBuilder.DropTable(
                name: "Participante");
        }
    }
}

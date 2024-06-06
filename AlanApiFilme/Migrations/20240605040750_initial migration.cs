using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlanApiFilme.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
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
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participante", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PARTICIPANTE_FILME",
                columns: table => new
                {
                    FilmeID = table.Column<Guid>(type: "char(36)", unicode: false, nullable: false, collation: "ascii_general_ci"),
                    ParticipanteID = table.Column<Guid>(type: "char(36)", unicode: false, nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PARTICIPANTE_FILME", x => new { x.ParticipanteID, x.FilmeID });
                    table.ForeignKey(
                        name: "FK_PARTICIPANTE_FILME_FILMES_FilmeID",
                        column: x => x.FilmeID,
                        principalTable: "FILMES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PARTICIPANTE_FILME_Participante_ParticipanteID",
                        column: x => x.ParticipanteID,
                        principalTable: "Participante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PARTICIPANTE_FILME_FilmeID",
                table: "PARTICIPANTE_FILME",
                column: "FilmeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PARTICIPANTE_FILME");

            migrationBuilder.DropTable(
                name: "FILMES");

            migrationBuilder.DropTable(
                name: "Participante");
        }
    }
}

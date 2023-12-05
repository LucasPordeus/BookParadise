using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookParadise.Data.Migrations
{
    /// <inheritdoc />
    public partial class RelacionamentoLivroCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaLivro",
                columns: table => new
                {
                    CategoriasCategoriaId = table.Column<int>(type: "int", nullable: false),
                    LivrosLivroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaLivro", x => new { x.CategoriasCategoriaId, x.LivrosLivroId });
                    table.ForeignKey(
                        name: "FK_CategoriaLivro_Categoria_CategoriasCategoriaId",
                        column: x => x.CategoriasCategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriaLivro_Livro_LivrosLivroId",
                        column: x => x.LivrosLivroId,
                        principalTable: "Livro",
                        principalColumn: "LivroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaLivro_LivrosLivroId",
                table: "CategoriaLivro",
                column: "LivrosLivroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriaLivro");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookParadise.Data.Migrations
{
    /// <inheritdoc />
    public partial class RelacionamentoLivroProdutora : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProdutoraId",
                table: "Livro",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Livro_ProdutoraId",
                table: "Livro",
                column: "ProdutoraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Livro_Produtora_ProdutoraId",
                table: "Livro",
                column: "ProdutoraId",
                principalTable: "Produtora",
                principalColumn: "ProdutoraId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livro_Produtora_ProdutoraId",
                table: "Livro");

            migrationBuilder.DropIndex(
                name: "IX_Livro_ProdutoraId",
                table: "Livro");

            migrationBuilder.DropColumn(
                name: "ProdutoraId",
                table: "Livro");
        }
    }
}

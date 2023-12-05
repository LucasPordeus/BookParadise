using BookParadise.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookParadise.Data.Migrations
{
    /// <inheritdoc />
    public partial class CargaInicialCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var context = new LivroDbContext();
            context.Categoria.AddRange(ObterCargaInicial());
            context.SaveChanges();
        }

        private IList<Categoria> ObterCargaInicial()
        {
            return new List<Categoria>()
            {
                new Categoria() { Descricao = "Romance" },
                new Categoria() { Descricao = "Ficção" },
                new Categoria() { Descricao = "Aventura" },
                new Categoria() { Descricao = "Terror" },
            };
        }
    }
}

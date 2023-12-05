using Microsoft.EntityFrameworkCore.Migrations;
using BookParadise.Models;

#nullable disable

namespace BookParadise.Data.Migrations
{
    /// <inheritdoc />
    public partial class CargaInicialLivro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var context = new LivroDbContext();
            context.Livro.AddRange(ObterCargaInicial());
            context.SaveChanges();
        }

        private IList<Livro> ObterCargaInicial()
        {
            return new List<Livro>()
            {
                new Livro
            {
                Nome = "O Senhor dos Anéis",
                Autor = "J.R.R. Tolkien",
                ImagemUri = "/images/senhor_dos_aneis.jpg",
                DataCadastro = DateTime.Now,
                EntregaExpressa = true,
                Preco = 19.00,
            },
            new Livro
            {
                Nome = "1984 - George Orwell",
                Autor = "George Orwell",
                ImagemUri = "/images/1984.jpg",
                DataCadastro = DateTime.Now,
                EntregaExpressa = false,
                Preco = 29.00,
            },
            new Livro
            {
                Nome = "Cem Anos de Solidão",
                Autor = "Gabriel García Márquez",
                ImagemUri = "/images/100anos.jpg",
                DataCadastro = DateTime.Now,
                EntregaExpressa = true,
                Preco = 39.00,
            },
            new Livro
            {
                Nome = "O Apanhador no Campo de Centeio",
                Autor = "Gabriel",
                ImagemUri = "/images/campo_centeio.jpg",
                DataCadastro = DateTime.Now,
                EntregaExpressa = true,
                Preco = 49.00,
            },
            };
        }
    }
}

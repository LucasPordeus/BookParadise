using BookParadise.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookParadise.Data.Migrations
{
    /// <inheritdoc />
    public partial class CargaInicialProdutora : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var context = new LivroDbContext();
            context.Produtora.AddRange(ObterCargaInicial());
            context.SaveChanges();
        }

        private IList<Produtora> ObterCargaInicial()
        {
            return new List<Produtora>()
            {
                new Produtora() { Descricao = "Umbrella-Rosenblum" },
                new Produtora() { Descricao = "4LF" },
                new Produtora() { Descricao = "WingNut" },
            };
        }
    }
}

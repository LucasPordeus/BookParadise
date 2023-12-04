using BookParadise.Models;
using BookParadise.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace BookParadise.Services.Data
{
    public class LivroService : ILivroService
    {
        private LivroDbContext _context;

        public LivroService(LivroDbContext context)
        {
            _context = context;
        }

        public void Alterar(Livro livro)
        {
            var hamburguerEncontrado = Obter(livro.LivroId);
            hamburguerEncontrado.Nome = livro.Nome;
            hamburguerEncontrado.Preco = livro.Preco;
            hamburguerEncontrado.EntregaExpressa = livro.EntregaExpressa;
            hamburguerEncontrado.DataCadastro = livro.DataCadastro;
            hamburguerEncontrado.ImagemUri = livro.ImagemUri;
            hamburguerEncontrado.ProdutoraId = livro.ProdutoraId;
            hamburguerEncontrado.Categorias = livro.Categorias;

            _context.SaveChanges();
        }

        public void Excluir(int id)
        {
            var livroEncontrado = Obter(id);
            _context.Livro.Remove(livroEncontrado);
            _context.SaveChanges();
        }

        public void Incluir(Livro livro)
        {
            _context.Livro.Add(livro);
            _context.SaveChanges();
        }

        public Livro Obter(int id)
        {
            return _context.Livro
                            .Include(item => item.Categorias)
                            .SingleOrDefault(item => item.LivroId == id);
        }

        public IList<Categoria> ObterTodasAsCategorias()
        {
            return _context.Categoria.ToList();
        }

        public IList<Produtora> ObterTodasAsProdutoras()
        {
            return _context.Produtora.ToList();
        }

        public IList<Livro> ObterTodos()
        {
            return _context.Livro.ToList();
        }
    }
}

using BookParadise.Models;

namespace BookParadise.Services
{
    public interface ILivroService
    {
        IList<Livro> ObterTodos();
        Livro Obter(int id);
        void Incluir(Livro livro);
        void Alterar(Livro livro);
        void Excluir(int id);
        IList<Produtora> ObterTodasAsProdutoras();
        IList<Categoria> ObterTodasAsCategorias();
    }
}

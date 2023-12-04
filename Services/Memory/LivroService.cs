using BookParadise.Models;

namespace BookParadise.Services.Memory
{
    public class LivroService : ILivroService
    {
        private IList<Livro> _livros;

        public LivroService()
            => CarregarListaInicial();

        private void CarregarListaInicial()
        {
            _livros = new List<Livro>()
        {
            new Livro
            {
                LivroId = 1,
                Nome = "O Senhor dos Anéis",
                ImagemUri = "/images/senhor_dos_aneis.jpg",
                DataCadastro = DateTime.Now,
                EntregaExpressa = true,
                Preco = 19.00,
            },
            new Livro
            {
                LivroId = 2,
                Nome = "1984",
                ImagemUri = "/images/1984.jpg",
                DataCadastro = DateTime.Now,
                EntregaExpressa = false,
                Preco = 29.00,
            },
            new Livro
            {
                LivroId = 3,
                Nome = "Cem Anos de Solidão",
                ImagemUri = "/images/100anos.jpg",
                DataCadastro = DateTime.Now,
                EntregaExpressa = true,
                Preco = 39.00,
            },
            new Livro
            {
                LivroId = 4,
                Nome = "O Apanhador no Campo de Centeio",
                ImagemUri = "/images/campo_centeio.jpg",
                DataCadastro = DateTime.Now,
                EntregaExpressa = true,
                Preco = 49.00,
            },
        };
        }

        public IList<Livro> ObterTodos()
            => _livros;

        public Livro Obter(int id)
        {
            return _livros.SingleOrDefault(item => item.LivroId == id);
        }

        public void Incluir(Livro livro)
        {
            var proximoNumero = _livros.Max(item => item.LivroId) + 1;
            livro.LivroId = proximoNumero;
            _livros.Add(livro);
        }

        public void Alterar(Livro livro)
        {
            var livroEncontrado = Obter(livro.LivroId);
            livroEncontrado.Nome = livro.Nome;
            livroEncontrado.Preco = livro.Preco;
            livroEncontrado.EntregaExpressa = livro.EntregaExpressa;
            livroEncontrado.DataCadastro = livro.DataCadastro;
            livroEncontrado.ImagemUri = livro.ImagemUri;
        }

        public void Excluir(int id)
        {
            var livroEncontrado = Obter(id);
            _livros.Remove(livroEncontrado);
        }

        public IList<Produtora> ObterTodasAsProdutoras()
        {
            return new List<Produtora>()
            {
            new Produtora() { Descricao = "Umbrella-Rosenblum" },
            new Produtora() { Descricao = "4LF" },
            new Produtora() { Descricao = "WingNut" },
        };
        }

        public IList<Categoria> ObterTodasAsCategorias()
        {
            return new List<Categoria>()
        {
            new Categoria() { Descricao = "Ficção" },
            new Categoria() { Descricao = "Fantasia" },
            new Categoria() { Descricao = "Romance" },
            new Categoria() { Descricao = "Distopia" },
        };
        }
    }
}

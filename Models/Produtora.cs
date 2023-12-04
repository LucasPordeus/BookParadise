namespace BookParadise.Models
{
    public class Produtora
    {
        public int ProdutoraId { get; set; }
        public string Descricao { get; set; }

        public ICollection<Livro> Livros { get; set; }
    }
}

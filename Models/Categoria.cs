namespace BookParadise.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Descricao { get; set; }
        public ICollection<Livro>? Livros { get; set; }
    }
}

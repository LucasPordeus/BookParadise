using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookParadise.Models
{
    public class Livro
    {
        public int LivroId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo 'Nome' obrigatório.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Campo 'Nome'deve conter entre 10 e 50 caracteres.")]
        public string Nome { get; set; }

        public string NomeSlug => Nome?.ToLower().Replace(" ", "-");

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo 'Autor' obrigatório.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Campo 'Autor'deve conter entre 10 e 50 caracteres.")]
        public string Autor { get; set; }

        [Display(Name = "Caminho da Imagem")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo 'Caminho da Image' obrigatório.")]
        public string ImagemUri { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "Campo 'Preço' obrigatório.")]
        [DataType(DataType.Currency)]
        public double Preco { get; set; }

        [Display(Name = "Entrega Expressa")]
        public bool EntregaExpressa { get; set; }

        public string EntregaExpressaFormatada => EntregaExpressa ? "Sim" : "Não";

        [Display(Name = "Disponível em")]
        [Required(ErrorMessage = "Campo 'Disponível em' obrigatório.")]
        [DataType("month")]
        [DisplayFormat(DataFormatString = "{0:MMMM \\de yyyy}")]
        public DateTime DataCadastro { get; set; }

        [Display(Name = "Marca")]
        public int? ProdutoraId { get; set; }

        public ICollection<Categoria>? Categorias { get; set; }

    }
}

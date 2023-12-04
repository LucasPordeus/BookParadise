using BookParadise.Models;
using BookParadise.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace BookParadise.Pages
{
    public class DetailsModel : PageModel
    {
        private ILivroService _service;

        public DetailsModel(ILivroService livroService)
        {
            _service = livroService;
        }

        public Livro Livro { get; private set; }
        public Produtora Produtora { get; private set; }

        public IActionResult OnGet(int id)
        {
            Livro = _service.Obter(id);
            Produtora = _service.ObterTodasAsProdutoras().SingleOrDefault(item => item.ProdutoraId == Livro.ProdutoraId);

            if (Livro == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}

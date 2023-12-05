using BookParadise.Models;
using BookParadise.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.RegularExpressions;

namespace BookParadise.Pages
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private ILivroService _service;
        public SelectList ProdutoraOptionItems { get; set; }
        public SelectList CategoriaOptionItems { get; set; }

        public CreateModel(ILivroService livroService)
        {
            _service = livroService;
        }

        public void OnGet()
        {
            ProdutoraOptionItems = new SelectList(_service.ObterTodasAsProdutoras(),
                                                nameof(Produtora.ProdutoraId),
                                                nameof(Produtora.Descricao));

            CategoriaOptionItems = new SelectList(_service.ObterTodasAsCategorias(),
                                                nameof(Categoria.CategoriaId),
                                                nameof(Categoria.Descricao));
        }


        [BindProperty]
        public Livro Livro { get; set; }

        [BindProperty]
        public IList<int> CategoriaIds { get; set; }

        public IActionResult OnPost()
        {
            Livro.Categorias = _service.ObterTodasAsCategorias()
                                            .Where(item => CategoriaIds.Contains(item.CategoriaId))
                                            .ToList();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.Incluir(Livro);

            return RedirectToPage("/Index");
        }
    }
}

using BookParadise.Models;
using BookParadise.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;

namespace BookParadise.Pages
{
    [Authorize]
    public class EditModel : PageModel
    {
        private IToastNotification _toastNotification;
        private ILivroService _service;
        public SelectList ProdutoraOptionItems { get; set; }
        public SelectList CategoriaOptionItems { get; set; }

        public EditModel(ILivroService livroService,
                         IToastNotification toastNotification)
        {
            _service = livroService;
            _toastNotification = toastNotification;
        }

        [BindProperty]
        public Livro Livro { get; set; }

        [BindProperty]
        public IList<int> CategoriaIds { get; set; }

        public void OnGet(int id)
        {
            Livro = _service.Obter(id);

            CategoriaIds = Livro.Categorias.Select(item => item.CategoriaId).ToList();

            ProdutoraOptionItems = new SelectList(_service.ObterTodasAsProdutoras(),
                                                nameof(Produtora.ProdutoraId),
                                                nameof(Produtora.Descricao));

            CategoriaOptionItems = new SelectList(_service.ObterTodasAsCategorias(),
                                                nameof(Categoria.CategoriaId),
                                                nameof(Categoria.Descricao));
        }

        public IActionResult OnPost()
        {
            Livro.Categorias = _service.ObterTodasAsCategorias()
                                            .Where(item => CategoriaIds.Contains(item.CategoriaId))
                                            .ToList();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.Alterar(Livro);

            _toastNotification.AddSuccessToastMessage("Operação realizada com sucesso!");

            return RedirectToPage("/Index");
        }

        public IActionResult OnPostDelete()
        {
            _service.Excluir(Livro.LivroId);

            _toastNotification.AddSuccessToastMessage("Operação realizada com sucesso!");

            return RedirectToPage("/Index");
        }
    }
}

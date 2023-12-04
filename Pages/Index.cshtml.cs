using BookParadise.Models;
using BookParadise.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookParadise.Pages
{
    public class IndexModel : PageModel
    {
        private ILivroService _service;

        public IndexModel(ILivroService livroService)
        {
            _service = livroService;
        }

        public IList<Livro> ListaLivros { get; private set; }

        public void OnGet()
        {
            ViewData["Title"] = "Home page";

            ListaLivros = _service.ObterTodos();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using ProjetoEmprestimoAspCore.GerenciarArquivos;
using ProjetoEmprestimoAspCore.Models;
using ProjetoEmprestimoAspCore.Repository.Contract;

namespace ProjetoEmprestimoAspCore.Controllers
{
    public class LivrosController : Controller
    {
        private ILivroRepository _livroRepository;

        public LivrosController(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Livro livro, IFormFile file)
        {
            var Caminho = GerenciadorArquivos.CadastrarImagemProduto(file);

            livro.ImagemLivro = Caminho;

            _livroRepository.Cadastrar(livro);

            ViewBag.msg = "Cadastro Realizado";
            return View();
        }
    }
}

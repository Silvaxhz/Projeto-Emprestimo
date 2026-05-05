using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using ProjetoEmprestimoAspCore.CarrinhoCompra;
using ProjetoEmprestimoAspCore.Models;
using ProjetoEmprestimoAspCore.Repository.Contract;

namespace ProjetoEmprestimoAspCore.Controllers
{
    public class HomeController : Controller
    {
        private ILivroRepository _livroRepository;
        private CookieCarrinhoCompra _cookieCarrinhoCompra;

        private IEmprestimoRepository _emprestimoRepository;
        private IItemRepository _itemRepository;

        public HomeController(ILivroRepository livroRepository, CookieCarrinhoCompra cookieCarrinhoCompra,
                              IEmprestimoRepository emprestimoRepository, IItemRepository itemRepository)
        {
            _livroRepository = livroRepository;
            _cookieCarrinhoCompra = cookieCarrinhoCompra;
            _emprestimoRepository = emprestimoRepository;
            _itemRepository = itemRepository;
        }

        public IActionResult Index()
        {
            return View(_livroRepository.ObterTodosLivros());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AdicionarItem(int id)
        {
            Livro produto = _livroRepository.ObterLivros(id);

            if (produto == null)
            {
                return View("NaoExistemItem");
            }
            else
            {
                var item = new Livro()
                {
                    CodLivro = id,
                    Quantidade = 1,
                    ImagemLivro = produto.ImagemLivro,
                    NomeLivro = produto.NomeLivro,
                };
                _cookieCarrinhoCompra.Cadastrar(item);

                return RedirectToAction(nameof(Carrinho));

            }

        }
        public IActionResult Carrinho()
        {
            return View(_cookieCarrinhoCompra.Consultar);
        }

        public IActionResult RemoverItem(int id)
        {
            _cookieCarrinhoCompra.Remover(new Livro() { CodLivro = id });
            return RedirectToAction(nameof(Carrinho));
        }
        
        DateTime data;

        public IActionResult SalvarCarrinho(Emprestimo emprestimo)
        {
            List<Livro> carrinho = _cookieCarrinhoCompra.Consultar();
            
            Emprestimo mdE = new Emprestimo();
            Item mdI = new Item();

            data = DateTime.Now.ToLocalTime();

            mdE.DtEmpre = data.ToString("dd/MM/yyyy");
            mdE.DtDev = data.AddDays(7).ToString();
            mdE.CodUsu = "1";
            _emprestimoRepository.Cadastrar(mdE);

            _emprestimoRepository.BuscaIdEmp(emprestimo);

            for(int i = 0; i < carrinho.Count; i++)
            {
                mdI.CodEmp = Convert.ToInt32(emprestimo.CodEmp);
                mdI.CodLivro = Convert.ToString(carrinho[i].CodLivro);

                _itemRepository.Cadastrar(mdI);
            }

            _cookieCarrinhoCompra.RemoverTodos();
            return RedirectToAction("confEmp");

        }

        public IActionResult confEmp()
        {
            return View();
        }
    }

}

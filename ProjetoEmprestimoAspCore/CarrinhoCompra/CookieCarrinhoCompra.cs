using Microsoft.VisualStudio.Web.CodeGeneration.Templating;
using Newtonsoft.Json;
using ProjetoEmprestimoAspCore.Models;

namespace ProjetoEmprestimoAspCore.CarrinhoCompra
{
    public class CookieCarrinhoCompra
    {
        private string Key = "Carrinho.Compras";
        private Cookie.Cookie _cookie;

        public CookieCarrinhoCompra(Cookie.Cookie cookie)
        {
            _cookie = cookie;
        }
        public void Salvar(List<Livro> Lista)
        {
            string Valor = JsonConvert.SerializeObject(Lista);
            _cookie.Cadastrar(Key, Valor);
        }
        public List<Livro> Consultar()
        {
            if (_cookie.Existe(Key))
            {
                string valor = _cookie.Consultar(Key);
                return JsonConvert.DeserializeObject<List<Livro>>(valor);
            }
            else
            {
                return new List<Livro>();
            }
        }
        public void Cadastrar(Livro item)
        {
            List<Livro> Lista;
            if (_cookie.Existe(Key))
            {
                Lista = Consultar();
                var ItemLocalizado = Lista.SingleOrDefault(a => a.CodLivro == item.CodLivro);

                if (ItemLocalizado == null)
                {
                    Lista.Add(item);
                }
                else
                {
                    ItemLocalizado.Quantidade = ItemLocalizado.Quantidade + 1;
                }
            }
            else
            {
                Lista = new List<Livro>();
                Lista.Add(item);
            }
            Salvar(Lista);

        }
    }
}

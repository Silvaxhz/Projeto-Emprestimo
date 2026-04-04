namespace ProjetoEmprestimoAspCore.Cookie
{
    public class Cookie
    {
        private IHttpContextAccessor _context;
        private IConfiguration _configuration;

        public Cookie(IHttpContextAccessor context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public void Cadastrar(String Key, String Valor)
        {
            CookieOptions Options = new CookieOptions();
            Options.Expires = DateTime.Now.AddDays(7);
            Options.IsEssential = true;

            _context.HttpContext.Response.Cookies.Append(Key, Valor, Options);
        }
        public void Atualizar(String Key, String Valor)
        {
            if (Existe(Key))
            {
                Remover(Key);
            }
            Cadastrar(Key, Valor);
        }
        public void Remover(String Key)
        {
            _context.HttpContext.Response.Cookies.Delete(Key);
        }
        public string Consultar(String Key, bool Cript = true)
        {
            var valor = _context.HttpContext.Request.Cookies[Key];
            return valor;
        }
        public bool Existe(String Key)
        {
            if (_context.HttpContext.Request.Cookies[Key] == null)
            {
                return false;
            }

            return true;
        }
    }
}

using System.ComponentModel;

namespace ProjetoEmprestimoAspCore.Models
{
    public class Livro
    {
        public int CodLivro { get; set; }

        [DisplayName("XYZ")]
        public string NomeLivro { get; set; }
        public string ImagemLivro { get; set; }
        public int Quantidade { get; set; }
    }
}

namespace ProjetoEmprestimoAspCore.Models
{
    public class Item
    {
        public Guid ItemPedidoID { get; set; }

        public int CodEmp {  get; set; }
        public string CodLivro { get; set; }

        public string NomeLivro { get; set; }
        public string Imagem { get; set; }
        public string Quantidade { get; set; }
    }
}

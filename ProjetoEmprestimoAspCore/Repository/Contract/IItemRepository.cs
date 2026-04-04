using ProjetoEmprestimoAspCore.Models;

namespace ProjetoEmprestimoAspCore.Repository.Contract
{
    public interface IItemRepository
    {
        IEnumerable<Item> ObterTodosItens();
        void Cadastrar(Item item);
        void Atualizar(Item item);
        Item ObterItens(int Id);
        void Excluir(int Id);
    }
}

using ProjetoEmprestimoAspCore.Models;

namespace ProjetoEmprestimoAspCore.Repository.Contract
{
    public interface ICategoriaRepository
    {
        IEnumerable<ICategoriaRepository> ObterTodasCategorias();
    }
}

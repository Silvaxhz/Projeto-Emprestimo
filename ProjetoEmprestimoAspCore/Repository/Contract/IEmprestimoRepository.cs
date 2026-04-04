using ProjetoEmprestimoAspCore.Models;

namespace ProjetoEmprestimoAspCore.Repository.Contract
{
    public interface IEmprestimoRepository
    {
        IEnumerable<Emprestimo> ObterTodosEmprestimos();
        void Cadastrar(Emprestimo emprestimo);
        void Atualizar(Emprestimo emprestimo);
        Emprestimo ObterEmprestimos(int Id);
        void BuscaIdEmp(Emprestimo emprestimo);
        void Excluir(int Id);
    }
}

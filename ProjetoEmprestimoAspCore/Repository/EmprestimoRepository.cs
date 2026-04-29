using MySql.Data.MySqlClient;
using ProjetoEmprestimoAspCore.Models;
using ProjetoEmprestimoAspCore.Repository.Contract;

namespace ProjetoEmprestimoAspCore.Repository
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly string _conexaoMySQL;
        public EmprestimoRepository(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQl");
        }
        public void Atualizar(Emprestimo emprestimo)
        {
            throw new NotImplementedException();
        }

        public void BuscaIdEmp(Emprestimo emprestimo)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlDataReader dr;

                MySqlCommand cmd = new MySqlCommand("select codEmp from tbEmprestimo order by codEmp desc limit 1", conexao);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    emprestimo.CodEmp = dr[0].ToString();
                }
                conexao.Close();
            }   
        }

        public void Cadastrar(Emprestimo emprestimo)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("insert into tbEmprestimo values(default, @DtEmpre, @DtDev, @CodUsu)", conexao);

                cmd.Parameters.Add("@DtEmpre", MySqlDbType.VarChar).Value = emprestimo.DtEmpre;
                cmd.Parameters.Add("DtDev", MySqlDbType.VarChar).Value = emprestimo.DtDev;
                cmd.Parameters.Add("CodUsu", MySqlDbType.VarChar).Value = emprestimo.CodUsu;
                cmd.ExecuteNonQuery();
                conexao.Close();
            }   
        }

        public void Excluir(int Id)
        {
            throw new NotImplementedException();
        }

        public Emprestimo ObterEmprestimos(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Emprestimo> ObterTodosEmprestimos()
        {
            throw new NotImplementedException();
        }
    }
}

using MySql.Data.MySqlClient;
using ProjetoEmprestimoAspCore.Models;
using ProjetoEmprestimoAspCore.Repository.Contract;
using System.Data;

namespace ProjetoEmprestimoAspCore.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly string _conexaoMySQL;
        public IEnumerable<Categoria> ObterTodasCategorias()
        {
            List<Categoria> catList = new List<Categoria>();
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Categoria", conexao);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                conexao.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    catList.Add(
                        new Categoria
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            NomeCategoria = (string)(dr["Nome"]),
                        });
                }
                return catList;
            }
        }

        IEnumerable<ICategoriaRepository> ICategoriaRepository.ObterTodasCategorias()
        {
            throw new NotImplementedException();
        }
    }
}

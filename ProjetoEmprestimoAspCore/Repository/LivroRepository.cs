using System.Data;
using MySql.Data.MySqlClient;
using ProjetoEmprestimoAspCore.Models;
using ProjetoEmprestimoAspCore.Repository.Contract;

namespace ProjetoEmprestimoAspCore.Repository
{
    public class LivroRepository : ILivroRepository
    {
        private readonly string _conexaoMySQL;
        public LivroRepository(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }

        public void Cadastrar(Livro livro)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("Insert into  tbLivro values(default, @NomeLivro, @ImagemLivro)", conexao);

                cmd.Parameters.Add("@NomeLivro", MySqlDbType.VarChar).Value = livro.NomeLivro;
                cmd.Parameters.Add("@ImagemLivro", MySqlDbType.VarChar).Value = livro.ImagemLivro;
                cmd.ExecuteNonQuery();
            
                conexao.Close();
            }

        }
        public Livro ObterLivros(int Id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("select * from tbLivro where CodLivro=@Cod", conexao);
                cmd.Parameters.Add("@Cod", MySqlDbType.VarChar).Value = Id;

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                Livro livro = new Livro();
                dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (dr.Read()) {
                    livro.CodLivro = Convert.ToInt32(dr["CodLivro"]);
                    livro.NomeLivro = (String)(dr["NomeLivro"]);
                    livro.ImagemLivro = (String)(dr["ImagemLivro"]);
                }
                return livro;
            }
        }

        public IEnumerable<Livro> ObterTodosLivros()
        {
            List<Livro> Livrolist = new List<Livro>();
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbLivro", conexao);
                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                sd.Fill(dt);
                conexao.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    Livrolist.Add(
                        new Livro
                        {
                            CodLivro = Convert.ToInt32(dr["CodLivro"]),
                            NomeLivro = (String)(dr["NomeLivro"]),
                            ImagemLivro = (String)(dr["ImagemLivro"]),
                        });
                }
                return Livrolist;
            }
        }

        public void Excluir(int Id)
        {

        }
        public void Atualizar(Livro livro)
        {

        }
    }
}

using System.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace TesteAutomatizado
{
    public class PessoaRepositorio : IPessoaRepositorio
    {
        public Pessoa Inserir(Pessoa pessoa)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["test"].ConnectionString))
            {
                pessoa.Id = conn.ExecuteScalar<int>(@"
                                    insert into pessoa (nome) values (@Nome)
                                    select SCOPE_IDENTITY()
                            ", pessoa);

                return pessoa;
            }
        }

        public void Alterar(Pessoa pessoa)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["test"].ConnectionString))
            {
                conn.Execute("update pessoa set nome = @Nome where id = @Id", pessoa);
            }
        }

        public Pessoa RetornarPorNome(string nome)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["test"].ConnectionString))
            {
                return conn.QueryFirstOrDefault<Pessoa>("select * from pessoa where nome = @nome", new { nome });
            }
        }

        public void Delete(int id)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["test"].ConnectionString))
            {
               conn.Execute("delete pessoa where id = @id", new { id });
            }
        }
    }
}

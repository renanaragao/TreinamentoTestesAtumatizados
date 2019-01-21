using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Transactions;
using Dapper;
using Xunit;

namespace TesteAutomatizado
{
    public class PessoaRepositorioTeste : IDisposable
    {
        private readonly Pessoa _pessoa1;
        private readonly Pessoa _pessoa2;
        private readonly PessoaRepositorio _pessoaRepositorio;
        private readonly SqlConnection _connection;

        public PessoaRepositorioTeste()
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["test"].ConnectionString);

            _pessoaRepositorio = new PessoaRepositorio();
            _pessoa1 = RetornarPessoa1();

            _pessoa2 = RetornarPessoa2();

        }

        private static Pessoa RetornarPessoa2()
        {
            return new Pessoa
            {
                Nome = Guid.NewGuid().ToString()
            };
        }

        private static Pessoa RetornarPessoa1()
        {
            return new Pessoa
            {
                Nome = Guid.NewGuid().ToString()
            };
        }

        [Fact]
        public void Deve_Salvar_Pessoa()
        {
            using (var trans = new TransactionScope())
            {
                var id = _pessoaRepositorio.Inserir(_pessoa1);

                var pessoa = RetornarPessoa(id);

                Assert.Equal(_pessoa1.Nome, pessoa.Nome);
            }
        }
        
        [Fact]
        public void Deve_Alterar_Pessoa()
        {
            using (var trans = new TransactionScope())
            {
                var pessoaInserida1 = _pessoaRepositorio.Inserir(_pessoa1);
                var pessoaInserida2 = _pessoaRepositorio.Inserir(_pessoa2);

                pessoaInserida1.Nome = Guid.NewGuid().ToString();

                _pessoaRepositorio.Alterar(pessoaInserida1);

                var pessoaAlterada1 = RetornarPessoa(pessoaInserida1);
                var pessoaNaoALterado2 = RetornarPessoa(pessoaInserida2);

                Assert.Equal(pessoaInserida1.Nome, pessoaAlterada1.Nome);
                Assert.Equal(pessoaInserida2.Nome, pessoaNaoALterado2.Nome);
            }
        }

        [Fact]
        public void Deve_Retornar_Pessoa_Por_Nome()
        {
            using (var trans = new TransactionScope())
            {
                _pessoaRepositorio.Inserir(_pessoa1);

                var pessoa = _pessoaRepositorio.RetornarPorNome(_pessoa1.Nome);

                Assert.Equal(_pessoa1.Nome, pessoa.Nome);
            }
        }

        [Fact]
        public void Deve_Deletar_Pessoa()
        {
            using (var trans = new TransactionScope())
            {
                var pessoa1 = _pessoaRepositorio.Inserir(_pessoa1);
                var pessoa2 = _pessoaRepositorio.Inserir(_pessoa2);

                _pessoaRepositorio.Delete(pessoa1.Id);

                Assert.Null(RetornarPessoa(pessoa1));
                Assert.NotNull(RetornarPessoa(pessoa2));
            }
        }

        private Pessoa RetornarPessoa(Pessoa pessoaInserida)
        => _connection.QueryFirstOrDefault<Pessoa>("select * from pessoa where id = @Id", pessoaInserida);

        public void Dispose()
        {
            _connection.Close();
            _connection?.Dispose();
        }
    }
}

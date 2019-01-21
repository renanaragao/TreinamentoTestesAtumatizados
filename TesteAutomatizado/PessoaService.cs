using System;

namespace TesteAutomatizado
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepositorio _pessoaRepositorio;

        public PessoaService(IPessoaRepositorio pessoaRepositorio)
        {
            _pessoaRepositorio = pessoaRepositorio;
        }

        public Pessoa Inserir(Pessoa pessoa)
        {
            try
            {
                pessoa.Validar();

                return _pessoaRepositorio.Inserir(pessoa);
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }
    }

    public interface IPessoaService
    {
        Pessoa Inserir(Pessoa pessoa);
    }
}

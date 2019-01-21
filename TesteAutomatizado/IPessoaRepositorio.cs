namespace TesteAutomatizado
{
    public interface IPessoaRepositorio
    {
        Pessoa Inserir(Pessoa pessoa);
        void Alterar(Pessoa pessoa);
        Pessoa RetornarPorNome(string nome);
        void Delete(int id);
    }
}
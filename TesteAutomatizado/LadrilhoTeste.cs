using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using Xunit;

namespace TesteAutomatizado
{
    public class PizzaTeste
    {
        private readonly Pessoa _pessoa;

        public PizzaTeste()
        {
            _pessoa = new Pessoa();
        }

        [Fact]
        public void Deve_Adicionar_Preferencia()
        {
            var preferencia = new preferencia() { Descricao = "queijo", Nota = 5 };

            _pessoa.addPreferencia(preferencia);

            Assert.Contains(_pessoa.Preferencias, x => x.Descricao == preferencia.Descricao &&
                                                         x.Nota == preferencia.Nota);
        }

        [Fact]
        public void Pessoa_Deve_Ter_Preferencia()
        {
            var preferencia = "";

            Assert.NotNull(preferencia);
        }

        public List<Pessoa> retornarPessoasSugeridas()
        {

            var lisPessoas = new List<Pessoa>();

            var objRenato = new Pessoa() { Nome = "Renato", Preferencias = new List<preferencia>() }
            objRenato.Preferencias.Add(new preferencia() { Descricao = "Marguerita", Nota = 4 });


            lisPessoas.Add(objRenato);

            return lisPessoas;


        }


    }


}
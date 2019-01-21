using System;
using System.Collections.Generic;
using AutoFixture;
using Xunit;

namespace TesteAutomatizado
{
    public class PessoaTeste
    {
        private readonly Pessoa _pessoa;
        private readonly Fixture _fixture;

        public PessoaTeste()
        {
            _fixture = new Fixture();

            _pessoa = _fixture.Create<Pessoa>();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("  ")]
        [MemberData(nameof(RetornarNomes))]
        public void Nome_Deve_Ser_Valido(string nome)
        {
            _pessoa.Nome = nome;

            var ex = Assert.Throws<ApplicationException>(() => _pessoa.Validar());

            Assert.Equal("Informe o nome.", ex.Message);
        }

        public static IEnumerable<object[]> RetornarNomes()
        {
            yield return new object[] { "" };
            yield return new object[] { " " };
            yield return new object[] { null };
        }
    }
}

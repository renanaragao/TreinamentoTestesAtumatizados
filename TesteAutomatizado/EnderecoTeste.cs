using System;
using AutoFixture;
using Xunit;

namespace TesteAutomatizado
{
    public class EnderecoTeste
    {
        private readonly Endereco _endereco;
        private readonly Fixture _fixture;

        public EnderecoTeste()
        {
            _fixture = new Fixture();
            _endereco = _fixture.Create<Endereco>();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Deve_Ter_Rua(string rua)
        {
            _endereco.Rua = rua;

            var ex = Assert.Throws<ApplicationException>(() => _endereco.Validar());
            Assert.Equal($"Informe a {nameof(Endereco.Rua)}.", ex.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Deve_Ter_Cep(string cep)
        {
            _endereco.Cep = cep;

            var ex = Assert.Throws<ApplicationException>(() => _endereco.Validar());
            Assert.Equal($"Informe a {nameof(Endereco.Cep)}.", ex.Message);
        }

        [Theory]
        [InlineData("123456789")]
        [InlineData("1234567")]
        public void Cep_Deve_Ter_8_Digitos(string cep)
        {
            _endereco.Cep = cep;

            var ex = Assert.Throws<ApplicationException>(() => _endereco.Validar());
            Assert.Equal($"{nameof(Endereco.Cep)} inválido.", ex.Message);
        }
    }
}

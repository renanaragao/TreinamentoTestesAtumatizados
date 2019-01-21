using System;
using AutoFixture;
using Moq;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Xunit;

namespace TesteAutomatizado
{
    public class PessoaServiceTeste
    {
        private readonly Pessoa _pessoa;
        private readonly Mock<IPessoaRepositorio> _pessoaRepositorioMock;
        private readonly IPessoaRepositorio _pessoaRepositorio;
        private readonly IPessoaService _pessoaService;
        private readonly Fixture _fixture;

        public PessoaServiceTeste()
        {
            _fixture = new Fixture();
            _pessoa = _fixture.Create<Pessoa>();

            _pessoaRepositorio = Substitute.For<IPessoaRepositorio>();
            _pessoaRepositorio.Inserir(Arg.Any<Pessoa>()).Returns(_pessoa);

            _pessoaRepositorioMock = new Mock<IPessoaRepositorio>();
            _pessoaRepositorioMock
                .Setup(x => x.Inserir(It.IsAny<Pessoa>()))
                .Returns(_pessoa);

            _pessoaService = new PessoaService(_pessoaRepositorioMock.Object);
        }

        [Fact]
        public void Deve_Inserir_Pessoa()
        {
            var pessoa = _pessoaService.Inserir(_pessoa);

            Assert.Same(pessoa, _pessoa);

            _pessoaRepositorioMock.Verify(x => x.Inserir(_pessoa));
            //_pessoaRepositorio.Received().Inserir(_pessoa);
        }

        [Fact]
        public void Deve_Validar_Ao_Inserir_Pessoa()
        {
            _pessoa.Nome = "";

            var ex = Assert.Throws<ApplicationException>(() => _pessoaService.Inserir(_pessoa));

            Assert.Equal("Informe o nome.", ex.Message);

            _pessoaRepositorioMock.Verify(x => x.Inserir(It.IsAny<Pessoa>()), Times.Never);
            //_pessoaRepositorio.Received(0).Inserir(Arg.Any<Pessoa>());

        }

        [Fact]
        public void Deve_Tratar_Erro_Ao_Inserir_Pessoa()
        {
            _pessoaRepositorioMock
                .Setup(x => x.Inserir(It.IsAny<Pessoa>()))
                .Throws(new Exception("erro"));

            //_pessoaRepositorio.Inserir(Arg.Any<Pessoa>()).Throws(new Exception());

            var ex = Assert.Throws<ApplicationException>(() => _pessoaService.Inserir(_pessoa));

            Assert.Equal("erro", ex.Message);

        }
    }
}

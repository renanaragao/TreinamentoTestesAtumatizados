using System;
using Xunit;

namespace TesteAutomatizado
{
    public class TrianguloTeste
    {
        [Fact]
        public void Deve_Ser_Um_Triangulo_Isoseles()
        {
            var triagulo = new Triangulo(78, 78, 89);

            Assert.Equal("Isósceles", triagulo.Nome);
        }

        [Fact]
        public void Deve_Ser_Um_Triangulo_Equilatero()
        {
            var triagulo = new Triangulo(78, 78, 78);

            Assert.Equal("Equilátero", triagulo.Nome);
        }

        [Fact]
        public void Deve_Ser_Um_Triangulo_Escaleno()
        {
            var triagulo = new Triangulo(5, 4, 3);

            Assert.Equal("Escaleno", triagulo.Nome);
        }

        [Fact]
        public void Deve_Ser_Um_Triangulo()
        {
            var ex = Assert.Throws<Exception>(() => new Triangulo(100, 10, 10));

            Assert.Equal("Não é um triângulo.", ex.Message);
        }
    }
}

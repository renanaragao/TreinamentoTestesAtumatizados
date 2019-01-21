using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace TesteAutomatizado
{
    public class ExemploTdd
    {
        private readonly IEnumerable<string> _telefones;
        private readonly NumeroRomano _numeroRomano;

        public ExemploTdd()
        {
           _numeroRomano = new NumeroRomano();
        }

        [Fact]
        public void Deve_Converter_1_I()
        {

            Assert.Equal("I", _numeroRomano.Converter(1));
        }

        [Fact]
        public void Deve_Converter_2_II()
        {
            Assert.Equal("II", _numeroRomano.Converter(2));
        }

        [Fact]
        public void Deve_Converter_3_III()
        {
            Assert.Equal("III", _numeroRomano.Converter(3));
        }

        [Fact]
        public void Deve_Converter_4_IV()
        {
            Assert.Equal("IV", _numeroRomano.Converter(4));
        }

        [Fact]
        public void Deve_Converter_5_V()
        {
            Assert.Equal("V", _numeroRomano.Converter(5));
        }
    }

    public class NumeroRomano
    {
        private readonly Dictionary<int, string> _numerosRomanos;

        public NumeroRomano()
        {
            _numerosRomanos = new Dictionary<int, string>
            {
                { 1, "I" },
                { 5, "V" },
                { 10, "X" },
                { 50, "D" },
                { 100, "C" },
                { 500, "L" },
                { 1000, "M" }
            };
        }

        public string Converter(int numero)
        {
            

            if (_numerosRomanos.ContainsKey(numero))
                return _numerosRomanos[numero];

            if (numero > (numero - 1) * 3 && numero < numero + 1)
                return _numerosRomanos
                    .Where(x => x.Key < numero - 1 || x.Key > numero + 1)
                    .OrderBy(x => x.Key)
                    .Aggregate("", (current, next) => current + next);

            return Repetir(_numerosRomanos
                .FirstOrDefault(x => x.Key <= numero)
                .Value, numero);

        }

        private static string Repetir(string value, int numero)
        {
            var novoValor = "";

            for (var i = 0; i < numero; i++)
            {
                novoValor += value;
            }

            return novoValor;
        }
    }
}

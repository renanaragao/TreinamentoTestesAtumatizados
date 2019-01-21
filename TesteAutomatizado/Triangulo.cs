using System;
using System.Collections.Generic;
using System.Linq;

namespace TesteAutomatizado
{
    public class Triangulo
    {
        private readonly IEnumerable<int> _lados;

        public Triangulo(int ladoA, int ladoB, int ladoC)
        {
            LadoA = ladoA;
            LadoB = ladoB;
            LadoC = ladoC;

            _lados = new[] {LadoA, LadoB, LadoC};

            Validar();
        }

        private void Validar()
        {
            var somaDosLadosMenores = _lados
                .OrderBy(x => x)
                .Take(2)
                .Sum();

            if (somaDosLadosMenores > _lados.Max(x => x))
                return;

            throw new Exception("Não é um triângulo.");
        }

        public int LadoA { get; }
        public int LadoB { get; }
        public int LadoC { get; }

        public string Nome
        {
            get
            {
                if (_lados.GroupBy(x => x).Any(x => x.Count() == 2))
                    return "Isósceles";

                if (_lados.GroupBy(x => x).Any(x => x.Count() == 3))
                    return "Equilátero";

                if (_lados.GroupBy(x => x).Count() == 3)
                    return "Escaleno";

                return string.Empty;
            }
        }
    }
}
using System;

namespace TesteAutomatizado
{
    public class Endereco
    {
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Rua))
                throw new ApplicationException($"Informe a {nameof(Rua)}.");

            if (string.IsNullOrWhiteSpace(Cep))
                throw new ApplicationException($"Informe a {nameof(Cep)}.");

            if(Cep.Length != 8)
                throw new ApplicationException($"{nameof(Cep)} inválido.");

        }
    }
}
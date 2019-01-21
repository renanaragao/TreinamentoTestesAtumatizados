using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace TesteAutomatizado
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<preferencia> Preferencias { get; set; }

        public Pessoa()
        {
            Preferencias = new List<preferencia>();
        }

        public void Validar()
        {
            if(string.IsNullOrWhiteSpace(Nome)) throw new ApplicationException("Informe o nome.");
        }


        public void addPreferencia(preferencia preferencia)
        {
            Preferencias.Add(preferencia);

        }
    }

    

    public class preferencia
    {

        public int Nota { get; set; }
        public string Descricao { get; set; }


    }
}
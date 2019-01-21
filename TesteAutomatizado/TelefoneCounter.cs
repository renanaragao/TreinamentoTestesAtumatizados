using System.Collections.Generic;

namespace TesteAutomatizado
{
    public class TelefoneCounter
    {
        private readonly IEnumerable<string> _telefones;

        public TelefoneCounter(IEnumerable<string> telefones)
        {
            _telefones = telefones;
        }
    }
}
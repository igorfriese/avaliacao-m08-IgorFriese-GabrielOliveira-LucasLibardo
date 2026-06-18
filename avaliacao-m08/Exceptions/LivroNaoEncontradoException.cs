using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avaliacao_m08.Exceptions
{
    public class LivroNaoEncontradoException : Exception
    {
        public LivroNaoEncontradoException(string mensagem) : base(mensagem)
        {
        }
    }
}

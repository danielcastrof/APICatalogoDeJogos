using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogoDeJogos.Exceptions
{
    public class GameNCadastradoException : Exception
    {
        public GameNCadastradoException()
            : base("Este jogo ainda não foi cadastrado")
        { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogoDeJogos.Exceptions
{
    public class GameCadastradoException : Exception
    {
        public GameCadastradoException()
            : base("Este jogo já está cadastrado")
        { }
    }
}

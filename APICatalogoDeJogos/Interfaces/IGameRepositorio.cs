using APICatalogoDeJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogoDeJogos.Repositories
{
    public interface IGameRepositorio : IDisposable
    {
        Task<List<Game>> Obter(int page, int qtd);
        Task<Game> Obter(Guid id);
        Task<List<Game>> Obter(string nome, string produtora);
        Task Inserir(Game game);
        Task Atualizar(Game game);
        Task Remover(Guid id);
    }
}

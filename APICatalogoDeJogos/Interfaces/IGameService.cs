using APICatalogoDeJogos.InputModel;
using APICatalogoDeJogos.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogoDeJogos.Services
{
    public interface IGameService : IDisposable
    {
        Task<List<GameViewModel>> Obter(int page, int qtd);
        Task<GameViewModel> Obter(Guid Id);
        Task<GameViewModel> Inserir(GameInputModel Game);
        Task Atualizar(Guid id, GameInputModel Game);
        Task Atualizar(Guid id, double Preco);
        Task Remover(Guid Id);

    }
}

using APICatalogoDeJogos.InputModel;
using APICatalogoDeJogos.Entities;
using APICatalogoDeJogos.Repositories;
using APICatalogoDeJogos.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICatalogoDeJogos.Exceptions;

namespace APICatalogoDeJogos.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepositorio _gameRepositorio;

        public GameService(IGameRepositorio gameRepositorio)
        {
            _gameRepositorio = gameRepositorio;
        }

        public async Task Atualizar(Guid id, GameInputModel game)
        {
            var gameEntity = await _gameRepositorio.Obter(id);

            if (gameEntity == null)
                throw new GameNCadastradoException();

            gameEntity.Nome = game.Nome;
            gameEntity.Produtora = game.Produtora;
            gameEntity.Preco = game.Preco;

            await _gameRepositorio.Atualizar(gameEntity);
        }

        public async Task Atualizar(Guid id, double preco)
        {
            var gameEntity = await _gameRepositorio.Obter(id);

            if (gameEntity == null)
                throw new GameNCadastradoException();

            gameEntity.Preco = preco;

            await _gameRepositorio.Atualizar(gameEntity);
        }

        public void Dispose()
        {
            _gameRepositorio?.Dispose();
        }

        public async Task<GameViewModel> Inserir(GameInputModel game)
        {
            var gameEntity = await _gameRepositorio.Obter(game.Nome, game.Produtora);

            if (gameEntity.Count > 0)
                throw new GameCadastradoException();

            var gameInsert = new Game
            {
                Id = Guid.NewGuid(),
                Nome = game.Nome,
                Produtora = game.Produtora,
                Preco = game.Preco
            };

            await _gameRepositorio.Inserir(gameInsert);

            return new GameViewModel
            {
                Id = gameInsert.Id,
                Nome = game.Nome,
                Produtora = game.Produtora,
                Preco = game.Preco
            };
        }

        public async Task<List<GameViewModel>> Obter(int page, int qtd)
        {
            var games = await _gameRepositorio.Obter(page, qtd);

            return games.Select(game => new GameViewModel
            {
                Id = game.Id,
                Nome = game.Nome,
                Produtora = game.Produtora,
                Preco = game.Preco
            })
                               .ToList();
        }

        public async Task<GameViewModel> Obter(Guid id)
        {
            var game = await _gameRepositorio.Obter(id);

            if (game == null)
                return null;

            return new GameViewModel
            {
                Id = game.Id,
                Nome = game.Nome,
                Produtora = game.Produtora,
                Preco = game.Preco
            };
        }


        public async Task Remover(Guid id)
        {
            var game = await _gameRepositorio.Obter(id);

            if (game == null)
                throw new GameNCadastradoException();

            await _gameRepositorio.Remover(id);
        }
    }
}

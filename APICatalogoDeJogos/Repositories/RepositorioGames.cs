using APICatalogoDeJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogoDeJogos.Repositories
{
    public class RepositorioGames : IGameRepositorio
    {
        private static Dictionary<Guid, Game> games = new Dictionary<Guid, Game>()
        {
            {Guid.Parse("232916a9-d19f-4171-a7a0-c1cddfef6f2e"), new Game{ Id = Guid.Parse("232916a9-d19f-4171-a7a0-c1cddfef6f2e"), Nome = "PES 2022", Produtora = "KONAMI", Preco = 250} },
            {Guid.Parse("7ccefbb2-e259-4ed1-9ab9-15e16cef0d35"), new Game{ Id = Guid.Parse("7ccefbb2-e259-4ed1-9ab9-15e16cef0d35"), Nome = "Crash Bandicoot", Produtora = "Activision", Preco = 100} },
            {Guid.Parse("9882d399-e2c5-4a07-96d5-0bd7768988f6"), new Game{ Id = Guid.Parse("9882d399-e2c5-4a07-96d5-0bd7768988f6"), Nome = "The King Of Fighters XV", Produtora = "SNK", Preco = 100} },
            {Guid.Parse("5a2f24b4-3ff8-4461-b4a5-94225dec4d32"), new Game{ Id = Guid.Parse("5a2f24b4-3ff8-4461-b4a5-94225dec4d32"), Nome = "Resident Evil 6", Produtora = "CAPCOM", Preco = 200} },
            {Guid.Parse("055a70cb-8df5-43b6-b621-4072937ee1e3"), new Game{ Id = Guid.Parse("055a70cb-8df5-43b6-b621-4072937ee1e3"), Nome = "God of War IV", Produtora = "SIE Santa Monica Studio", Preco = 385} }
        };

        public Task Atualizar(Game game)
        {
            games[game.Id] = game;
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            
        }

        public Task Inserir(Game game)
        {
            games.Add(game.Id, game);
            return Task.CompletedTask;
        }

        public Task<List<Game>> Obter(int page, int qtd)
        {
            return Task.FromResult(games.Values.Skip((page - 1) * qtd).Take(qtd).ToList());
        }

        public Task<Game> Obter(Guid id)
        {
            if (!games.ContainsKey(id))
                return Task.FromResult<Game>(null);

            return Task.FromResult(games[id]);
        }

        public Task<List<Game>> Obter(string nome, string produtora)
        {
            return Task.FromResult(games.Values.Where(game => game.Nome.Equals(nome) && game.Produtora.Equals(produtora)).ToList());
        }

        public Task Remover(Guid id)
        {
            games.Remove(id);
            return Task.CompletedTask;
        }
    }
}

using APICatalogoDeJogos.Exceptions;
using APICatalogoDeJogos.InputModel;
using APICatalogoDeJogos.Services;
using APICatalogoDeJogos.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogoDeJogos.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GameViewModel>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 20)] int quantidade = 5)
        {
            var games = await _gameService.Obter(pagina, quantidade);

            if (games.Count() == 0)
                return NoContent();

            return Ok(games);
        }

        [HttpGet("{idGame:guid}")]
        public async Task<ActionResult<GameViewModel>> Obter([FromRoute] Guid idGame) 
        {
            var game = await _gameService.Obter(idGame);

            if (game == null)
                return NoContent();

            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult<GameViewModel>> InserirJogo([FromBody] GameInputModel gameInputModel)
        {
            try
            {
                var game = await _gameService.Inserir(gameInputModel);

                return Ok(game);
            }
            catch (GameCadastradoException ex)
            {
                return UnprocessableEntity("Já existe um jogo com este nome para esta produtora");
            }
        }

        [HttpPut]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idGame, [FromBody] GameInputModel gameInputModel)
        {
            try
            {
                await _gameService.Atualizar(idGame, gameInputModel);

                return Ok();
            }
            catch (GameNCadastradoException ex)
            {
                return NotFound("Jogo Inexistente");
            }
        }

        [HttpPatch("{idGame:guid}/preco/{preco:double}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idGame, [FromRoute] double preco)
        {
            try
            {
                await _gameService.Atualizar(idGame, preco);

                return Ok();
            }
            catch (GameNCadastradoException ex)
            {
                return NotFound("Jogo Inexistente");
            }
        }

        [HttpDelete ("{idGame:guid}")]
        public async Task<ActionResult> DeletarJogo([FromRoute] Guid idGame)
        {
            try
            {
                await _gameService.Remover(idGame);
                return Ok();
            }
            catch (GameNCadastradoException ex)
            {
                return NotFound("Jogo Inexistente");
            }
        }

    }
}

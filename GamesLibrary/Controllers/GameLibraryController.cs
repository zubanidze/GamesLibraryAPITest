using AutoMapper;
using GamesLibrary.GameLibraryService.Abstractions;
using GamesLibrary.Infrastructure.Db.Entities;
using GamesLibrary.Infrastructure.Db.Repositories.Abstractions;
using GamesLibrary.Infrastructure.Dto;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GamesLibrary.Controllers
{
    [Route("gamelibrary")]
    public class GameLibraryController : ControllerBase
    {
        private readonly ILogger<GameLibraryController> _logger;
        private readonly IGameRepo _gameRepo;
        private readonly IGameLibraryService _gameLibraryService;
        private readonly IMapper _mapper;
        public GameLibraryController(ILogger<GameLibraryController> logger, IGameRepo gameRepo,IGameLibraryService gameLibraryService, IMapper mapper)
        {
            _logger = logger;
            _gameRepo = gameRepo;
            _gameLibraryService = gameLibraryService;
            _mapper = mapper;
        }
        /// <summary>
        /// Создание 
        /// </summary>
        /// <param name="gameModel">Модель игры</param>
        /// <param name="traceId">Идентификатор запроса</param>
        /// <returns></returns>
        [SwaggerOperation("Добавить игру в библиотеку")]
        [HttpPost("games")]
        public async Task<ActionResult<GameModel>> AddGame([FromBody]GameModel gameModel, [FromQuery] string traceId)
        {
            #region validation
            if ((await _gameRepo.FindIncludingBy(x=>x.Id==gameModel.Id)).Count()>0)
            {
                _logger.LogError($"trace [{traceId}] : Игра с данным Id{gameModel.Id} уже существует");
                return BadRequest($"Игра с данным Id{gameModel.Id} уже существует");
            }
            #endregion
            var gameToAdd = _mapper.Map<Game>(gameModel);
            var result = _mapper.Map<GameModel>(await _gameLibraryService.AddGame(gameToAdd,gameModel.Genres));
            result.Genres = gameModel.Genres;
            return Ok(_mapper.Map<GameModel>(result));
        }
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="gameId">Id удаляемой игры</param>
        /// <param name="traceId">Идентификатор запроса</param>
        /// <returns></returns>
        [SwaggerOperation("Удалить игру из библиотеки")]
        [HttpDelete("games/{gameId:Guid}")]
        public async Task<ActionResult> DeleteGame(Guid gameId, [FromQuery] string traceId)
        {
            #region validation
            if ((await _gameRepo.GetFirstOrDefault(x => x.Id == gameId))==null)
            {
                _logger.LogError($"trace [{traceId}] : Игра с данным Id{gameId} не существует");
                return BadRequest($" Игра с данным Id{gameId} не существует");
            }
            #endregion
            await _gameLibraryService.DeleteGame(gameId);
            return Ok("Игра успешно удалена");
        }
        /// <summary>
        /// Обновление
        /// </summary>
        /// <param name="gameId">Id обновляемой игры</param>
        /// /// <param name="gameModel">Модель игры</param>
        /// <param name="traceId">Идентификатор запроса</param>
        /// <returns></returns>
        [SwaggerOperation("Обновить игру в библиотеке")]
        [HttpPut("games/{gameId:Guid}")]
        public async Task<ActionResult> UpdateGame(Guid gameId, [FromBody] GameModel gameModel, [FromQuery] string traceId)
        {
            #region validation
            if ((await _gameRepo.GetFirstOrDefault(x => x.Id == gameId)) == null)
            {
                _logger.LogError($"trace [{traceId}] : Игра с данным Id{gameId} не существует");
                return BadRequest($" Игра с данным Id{gameId} не существует");
            }
            #endregion
            var gameToUpdate = _mapper.Map<Game>(gameModel);
            await _gameLibraryService.UpdateGame(gameToUpdate,gameModel.Genres);
            return Ok("Игра успешно удалена");
        }
        /// <summary>
        /// Получение списка игр по жанру
        /// </summary>
        /// <param name="genreName">Название жанра</param>
        /// <param name="traceId">Идентификатор запроса</param>
        /// <returns></returns>
        [SwaggerOperation("Получить список игр из библиотеки")]
        [HttpGet("games")]
        public async Task<ActionResult<List<GameModel>>> GetGames([FromQuery] string genreName, [FromQuery] string traceId)
        {
            #region validation
            var gamesOfGenre = await _gameRepo.GetGamesOfGenre(genreName);
            if (gamesOfGenre == null)
            {
                _logger.LogError($"trace [{traceId}] : Жанра genre {genreName} не существует");
                return BadRequest($"Игр с жанром {genreName} не существует");
            }
            #endregion
            List<GameModel> result = new List<GameModel>();
            var games = await _gameLibraryService.GetGamesByGenre(genreName);
            foreach(var game in games)
            {
                var outputModel = _mapper.Map<GameModel>(game);
                outputModel.Genres = (await _gameRepo.GetAllGenresOfGame(game.Id)).Select(x=>x.Name).ToList();
                result.Add(outputModel);
            }
            return Ok(result);
        }

    }
}

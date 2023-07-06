using GamesLibrary.GameLibraryService.Abstractions;
using GamesLibrary.Infrastructure.Db.Entities;
using GamesLibrary.Infrastructure.Db.Repositories.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GamesLibrary.GameLibraryService
{
    public class GameLibraryService : IGameLibraryService
    {
        private readonly ILogger<GameLibraryService> _logger;
        private readonly IGameRepo _gameRepo;
        public GameLibraryService(ILogger<GameLibraryService> logger, IGameRepo gameRepo)
        {
            _logger = logger;
            _gameRepo = gameRepo;
        }

        public async Task<Game> AddGame(Game game,List<string> genres)
        {
            _gameRepo.Add(game);
            foreach(var genre in genres)
            {
               await _gameRepo.AddGameGenreLink(genre, game.Id);
            }
            await _gameRepo.CommitAsync();
            return game;
        }

        public async Task DeleteGame(Guid gameId)
        {
            _gameRepo.Delete(gameId);
            await _gameRepo.DeleteGameGenreLinks(gameId);
            await _gameRepo.CommitAsync();

        }

        public async Task<List<Game>> GetGamesByGenre(string genreName)
        {
            List<Genre> gameGenreLinks = await _gameRepo.GetGamesOfGenre(genreName);
            List<Game> gamesOfGenre = new List<Game>();
            foreach (var link in gameGenreLinks)
            {
                gamesOfGenre.Add(await _gameRepo.GetFirstOrDefault(x => x.Id == link.GameId));
            }
            return gamesOfGenre;
        }

        public async Task<Game> UpdateGame(Game game, List<string> genres)
        {
            _gameRepo.Update(game);
            foreach (var genre in genres)
            {
                if( await _gameRepo.GetGenreOfGame(game.Id,genre) ==null)
                {
                    await _gameRepo.AddGameGenreLink(genre, game.Id);
                }
                else
                {
                    await _gameRepo.DeleteGameGenreLink(game.Id, genre);
                }
            }
            await _gameRepo.CommitAsync();
            return game;

        }
    }
}

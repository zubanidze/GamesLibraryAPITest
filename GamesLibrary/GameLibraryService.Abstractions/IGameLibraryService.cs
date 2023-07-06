using GamesLibrary.Infrastructure.Db.Entities;

namespace GamesLibrary.GameLibraryService.Abstractions
{
    public interface IGameLibraryService
    {
        Task<Game> AddGame(Game game, List<string> genres);
        Task DeleteGame(Guid gameId);
        Task<Game> UpdateGame(Game game, List<string> genres);
        Task<List<Game>> GetGamesByGenre(string genreName);


    }
}

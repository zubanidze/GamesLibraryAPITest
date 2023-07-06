using GamesLibrary.Infrastructure.Db.Entities;

namespace GamesLibrary.Infrastructure.Db.Repositories.Abstractions
{
    public interface IGameRepo: IBaseRepository<Game, Guid>
    {
        Task AddGameGenreLink(string name, Guid GameId);
        Task DeleteGameGenreLinks(Guid GameId);
        Task DeleteGameGenreLink(Guid GameId, string name);
        Task<Genre> GetGenreOfGame(Guid GameId,string name);
        Task<List<Genre>> GetAllGenresOfGame(Guid GameId);
        Task<List<Genre>> GetGamesOfGenre(string name);
    }
}

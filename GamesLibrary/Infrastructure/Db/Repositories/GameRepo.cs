using GamesLibrary.Infrastructure.Db.Entities;
using GamesLibrary.Infrastructure.Db.Repositories.Abstractions;
using System.Linq.Expressions;

namespace GamesLibrary.Infrastructure.Db.Repositories
{
    public class GameRepo : IGameRepo
    {
        public void Add(Game entity)
        {
            throw new NotImplementedException();
        }

        public Task AddGameGenreLink(string name, Guid GameId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Game>> All()
        {
            throw new NotImplementedException();
        }

        public Task CommitAsync()
        {
            throw new NotImplementedException();
        }

        public Task<long> Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteGameGenreLink(Guid GameId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteGameGenreLink(Guid GameId, string name)
        {
            throw new NotImplementedException();
        }

        public Task DeleteGameGenreLinks(Guid GameId)
        {
            throw new NotImplementedException();
        }

        public void DeleteWhere(Expression<Func<Game, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Game>> FindIncludingBy(Expression<Func<Game, bool>> predicate, params Expression<Func<Game, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<List<Genre>> GetAllGenresOfGame(Guid GameId)
        {
            throw new NotImplementedException();
        }

        public Task<Game> GetFirstOrDefault(Expression<Func<Game, bool>> predicate, params Expression<Func<Game, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<List<Game>> GetGamesOfGenre(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Genre> GetGenreOfGame(Guid GameId, string name)
        {
            throw new NotImplementedException();
        }

        public Task<Game> GetSingle(Guid id, IEnumerable<string> include = null)
        {
            throw new NotImplementedException();
        }

        public void PartialUpdate(Game entity, IEnumerable<string> properties)
        {
            throw new NotImplementedException();
        }

        public void Update(Game entity)
        {
            throw new NotImplementedException();
        }

        Task<List<Genre>> IGameRepo.GetGamesOfGenre(string name)
        {
            throw new NotImplementedException();
        }
    }
}

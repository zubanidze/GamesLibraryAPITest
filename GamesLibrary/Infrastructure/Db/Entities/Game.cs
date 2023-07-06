using GamesLibrary.Infrastructure.Db.Repositories.Abstractions;

namespace GamesLibrary.Infrastructure.Db.Entities
{
    public class Game:EntityBase<Guid>
    {
        public string Name { get; set; }
        public string Developer { get; set; }
        
    }
}

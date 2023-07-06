using GamesLibrary.Infrastructure.Db.Repositories.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamesLibrary.Infrastructure.Db.Entities
{
    public class Genre:EntityBase<Guid>
    {
        [ForeignKey("Game")]
        public Guid GameId { get; set; }
        public string Name { get; set; }
        
    }
}

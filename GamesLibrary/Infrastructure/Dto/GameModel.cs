namespace GamesLibrary.Infrastructure.Dto
{
    public class GameModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Developer { get; set; }
        public List<string> Genres { get; set; }
    }
}

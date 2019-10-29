namespace Wired.Models.Entities
{
    public class GameKey
    {
        public int Id { get; set; }
        public bool IsUsed { get; set; }
        public string Key { get; set; }
        public Game Game { get; set; }

        public int GameId { get; set; }
    }
}

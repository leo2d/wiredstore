using System.Collections.Generic;

namespace Wired.Models.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public string Producer { get; set; }
        public string ReleaseYear { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public List<Image> Images { get; set; } = new List<Image>();
        public List<GameKey> Keys { get; set; }

        public int GenreId { get; set; }

    }
}

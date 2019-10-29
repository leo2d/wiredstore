using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wired.Models.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Game> Games { get; set; }
    }
}

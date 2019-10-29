using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wired.Models.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}

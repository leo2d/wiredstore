using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wired.Models.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public int Amount { get; set; }

        public Game Game { get; set; }
        public int GameID { get; set; }

        public Cart Cart { get; set; }
        public int CartID { get; set; }

    }
}

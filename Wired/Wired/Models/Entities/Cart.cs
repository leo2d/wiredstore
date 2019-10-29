using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Wired.Models.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public List<CartItem> Games { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}

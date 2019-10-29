using System;
using System.Collections.Generic;

namespace Wired.Models.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Total { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<Game> Items { get; set; }
        public int CreditCardId { get; set; }
        public CreditCard CreditCard { get; set; }

        public int PromoCodeId { get; set; }
        public PromoCode PromoCode { get; set; }
    }
}

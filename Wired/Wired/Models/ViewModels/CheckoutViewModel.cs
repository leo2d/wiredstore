using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wired.Models.Entities;

namespace Wired.Models.ViewModels
{
    public class CheckoutViewModel
    {
        public string Type { get; set; }
        public string Number { get; set; }
        public string SecurityCode { get; set; }
        public string CardHolder { get; set; }
        public string ExpirationDate { get; set; }

        public string Coupon { get; set; }

        public Cart Cart { get; set; }
    }
}

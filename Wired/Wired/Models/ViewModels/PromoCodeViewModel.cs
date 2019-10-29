using System.ComponentModel.DataAnnotations;

namespace Wired.Models.ViewModels
{
    public class PromoCodeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Cupom é obrigatório"), MaxLength(75)]
        public string Coupon { get; set; }

        [Required(ErrorMessage = "Quantidade é obrigatório")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "Desconto é obrigatório")]
        public int DiscountPercent { get; set; }

        public int UsedAmount { get; set; }
    }
}

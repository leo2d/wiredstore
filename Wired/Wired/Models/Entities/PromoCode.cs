namespace Wired.Models.Entities
{
    public class PromoCode
    {
        public int Id { get; set; }
        public string Coupon { get; set; }
        public int Amount { get; set; }
        public int UsedAmount { get; set; }
        public int DiscountPercent { get; set; }
    }
}

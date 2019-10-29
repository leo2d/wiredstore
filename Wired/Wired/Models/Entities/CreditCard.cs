namespace Wired.Models.Entities
{
    public class CreditCard
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Number { get; set; }
        public string SecurityCode { get; set; }
        public string CardHolder { get; set; }
        public string ExpirationDate { get; set; }
    }
}

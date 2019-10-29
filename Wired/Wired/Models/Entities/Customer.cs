using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wired.Models.Entities
{
    public class Customer : User
    {
        public string Cpf { get; set; }
      //  public Cart Cart { get; set; } = null;
    }
}

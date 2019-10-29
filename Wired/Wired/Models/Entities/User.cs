using Microsoft.AspNetCore.Identity;
using Wired.Models.Contracts;

namespace Wired.Models.Entities
{
    public class User : IUser//IdentityUser, IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public virtual string Password { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wired.Models.Contracts
{
    public interface IUser
    {
        Int32 Id { get; }
        [Required]
        string Email { get; set; }
        [Required]
        string Password { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wired.Models.Contracts
{
    public interface IUserViewModel
    {
        string Email { get; set; }
        string Password { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Wired.Models.Contracts;

namespace Wired.Models.ViewModels
{
    public class LoginViewModel : IUserViewModel
    {
        [Required(ErrorMessage = "O campo Email é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        [MinLength(3, ErrorMessage = "A senha tem de ter no minimo 3 caracteres")]
        public string Password { get; set; }
    }
}

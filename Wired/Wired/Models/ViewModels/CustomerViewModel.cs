using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Wired.Models.Contracts;

namespace Wired.Models.ViewModels
{
    public class CustomerViewModel : IUserViewModel
    {
        [Required(ErrorMessage ="Campo nome é Obrigatório")]
        [MaxLength(120,ErrorMessage = "Nome pode tem ter no máximo 120 letras")]
        [MinLength(8,ErrorMessage ="Nome tem de ter no minimo 8 letras")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo CPF é Obrigatório")]
        [MaxLength(11, ErrorMessage = "CPF só pode ter 11 digitos")]
        [MinLength(11, ErrorMessage = "CPF só pode ter 11 digitos")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório")]
        [MinLength(3, ErrorMessage = "A senha tem de ter no minimo 3 caracteres")]
        public string Password { get; set; }
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wired.Models.Entities;

namespace Wired.Models.ViewModels
{
    public class RegisterGameViewModel
    {
        public GameViewModel Game { get; set; }
        public List <IFormFile> Files { get; set; }
    }
}

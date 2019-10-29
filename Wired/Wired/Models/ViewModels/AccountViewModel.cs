using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wired.Models.ViewModels
{
    public class AccountViewModel
    {
        public LoginViewModel Login { get; set; }
        public CustomerViewModel Register { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class LoginViewModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool isRememberMe{ get; set; }
    }
}

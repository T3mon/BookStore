using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class User : IdentityUser<Guid>
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public IList<Book> PurchasedBooks { get; set; }

    }
}

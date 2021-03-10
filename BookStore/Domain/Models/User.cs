using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class User : IdentityUser<Guid>
    {
        public IList<Book> PurchasedBooks { get; set; }

    }
}

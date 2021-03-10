using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Context
{
    public class StoreContext : IdentityDbContext<User, Role, Guid>
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Book> Books { get; set; }
    }
}

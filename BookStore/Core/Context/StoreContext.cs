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
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        public DbSet<Autor> Autors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Category>().HasData(new Category[] {
        //        new Category
        //        {
        //            Id = 1,
        //            CategoryName = "Drama"
        //        },
        //    });


        //    modelBuilder.Entity<Autor>().HasData(new Autor[]{
        //        new Autor
        //            {
        //                Id = 1,
        //                FullName = "Leo Tolstoy",
        //                DateOfBirth = new DateTime(1828,9,9),
        //                DateOfDeath = new DateTime(1910,10,20),
        //                Description = "Leo Tolstoy wrote two of the great novels of the nineteenth century, War and Peace and Anna Karenina."
        //            },
        //        new Autor
        //            {
        //                Id = 2,
        //                FullName = "Mark Twen",
        //                DateOfBirth = new DateTime(1835,10,30),
        //                DateOfDeath = new DateTime(1910,5,21),
        //                Description = "Mark Twain is an American writer, comedian, journalist and public figure. His work covers many genres - humor, satire, philosophical fiction, journalism and others, and in all these genres he invariably takes the position of a humanist and democrat."
        //            },
        //    });

        //    modelBuilder.Entity<Book>().HasData(
        //        new Book[]
        //        {
        //            new Book
        //            {
        //                Id = 1,
        //                BookAutorId = 1,
        //                PageCount = 1225,
        //                Name = "War and peace",
        //                Description= "Leo Tolstoy’s sweeping epic of human life in all its imperfection and grandeur is universally accepted as one of the greatest novels of all time.",
        //                Price = 15,
        //                Text = "Book text",
        //                LogoUrl = "https://www.penguin.co.uk/content/dam/prh/books/301/301515/9780141959801.jpg.transform/PRHDesktopWide_small/image.jpg"
        //            },
        //            new Book
        //            {
        //                Id = 2,
        //                BookAutorId = 1,
        //                PageCount = 864,
        //                Name = "Anna Karenina",
        //                Description= "In 1872 the mistress of a neighbouring landowner threw herself under a train at a station near Tolstoy's home.",
        //                Price = 5,
        //                Text = "Book text",
        //                LogoUrl = "https://m.media-amazon.com/images/I/414RQsmvcxL._SY346_.jpg"
        //            },
        //            new Book
        //            {
        //                Id = 3,
        //                BookAutorId = 2,
        //                PageCount = 366,
        //                Name = "Adventures Of Huckleberry Finn",
        //                Description= "Adventures of Huckleberry Finnis a novel by Mark Twain. Commonly named among the Great American Novels.The novel's preeminence derives from its wonderfully.",
        //                Price = 7,
        //                Text = "Book text",
        //                LogoUrl = "https://m.media-amazon.com/images/I/61cPb04ZS7L._AC_UY218_.jpg"
        //            },
        //        });
        //}

    }
}

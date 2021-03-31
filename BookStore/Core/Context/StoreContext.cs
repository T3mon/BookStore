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
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        public DbSet<Autor> Autors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    CategoryName = "Drama"
                });
            modelBuilder.Entity<Autor>().HasData(
                new Autor[]
                {
                    new Autor
                    {
                        Id = 1,
                        FullName = "Leo Tolstoy",
                        DateOfBirth = new DateTime(1828,9,9),
                        DateOfDeath = new DateTime(1910,10,20),
                        Description = "Leo Tolstoy (1828-1910) wrote two of the great novels of the nineteenth century, War and Peace and Anna Karenina."
                    }
                });

            modelBuilder.Entity<Book>().HasData(
                new Book[]
                {
                    new Book
                    {
                        Id = 1,
                        Name = "War and peace",
                        Description= "Leo Tolstoy’s sweeping epic of human life in all its imperfection and grandeur is universally accepted as one of the greatest novels of all time.",
                        Price = 15,
                        Text = "Book text",
                        LogoUrl = "https://www.penguin.co.uk/content/dam/prh/books/301/301515/9780141959801.jpg.transform/PRHDesktopWide_small/image.jpg"
                    }
                });

            //new Category[]
            //{
            //    new Category() {Id = 1, CategoryName="Drama", Books= new Book[]{
            //        new Book(){ BookAutor= new Autor{ FullName="Leo Tolstoy"}, Name="War and peace", Price = 20,
            //            Description = "Leo Tolstoy’s sweeping epic of human life in all its imperfection and grandeur is universally accepted as one of the greatest novels of all time. ",
            //        Text="BookText",LogoUrl="https://www.penguin.co.uk/content/dam/prh/books/301/301515/9780141959801.jpg.transform/PRHDesktopWide_small/image.jpg"},new Book(){ BookAutor= new Autor{ FullName="Leo Tolstoy"}, Name="War and peace", Price = 20,
            //            Description = "Leo Tolstoy’s sweeping epic of human life in all its imperfection and grandeur is universally accepted as one of the greatest novels of all time. ",
            //        Text="BookText",LogoUrl="https://www.penguin.co.uk/content/dam/prh/books/301/301515/9780141959801.jpg.transform/PRHDesktopWide_small/image.jpg"},new Book(){ BookAutor= new Autor{ FullName="Leo Tolstoy"}, Name="War and peace", Price = 20,
            //            Description = "Leo Tolstoy’s sweeping epic of human life in all its imperfection and grandeur is universally accepted as one of the greatest novels of all time. ",
            //        Text="BookText",LogoUrl="https://www.penguin.co.uk/content/dam/prh/books/301/301515/9780141959801.jpg.transform/PRHDesktopWide_small/image.jpg"},
            //    } },
            //    new Category() {Id = 2, CategoryName="Horror", Books= new Book[]{
            //        new Book(){ BookAutor= new Autor{ FullName="Stephen King"}, Name="Pet Sematary", Price = 14,
            //            Description = "The new home seemed to be perfect for the life of the family of Dr. Louis Creed. In need of renovation, old, awkward, but so cozy. " +
            //            "It's nice to settle down and settle down here. Children will grow up here and learn about the world. And as if the rolling hills and meadows of Maine's terrain could carry them far from the dangers of industrial Chicago ",
            //        Text="BookText",LogoUrl="https://www.britishbook.ua/upload/iblock/df9/kniga_pet_sematary.jpg"},new Book(){ BookAutor= new Autor{ FullName="Leo Tolstoy"}, Name="Pet Sematary 2", Price = 30,
            //            Description = "The new home seemed to be perfect for the life of the family of Dr. Louis Creed. In need of renovation, old, awkward, but so cozy. It's nice to settle down " +
            //            "and settle down here. Children will grow up here and learn about the world. And as if the rolling hills and meadows of Maine's terrain could carry them far from the dangers of industrial Chicago ",
            //        Text="BookText",LogoUrl="https://www.britishbook.ua/upload/iblock/df9/kniga_pet_sematary.jpg"},new Book(){ BookAutor= new Autor{ FullName="Leo Tolstoy"}, Name="Pet Sematary 2", Price = 40,
            //            Description = "Leo Tolstoy’s sweeping epic of human life in all its imperfection and grandeur is universally accepted as one of the greatest novels of all time. ",
            //        Text="BookText",LogoUrl="https://www.britishbook.ua/upload/iblock/df9/kniga_pet_sematary.jpg"},
            //    } }
            //});
        }
    }
}

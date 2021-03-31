using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class Book
    {
        public int Id { get; set; }
        public int PageCount { get; set; }
        public int OverallRating { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public string LogoUrl { get; set; }
        public int Price { get; set; }
        public int? BookAutorId { get; set; }      // внешний ключ
        [ForeignKey("BookAutorId")]
        public Autor BookAutor{ get; set; }
        public IList<Review> Reviews { get; set; }
        public int? CategoryId { get; set; }      // внешний ключ
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public Book()
        {
            BookAutor = new Autor();
            Reviews = new List<Review>();
            Category = new Category();
        }
    }
}

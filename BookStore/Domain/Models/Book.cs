using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public string LogoUrl { get; set; }
        public int Price{ get; set; }
        public Autor BookAutor{ get; set; }
        public IList<Reviews> Reviews { get; set; }
        public Book()
        {
            BookAutor = new Autor();
            Reviews = new List<Reviews>();
        }
    }
}

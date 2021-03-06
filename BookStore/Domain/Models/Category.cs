using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int? ParentCategoryId { get; set; }
        [ForeignKey("ParentCategoryId")]
        public Category ParentCategory { get; set; }
        public ICollection<Category> Subcategories { get; set; }
        public ICollection<Book> Books { get; set; }
        public Category()
        {
            Books = new List<Book>();
            Subcategories = new List<Category>();
        }
    }
}

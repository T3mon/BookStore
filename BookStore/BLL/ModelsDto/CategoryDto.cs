using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ModelsDto
{
    public class CategoryDto
    {
        public string CategoryName { get; set; }
        public int CategoryCount { get; set; }
        public Category ParentCategory { get; set; }
        public ICollection<Category> Subcategories { get; set; } 
        public IList<Book> Books { get; set; } 
    }
}

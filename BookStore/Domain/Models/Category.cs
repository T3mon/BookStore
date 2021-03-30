using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public int parentCategoryId { get; set; }
        public string CategoryName { get; set; }
        public IList<Category> Categories { get; set; } = new List<Category>();
        public IList<Book> Books { get; set; } = new List<Book>();

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ModelsDto
{
    public class BookDto
    {
        public int PageCount { get; set; }
        public int OverallRating { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public string LogoUrl { get; set; }
        public int Price { get; set; }
        public AutorDto BookAutor { get; set; }
        public IList<ReviewDto> Reviews { get; set; }
        public CategoryDto Category { get; set; }
        public BookDto()
        {
            Reviews = new List<ReviewDto>();
        }
    }
}

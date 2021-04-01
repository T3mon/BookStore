using BLL.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.Interfaces
{
    public interface IBookService
    {
        public IList<BookDto> GetBooks();
        public IList<BookDto> GetBooks(int? categotyId);
        public IList<CategoryDto> GetCategories();


    }
}

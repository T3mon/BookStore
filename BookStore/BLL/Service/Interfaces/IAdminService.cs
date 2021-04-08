using BLL.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.Interfaces
{
    public interface IAdminService
    {
        Task CreateBook();
        Task<BookDto> GetBook();

        Task CreateCategory();
        Task<CategoryDto> GetCategoryWithBooks();
        
        Task CreateAuthor();
        Task<CategoryDto> GetAuthorWithBooks();



    }
}

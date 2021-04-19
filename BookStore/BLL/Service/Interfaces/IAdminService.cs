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
        Task CreateBook(BookDto bookDto);
        Task<BookDto> GetBookById();
        Task<List<BookDto>> GetBooks();

        Task CreateCategory(CategoryDto categoryDto);
        Task<CategoryDto> GetCategoryWithBooks();
        Task<List<CategoryDto>> GetAllCategorys();

        Task CreateAuthor(AutorDto autorDto);
        Task<CategoryDto> GetAuthorWithBooks();
        Task<CategoryDto> GetAllAuthors();



    }
}

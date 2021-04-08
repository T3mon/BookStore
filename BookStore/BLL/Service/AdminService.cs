using BLL.ModelsDto;
using BLL.Service.Interfaces;
using Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class AdminService : IAdminService
    {
        private readonly StoreContext _storeContext;
        public AdminService(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        //HTPP POSTS

        public Task CreateBook()
        {
            throw new NotImplementedException();
        }

        public Task CreateAuthor()
        {
            throw new NotImplementedException();
        }

        public Task CreateCategory()
        {
            throw new NotImplementedException();
        }


        //HTPP GETS
        public Task<CategoryDto> GetAuthorWithBooks()
        {
            throw new NotImplementedException();
        }

        public Task<BookDto> GetBook()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDto> GetCategoryWithBooks()
        {
            throw new NotImplementedException();
        }
    }
}

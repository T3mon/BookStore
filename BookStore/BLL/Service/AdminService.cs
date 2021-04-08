using AutoMapper;
using BLL.ModelsDto;
using BLL.Service.Interfaces;
using Core.Context;
using Domain.Models;
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
        private readonly IMapper _mapper;

        public AdminService(StoreContext storeContext, IMapper mapper)
        {
            _storeContext = storeContext;
            _mapper = mapper;
        }


        //HTPP POSTS
        public async Task CreateCategory(CategoryDto categoryDto)
        {
            _storeContext.Categories.Add(_mapper.Map<CategoryDto, Category>(categoryDto));
            await _storeContext.SaveChangesAsync();
        }
        public async Task CreateBook(BookDto bookDto)
        {
            _storeContext.Books.Add(_mapper.Map<BookDto, Book>(bookDto));
            await _storeContext.SaveChangesAsync();
        }
        public async Task CreateAuthor(AutorDto autorDto)
        {
            _storeContext.Autors.Add(_mapper.Map<AutorDto, Autor>(autorDto));
            await _storeContext.SaveChangesAsync();
        }

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

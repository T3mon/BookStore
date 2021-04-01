using AutoMapper;
using BLL.ModelsDto;
using BLL.Service.Interfaces;
using Core.Context;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BookService : IBookService
    {
        private readonly StoreContext _storeContext;
        private readonly IMapper _mapper;

        public BookService(StoreContext storeContext, IMapper mapper)
        {
            _storeContext = storeContext;
            _mapper = mapper;
        }

        public IList<BookDto> GetBooks()
        {
            var Books = _storeContext.Books.ToList();
            return _mapper.Map<List<BookDto>>(Books);
        }

        public IList<CategoryDto> GetCategories()
        {
            var Categoties = _storeContext.Categories.ToList();
            return _mapper.Map<List<CategoryDto>>(Categoties);
        }
    }
}

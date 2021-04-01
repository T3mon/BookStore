using AutoMapper;
using BLL.ModelsDto;
using BLL.Service.Interfaces;
using Core.Context;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            return _mapper.Map<List<BookDto>>(_storeContext.Books.ToList());
        }

        public IList<BookDto> GetBooks(int? categotyId)
        {
            return _mapper.Map<List<BookDto>>(_storeContext.Books.Where(x => x.CategoryId == categotyId).ToList());

        }

        public IList<CategoryDto> GetCategories()
        {
            //This maps categories and gets books count
            List<CategoryDto> result = new List<CategoryDto>();
            foreach (var item in _storeContext.Categories.Include(c => c.Books).ToList())
            {
                CategoryDto category = _mapper.Map<CategoryDto>(item);
                category.CategoryCount = item.Books.ToList().Count;
                result.Add(category);
            }

            return result;
        }
    }
}

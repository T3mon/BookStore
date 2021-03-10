using Core.Context;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BookService
    {
        private readonly StoreContext _storeContext;
        public BookService(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public IList<Book> GetBooks()
        {
            return _storeContext.Books.ToList();
        }
    }
}

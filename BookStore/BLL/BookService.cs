using Core.Context;
using Domain.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static async Task SendMail()
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("artemermolaev0@gmail.com", "Artem");
            var subject = "Now you buy books!!!";
            var to = new EmailAddress("artemermolaev0@gmail.com", "Artem");
            var plainTextContent = "and will definetly be smarter";
            var htmlContent = "<strong>and will definetly be smarter</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}

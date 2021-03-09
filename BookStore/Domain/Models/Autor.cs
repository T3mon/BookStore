using System.Collections.Generic;

namespace Domain.Models
{
    public class Autor
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public IList<Book> Books{ get; set; }
    }
}
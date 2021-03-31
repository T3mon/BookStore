using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Autor
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfDeath { get; set; }

        public int? BookAutorId { get; set; }
        public IList<Book> Books{ get; set; } = new List<Book>();
    }
}
using System;
using System.Collections.Generic;

namespace BLL.ModelsDto
{
    public class AutorDto
    {

        public string FullName { get; set; }
        public string Description { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfDeath { get; set; }
        public IList<BookDto> Books { get; set; } = new List<BookDto>();
    }
}
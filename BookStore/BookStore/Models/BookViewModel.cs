using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.UI.Models
{
    public class BookViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public string LogoUrl { get; set; }
        public int Price { get; set; }
        public string Autor { get; set; }
    }
}

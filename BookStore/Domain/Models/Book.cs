﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price{ get; set; }
        public int Rating{ get; set; }
        public Autor BookAutor{ get; set; }
    }
}
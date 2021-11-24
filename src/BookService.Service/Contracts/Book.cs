using System;
using System.Collections.Generic;
using System.Text;

namespace BookService.Service.Contracts
{
    public abstract class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
    }
}

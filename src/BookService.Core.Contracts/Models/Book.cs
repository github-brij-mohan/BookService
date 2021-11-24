using System;
using System.Collections.Generic;
using System.Text;

namespace BookService.Core.Contracts.Models
{
    public class Book
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
    }
}

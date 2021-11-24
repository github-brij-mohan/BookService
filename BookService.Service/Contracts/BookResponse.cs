using System;
using System.Collections.Generic;
using System.Text;

namespace BookService.Service.Contracts
{
    public class BookResponse: Book
    {
        public string Id { get; set; }
    }
}

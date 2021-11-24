using BookService.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Models = BookService.Core.Contracts.Models;

namespace BookService.Service.Translators
{
    internal static class BookTranslator
    {
        internal static Models.Book ToModel(this BookRequest bookRequest, string id = null)
        {
            return new Models.Book
            {
                Id = id,
                Name = bookRequest.Name,
                Author = bookRequest.Author,
                Price = bookRequest.Price
            };
        }

        internal static BookResponse ToResponse(this Models.Book book)
        {
            return new BookResponse
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                Price = book.Price
            };
        }
    }
}

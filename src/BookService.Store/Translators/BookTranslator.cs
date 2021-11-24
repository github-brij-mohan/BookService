using System;
using System.Collections.Generic;
using System.Text;
using Models = BookService.Core.Contracts.Models;
using Dto = BookService.Store.Entities;

namespace BookService.Store.Translators
{
    internal static class BookTranslator
    {
        internal static Models.Book ToModel(this Dto.Book book)
        {
            return new Models.Book
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                Price = book.Price
            };
        }

        internal static Dto.Book ToDto(this Models.Book book)
        {
            return new Dto.Book
            {
                Id = book.Id ?? Guid.NewGuid().ToString(),
                Name = book.Name,
                Author = book.Author,
                Price = book.Price
            };
        }
    }
}

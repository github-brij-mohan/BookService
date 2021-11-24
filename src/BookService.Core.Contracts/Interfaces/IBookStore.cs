using BookService.Core.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookService.Core.Contracts.Interfaces
{
    public interface IBookStore
    {
        Task<Book> CreateAsync(Book book);
        Task<List<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(string bookId);
        Task<Book> UpdateAsync(Book book);
        Task<Book> DeleteAsync(Book book);
    }
}

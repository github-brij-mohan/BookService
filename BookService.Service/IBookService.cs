using BookService.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookService.Service
{
    public interface IBookService
    {
        Task<BookResponse> CreateAsync(BookRequest book);
        Task<List<BookResponse>> GetAllAsync();
        Task<BookResponse> GetByIdAsync(string bookId);
        Task<BookResponse> UpdateAsync(BookRequest book, string bookId);
        Task<BookResponse> DeleteAsync(string bookId);
    }
}

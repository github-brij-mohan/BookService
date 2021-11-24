using BookService.Core.Contracts.Interfaces;
using BookService.Core.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookService.Core
{
    public class BookManager : IBookManager
    {
        private readonly IBookStore _bookStore;
        public BookManager(IBookStore bookStore)
        {
            _bookStore = bookStore;
        }

        public async Task<Book> CreateAsync(Book book)
        {
            var result = await _bookStore.CreateAsync(book);
            return result;
        }

        public async Task<Book> DeleteAsync(string bookId)
        {
            var book = await _bookStore.GetByIdAsync(bookId);
            if(book == null)
            {
                throw new Exception($"Book with Id: {bookId} does not exists");
            }

            return await _bookStore.DeleteAsync(book);
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _bookStore.GetAllAsync();
        }

        public async Task<Book> GetByIdAsync(string bookId)
        {
            var book = await _bookStore.GetByIdAsync(bookId);
            if(book == null)
            {
                throw new Exception($"Book with Id: {bookId} does not exists");
            }

            return book;
        }

        public async Task<Book> UpdateAsync(Book book)
        {
            return await _bookStore.UpdateAsync(book);
        }
    }
}

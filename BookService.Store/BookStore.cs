using BookService.Core.Contracts.Interfaces;
using BookService.Core.Contracts.Models;
using BookService.Store.Translators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.Store
{
    public class BookStore : IBookStore
    {
        public async Task<Book> CreateAsync(Book book)
        {
            using (var db = new DataContext())
            {
                var dto = book.ToDto();
                var entityEntry = await db.AddAsync(dto);
                await db.SaveChangesAsync();
                return entityEntry.Entity.ToModel();
            }
        }

        public async Task<Book> DeleteAsync(Book book)
        {
            using (var db = new DataContext())
            {
                var dto = book.ToDto(); 
                var deletedEntry = db.Remove(dto);
                await db.SaveChangesAsync();
                return deletedEntry.Entity.ToModel();
            }
        }

        public Task<List<Book>> GetAllAsync()
        {
            using (var db = new DataContext())
            {
                return Task.FromResult(db.Books.Select(x => x.ToModel()).ToList());
            }
        }

        public async Task<Book> GetByIdAsync(string bookId)
        {
            using (var db = new DataContext())
            {
                var book = await db.FindAsync<Entities.Book>(bookId);
                return book?.ToModel();
            }
        }

        public async Task<Book> UpdateAsync(Book book)
        {
            using (var db = new DataContext())
            {
                var dto = book.ToDto();
                var updatedEntry = db.Update(dto);
                await db.SaveChangesAsync();
                return updatedEntry.Entity.ToModel();
            }
        }
    }
}

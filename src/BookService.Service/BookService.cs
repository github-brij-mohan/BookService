using BookService.Core.Contracts.Interfaces;
using BookService.Service.Contracts;
using BookService.Service.Translators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService.Service
{
    public class BookService : IBookService
    {
        private readonly IBookManager _bookManager;
        private readonly IValidator<BookRequest> _validator;
        public BookService(IBookManager bookManager, IValidator<BookRequest> validator)
        {
            _bookManager = bookManager;
            _validator = validator;
        }

        public async Task<BookResponse> CreateAsync(BookRequest bookRequest)
        {
            var validationResult = await _validator.ValidateAsync(bookRequest);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var result = await _bookManager.CreateAsync(bookRequest.ToModel());
            return result.ToResponse();
        }

        public async Task<BookResponse> DeleteAsync(string bookId)
        {
            if (string.IsNullOrWhiteSpace(bookId))
            {
                throw new Exception("book id is required to delete a book from database");
            }

            var result = await _bookManager.DeleteAsync(bookId);
            return result.ToResponse();
        }

        public async Task<List<BookResponse>> GetAllAsync()
        {
            var result = await _bookManager.GetAllAsync();
            return result?.Select(x => x.ToResponse())?.ToList();
        }

        public async Task<BookResponse> GetByIdAsync(string bookId)
        {
            if (string.IsNullOrWhiteSpace(bookId))
            {
                throw new Exception("book id is required to get a book from database");
            }

            var result = await _bookManager.GetByIdAsync(bookId);
            return result.ToResponse();
        }

        public async Task<BookResponse> UpdateAsync(BookRequest bookRequest, string bookId)
        {
            if (string.IsNullOrWhiteSpace(bookId))
            {
                throw new Exception("book id is required to update a book in database");
            }

            var validationResult = await _validator.ValidateAsync(bookRequest);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var result = await _bookManager.UpdateAsync(bookRequest.ToModel(bookId));
            return result.ToResponse();
        }
    }
}

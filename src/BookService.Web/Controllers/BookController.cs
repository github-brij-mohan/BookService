using BookService.Service;
using BookService.Service.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestBookService.Controllers
{
    [ApiController]
    [Route("api/v1.0/books")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(BookRequest book)
        {
            var result = await _bookService.CreateAsync(book);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _bookService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("{bookId}")]
        public async Task<IActionResult> GetByIdAsync(string bookId)
        {
            var result = await _bookService.GetByIdAsync(bookId);
            return Ok(result);
        }

        [HttpPut]
        [Route("{bookId}")]
        public async Task<IActionResult> UpdateAsync(BookRequest book, string bookId)
        {
            var result = await _bookService.UpdateAsync(book, bookId);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{bookId}")]
        public async Task<IActionResult> DeleteAsync(string bookId)
        {
            var result = await _bookService.DeleteAsync(bookId);
            return Ok(result);
        }
    }
}

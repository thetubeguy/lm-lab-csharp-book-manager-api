﻿using Microsoft.AspNetCore.Mvc;
using BookManagerApi.Models;
using BookManagerApi.Services;

namespace BookManagerApi.Controllers
{
    [Route("api/v1/book")]
    [ApiController]
    public class BookManagerController : ControllerBase
    {
        private readonly IBookManagementService _bookManagementService;
        private readonly IGenericManagementService<Book> _genericManagementServiceBook;
       

        public BookManagerController(IBookManagementService bookManagementService, IGenericManagementService<Book> genericManagementServiceBook)
        {
            _bookManagementService = bookManagementService;
            _genericManagementServiceBook = genericManagementServiceBook;
            
        }

        // GET: api/v1/book
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            return _bookManagementService.GetAllBooks();
        }

        // GET: api/v1/book/5
        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(long id)
        {
            Book? book = _bookManagementService.FindBookById(id);
            if (book == null)
                return NotFound();
            else
                return book;
        }

        // DELETE: api/v1/book/5
        [HttpDelete("{id}")]
        public ActionResult<string> DeleteBookById(long id)
        {
            if(_bookManagementService.DeleteBook(id))
                return $"Book with Id:{id} deleted";
            else

                return NotFound();
        }

        // PUT: api/v1/book/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult UpdateBookById(long id, Book book)
        {
            _bookManagementService.Update(id, book);
            return NoContent();
        }

        // POST: api/v1/book
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Book> AddBook(Book book)
        {
            if(_genericManagementServiceBook.Create(book)) //
                return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
            else
                return ValidationProblem(detail: $"Id {book.Id} already exists", statusCode: 400); 
        }
    }
}

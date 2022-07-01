using BookManagerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagerApi.Services
{
	public class BookManagementService : IBookManagementService
	{
        private readonly BookContext _context;

        public BookManagementService(BookContext context)
        {
            _context = context;
        }


        public List<Book> GetAllBooks()
        {        
            List<Book> _books = _context.Books.ToList();
            return _books;
        }



        public Book Update(long id, Book book)
        {
            var existingBookFound = FindBookById(id);

            existingBookFound.Title = book.Title;
            existingBookFound.Description = book.Description;
            existingBookFound.Genre = book.Genre;

            _context.SaveChanges();
            return book;
        }

        public Book? FindBookById(long id)
        {
            var book = _context.Books.Find(id);
            return book;
        }

        public bool DeleteBook(long id) 
        {
            var book = FindBookById(id);

            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
                return true;
            }
            else return false;
        }

 
    }
}


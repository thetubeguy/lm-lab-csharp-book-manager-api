using BookManagerApi.Models;

namespace BookManagerApi.Services
{
    public interface IAuthorManagerService
    {
        List<Author> GetAllBooks();
        bool Create(Book book);
        Book Update(long id, Book book);
        Book? FindBookById(long id);
        bool BookExists(long id);
        bool DeleteBook(long id);
    }
}

using System;
using BookManagerApi.Models;

namespace BookManagerApi.Services
{
	public interface IBookManagementService
	{
        List<Book> GetAllBooks();
        Book Update(long id, Book book);
        Book FindBookById(long id);
        bool DeleteBook(long id);
    }
}

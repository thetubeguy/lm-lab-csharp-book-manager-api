using BookManagerApi.Models;

namespace BookManagerApi.Services
    {
        public interface IAuthorManagementService
        {
            List<Author> GetAllAuthors();
            Author Update(long id, Author Author);
            Author FindAuthorById(long id);
            bool DeleteAuthor(long id);
        }
    }



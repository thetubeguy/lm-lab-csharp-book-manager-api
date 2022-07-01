using BookManagerApi.Models;
namespace BookManagerApi.Services
{
  
    public class AuthorManagementService : IAuthorManagementService
    {
        private readonly BookContext _context;

        public AuthorManagementService(BookContext context)
        {
            _context = context;
        }


        public List<Author> GetAllAuthors()
        {
            List<Author> _authors = _context.Authors.ToList();
            return _authors;
        }



        public Author Update(long id, Author author)
        {
            var existingAuthorFound = FindAuthorById(id);

            existingAuthorFound.Id = author.Id;
            existingAuthorFound.Name = author.Name;
            existingAuthorFound.About = author.About;

            _context.SaveChanges();
            return author;
        }

        public Author? FindAuthorById(long id)
        {
            var author = _context.Authors.Find(id);
            return author;
        }

        public bool DeleteAuthor(long id)
        {
            var author = FindAuthorById(id);

            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
                return true;
            }
            else return false;
        }


    }
    
}

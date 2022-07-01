using Microsoft.AspNetCore.Mvc;
using BookManagerApi.Models;
using BookManagerApi.Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookManagerApi.Controllers
{
    [Route("api/v1/author")]
    [ApiController]
    public class AuthorManagerController : ControllerBase
    {
        private readonly IAuthorManagementService _authorManagementService;
        private readonly IGenericManagementService<Author> _genericManagementServiceauthor;


        public AuthorManagerController(IAuthorManagementService authorManagementService, IGenericManagementService<Author> genericManagementServiceauthor)
        {
            _authorManagementService = authorManagementService;
            _genericManagementServiceauthor = genericManagementServiceauthor;

        }

        // GET: api/v1/author
        [HttpGet]
        public ActionResult<IEnumerable<Author>> Getauthors()
        {
            return _authorManagementService.GetAllAuthors();
        }

        // GET: api/v1/author/5
        [HttpGet("{id}")]
        public ActionResult<Author> GetauthorById(long id)
        {
            Author? author = _authorManagementService.FindAuthorById(id);
            if (author == null)
                return NotFound();
            else
                return author;
        }

        // DELETE: api/v1/author/5
        [HttpDelete("{id}")]
        public ActionResult<string> DeleteauthorById(long id)
        {
            if (_authorManagementService.DeleteAuthor(id))
                return $"author with Id:{id} deleted";
            else

                return NotFound();
        }

        // PUT: api/v1/author/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult UpdateauthorById(long id, Author author)
        {
            _authorManagementService.Update(id, author);
            return NoContent();
        }

        // POST: api/v1/author
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Author> Addauthor(Author author)
        {
            if (_genericManagementServiceauthor.Create(author)) //
                return CreatedAtAction(nameof(GetauthorById), new { id = author.Id }, author);
            else
                return ValidationProblem(detail: $"Id {author.Id} already exists", statusCode: 400);
        }
    }
}


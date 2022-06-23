using Halle.App.ViewModels;
using Halle.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Halle.App.Controllers
{
    [Route("api/authors")]
    public class AuthorsController : MainController
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(
            IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IEnumerable<AuthorViewModel>> GetAuthors() =>
            await _authorService.GetAuthors();

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AuthorViewModel>> GetAuthor(Guid authorId)
        {
            var author = await _authorService.GetAuthorBooksById(authorId);

            if (author == null) return NotFound();

            return author;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAuthor(AuthorViewModel author)
        {
            if (!ModelState.IsValid) return BadRequest(); 

            var result = await _authorService.CreateAuthor(author);

            if (result) return Ok(result);

            return BadRequest();

        }
           

    }
}

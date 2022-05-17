using Microsoft.AspNetCore.Mvc;

namespace Halle.App.Controllers
{
    [Route("api/books")]
    public class BooksController : MainController
    {
        [HttpGet]
        public async Task<IEnumerable<int>> GetAll() { }

        [HttpGet("{id:guid}")]
        public async Task<IEnumerable<int>> GetById(Guid id) { }

    }
}

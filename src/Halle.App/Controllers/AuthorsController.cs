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



    }
}

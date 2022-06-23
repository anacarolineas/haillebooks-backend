using Halle.Application.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Halle.App.Controllers
{
    [Route("api/tags")]
    public class TagController : MainController
    {
        private readonly ITagService _tagService;

        public TagController()
        {

        }
    }
}

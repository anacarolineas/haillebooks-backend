using Halle.Application.Interfaces;
using Halle.Application.ViewModels.Tag;
using Microsoft.AspNetCore.Mvc;

namespace Halle.App.Controllers
{
    [Route("api/tags")]
    public class TagController : MainController
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService) =>
            _tagService = tagService;

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TagViewModel>> GetTag(Guid id)
        {
            var result = await _tagService.GetTag(id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpGet("search/{name:string}")]
        public async Task<ActionResult<IEnumerable<TagViewModel>>> SearchTag(string name) =>
            Ok(await _tagService.SearchTag(name));


        [HttpPost]
        public async Task<ActionResult> CreateTag(TagViewModel tag)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _tagService.CreateTag(tag);

            return CreatedAtAction("", "");
        }
 
    }
}

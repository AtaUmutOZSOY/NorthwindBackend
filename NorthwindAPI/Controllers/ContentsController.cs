using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NorthwindAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentsController : ControllerBase
    {
        IContentService _contentService;
        public ContentsController(IContentService contentService)
        {
            _contentService = contentService;
        }

        [HttpPost("AddContent")]
        public IActionResult AddContent(Content content)
        {
            var result = _contentService.Add(content);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpDelete("DeleteContent")]
        public IActionResult DeleteContent(Content content)
        {
            var result = _contentService.Delete(content);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result.Message);
        }
        [HttpGet("GetAll")]
        public IActionResult GetAllContent()
        {
            var result = _contentService.GetAll();
            if (result.Data != null)
            {
                return Ok(result);
            }
            return null;
        }
    }
}

using Labb_2_Blog.Core.Interface;
using Labb_2_Blog.Data.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb_2_Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(AddCommentDTO dto)
        {
            var ok = await _commentService.AddCommentAsync(dto);

            if (!ok)
            {
                return BadRequest("Could not add comment");

            }
            else
            {
                return Ok("Comment added");
            }
        }
    }
}

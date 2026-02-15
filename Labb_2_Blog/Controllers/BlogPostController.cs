using Labb_2_Blog.Core.Interface;
using Labb_2_Blog.Data.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb_2_Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostService _blogPostService;

        public BlogPostController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await _blogPostService.GetBlogPostsAsync();
            return Ok(posts);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetPostById(int id)
        {
            var post = await _blogPostService.GetBlogPostByIdAsync(id);
            if (post == null)
            {
                return NotFound("Could not find the post");
            }

            return Ok(post);
        }

        [HttpPost]

        public async Task<IActionResult> AddBlogPost(AddPostDTO dtp)
        {
            var ok = await _blogPostService.AddBlogPostAsync(dtp);

            if (!ok)
            {
                return BadRequest("The post could not be created");
            }

            return Ok();
        }


        [HttpPut("{postId}")]

        public async Task<IActionResult> UpdateBlogPost(int postId, UpdatePostDTO dto, int updaterId)
        {
            var post = await _blogPostService.GetBlogPostByIdAsync(postId);

            if (post == null)
            {
                return BadRequest("The post could not be found");
            }

            if (post.AuthorId != updaterId)
            {
                return BadRequest("You do not have permition to update this post");
            }

            var ok = await _blogPostService.UpdateBlogPostAsync(postId, dto, updaterId);

            if (!ok)
            {
                return BadRequest("Something went wrong, nothing was updated");
            }

            return NoContent();
        }


        [HttpDelete("{postId}")]

        public async Task<IActionResult> DeleteBlogPost(int postId, int deleterId)
        {
            var post = await _blogPostService.GetBlogPostByIdAsync(postId);

            if (post == null)
            {
                return BadRequest("Could not find the post");
            }

            if (post.AuthorId != deleterId)
            {
                return BadRequest("Yoo do not have permition do delete this post");
            }

            var ok = await _blogPostService.DeletePostAsync(postId, deleterId);

            if (!ok)
            {
                return BadRequest("Something went wrong. Nothing was deleted");
            }

            return NoContent();
        }

        [HttpGet("category/{categoryId}")]

        public async Task<IActionResult> SearchPostsByCategory(int categoryId)
        {
            var posts = await _blogPostService.SearchByCategoryAsync(categoryId);
            return Ok(posts);
        }

        [HttpGet("searchTerm")]

        public async Task<IActionResult> SearchByTitle(string title)
        {
            var posts = await _blogPostService.SearchByTitleAsync(title);
            return Ok(posts);
        }
    }
}

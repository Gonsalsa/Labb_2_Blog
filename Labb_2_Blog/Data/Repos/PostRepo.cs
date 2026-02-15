using Labb_2_Blog.Context;
using Labb_2_Blog.Data.Enteties;
using Labb_2_Blog.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Labb_2_Blog.Data.Repos
{
    public class PostRepo : IPostRepo
    {
        private readonly AppDbContext _context;

        public PostRepo(AppDbContext context)
        {
            _context = context;
        }


        public async Task AddPostAsync(BlogPost blogPost)
        {
            _context.BlogPosts.Add(blogPost);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeletePostAsync(int id)
        {
            var blogpost = await _context.BlogPosts.SingleOrDefaultAsync(p => p.BlogPostId == id);

            if (blogpost == null)
            {
                return false;
            }

            _context.BlogPosts.Remove(blogpost);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<BlogPost>> GetAllPostAsync()
        {
            return await _context.BlogPosts.ToListAsync();
        }

        public Task<List<BlogPost>> GetPostByCategoryAsync(int categoryId)
        {
            return _context.BlogPosts.Where(p => p.CategoryId == categoryId).ToListAsync();
        }

        public async Task<BlogPost?> GetPostByIdAsync(int id)
        {
            return await _context.BlogPosts.SingleOrDefaultAsync(p => p.BlogPostId == id);
        }

        public async Task<List<BlogPost>> GetPostByTitleAsync(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                return new List<BlogPost>();
            }

            return await _context.BlogPosts.Where(p => p.BlogPostTitle.Contains(title)).ToListAsync();
        }

        public async Task UpdatePostAsync(BlogPost blogPost)
        {
            var originalPost = _context.BlogPosts.SingleOrDefault(p => p.BlogPostId == blogPost.BlogPostId);

            if (originalPost == null) return;


            _context.Entry(originalPost).CurrentValues.SetValues(blogPost);
            await _context.SaveChangesAsync();

        }
    }
}

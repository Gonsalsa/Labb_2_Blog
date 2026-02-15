using Labb_2_Blog.Context;
using Labb_2_Blog.Data.Enteties;
using Labb_2_Blog.Data.Interfaces;

namespace Labb_2_Blog.Data.Repos
{
    public class CommentRepo : ICommentRepo
    {
        private readonly AppDbContext _context;

        public CommentRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddCommentAsync(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }
    }
}

using Labb_2_Blog.Core.Interface;
using Labb_2_Blog.Data.DTO;
using Labb_2_Blog.Data.Enteties;
using Labb_2_Blog.Data.Interfaces;

namespace Labb_2_Blog.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepo _commentRepo;
        private readonly IPostRepo _postRepo;

        public CommentService(ICommentRepo commentRepo, IPostRepo postRepo)
        {
            _commentRepo = commentRepo;
            _postRepo = postRepo;
        }

        public async Task<bool> AddCommentAsync(AddCommentDTO dto)
        {
            if (dto == null)
            {
                return false;
            }

            var post = await _postRepo.GetPostByIdAsync(dto.BlogPostId);

            if (post == null)
            {
                return false;
            }

            if (post.AuthorId == dto.CommentAuthorId)
            {
                return false;
            }

            var comment = new Comment
            {
                CommentContent = dto.CommentContent,
                PostId = dto.BlogPostId,
                UserId = dto.CommentAuthorId
            };

            await _commentRepo.AddCommentAsync(comment);
            return true;

        }
    }
}

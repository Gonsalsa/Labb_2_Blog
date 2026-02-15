using Labb_2_Blog.Data.DTO;

namespace Labb_2_Blog.Core.Interface
{
    public interface ICommentService
    {
        Task<bool> AddCommentAsync(AddCommentDTO dto, int userID);
    }
}

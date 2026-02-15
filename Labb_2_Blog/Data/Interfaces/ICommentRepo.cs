using Labb_2_Blog.Data.Enteties;

namespace Labb_2_Blog.Data.Interfaces
{
    public interface ICommentRepo
    {
        Task AddCommentAsync(Comment comment);
    }
}

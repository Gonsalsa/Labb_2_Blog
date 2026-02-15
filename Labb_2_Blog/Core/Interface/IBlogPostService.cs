using Labb_2_Blog.Data.DTO;
using Labb_2_Blog.Data.Enteties;

namespace Labb_2_Blog.Core.Interface
{
    public interface IBlogPostService
    {
        //C - Create
        Task<bool> AddBlogPostAsync(AddPostDTO dto, int userID);

        //R - Read
        Task<List<BlogPost>> GetBlogPostsAsync();
        Task<BlogPost?> GetBlogPostByIdAsync(int id);
        Task<List<BlogPost>> SearchByCategoryAsync(int CatId);
        Task<List<BlogPost>> SearchByTitleAsync(string title);

        //U - Update
        Task<bool> UpdateBlogPostAsync(int blogPostId, UpdatePostDTO dto, int updatingUserId);

        //D - Delete
        Task<bool> DeletePostAsync(int blogPostId, int deleterId);
    }
}

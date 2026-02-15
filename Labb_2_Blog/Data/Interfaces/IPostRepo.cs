using Labb_2_Blog.Data.Enteties;

namespace Labb_2_Blog.Data.Interfaces
{
    public interface IPostRepo
    {
        // C - Create 
        Task AddPostAsync(BlogPost blogPost);

        //R - Read
        Task<List<BlogPost>> GetAllPostAsync();
        Task<BlogPost?> GetPostByIdAsync(int id);
        Task<List<BlogPost>> GetPostByCategoryAsync(int categoryId);
        Task<List<BlogPost>> GetPostByTitleAsync(string title);

        //U - Update
        Task UpdatePostAsync(BlogPost blogPost);

        //D - Delete
        Task<bool> DeletePostAsync(int id);
    }
}

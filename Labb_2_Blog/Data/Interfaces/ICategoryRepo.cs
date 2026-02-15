using Labb_2_Blog.Data.Enteties;

namespace Labb_2_Blog.Data.Interfaces
{
    public interface ICategoryRepo
    {
        //vad som ska göras i databasen

        Task<List<Category>> GetAllCategoriesAsync();
        Task<Category?> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(Category category);
    }
}

using Labb_2_Blog.Data.Enteties;

namespace Labb_2_Blog.Core.Interface
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategoriesAsync();
        Task<Category?> GetCategoryByIdAsync(int id);
        Task<bool> AddCategoryAsync(Category category);
    }
}

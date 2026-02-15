using Labb_2_Blog.Data.Enteties;

namespace Labb_2_Blog.Data.Interfaces
{
    public interface IUserRepo
    {
        //C- Create
        Task AddUserAsync(User user);

        //R- Read
        Task<List<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByUserNameAsync(string username);
        Task<User?> GetUserByEmailAsync(string email);
        Task<bool> doUserExists(string username, string email);

        //U- Update
        Task UpdateUserAsync(User user);

        //D- Delete
        Task<bool> DeleteUserAsync(int id);
    }
}

using Labb_2_Blog.Data.DTO;
using Labb_2_Blog.Data.Enteties;

namespace Labb_2_Blog.Core.Interface
{
    public interface IUserService
    {
        //C- Create
        Task<bool> RegisterNewUserAsync(RegisterUserDTO dto);

        //R- read
        Task<List<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<int?> LoginUserAsync(string userName, string password);

        //U- Update
        Task<bool> UpdateUserAsync(int userId, UpdateUserDTO dto);

        //D- Delete
        Task<bool> DeleteUserAsync(int userId);
    }
}

using Labb_2_Blog.Core.Interface;
using Labb_2_Blog.Data.DTO;
using Labb_2_Blog.Data.Enteties;
using Labb_2_Blog.Data.Interfaces;

namespace Labb_2_Blog.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }


        public async Task<bool> DeleteUserAsync(int userId)
        {
            var user = await _userRepo.GetUserByIdAsync(userId);

            if (user == null)
            {
                return false;
            }

            await _userRepo.DeleteUserAsync(userId);
            return true;

        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userRepo.GetAllUsersAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _userRepo.GetUserByIdAsync(id);
        }

        public async Task<int?> LoginUserAsync(string userName, string password)
        {
            var user = await _userRepo.GetUserByUserNameAsync(userName);

            if (user == null)
            {
                return null;
            }

            if (user.Password != password)
            {
                return null;
            }

            return user.UserId;
        }

        public async Task<bool> RegisterNewUserAsync(RegisterUserDTO dto)
        {
            if (dto == null)
            {
                return false;
            }

            var exists = await _userRepo.doUserExists(dto.UserName, dto.Email);

            if (exists)
            {
                return false;
            }

            var user = new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                Password = dto.Password
            };

            await _userRepo.AddUserAsync(user);
            return true;

        }

        public async Task<bool> UpdateUserAsync(int userId, UpdateUserDTO dto)
        {
            var user = _userRepo.GetUserByIdAsync(userId);

            if (user == null)
            {
                return false;
            }

            if (!string.IsNullOrEmpty(dto.UserName))
            {
                user.Result.UserName = dto.UserName;
            }

            if (!string.IsNullOrEmpty(dto.Email))
            {
                user.Result.Email = dto.Email;
            }

            if (!string.IsNullOrEmpty(dto.Password))
            {
                user.Result.Password = dto.Password;
            }

            await _userRepo.UpdateUserAsync(user.Result);
            return true;
        }
    }
}

using Labb_2_Blog.Context;
using Labb_2_Blog.Data.Enteties;
using Labb_2_Blog.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Labb_2_Blog.Data.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext _context;

        public UserRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.UserId == id);
            if (user == null)
            {
                return false;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> doUserExists(string username, string email)
        {
            return await _context.Users.AnyAsync(u => u.UserName == username || u.Email == email);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public Task<User?> GetUserByEmailAsync(string email)
        {
            return _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public Task<User?> GetUserByIdAsync(int id)
        {
            return _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
        }

        public Task<User?> GetUserByUserNameAsync(string username)
        {
            return _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }

        public async Task UpdateUserAsync(User user)
        {
            var originalUser = await _context.Users.SingleOrDefaultAsync(u => u.UserId == user.UserId);
            if (originalUser == null)
            {
                return;
            }

            _context.Entry(originalUser).CurrentValues.SetValues(user);
            await _context.SaveChangesAsync();
        }
    }
}

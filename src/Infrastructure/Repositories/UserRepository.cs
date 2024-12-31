using Domain.UserAggregate;
using Infrastructure;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbConfig _dbConfig;
        public UserRepository(DbConfig dbConfig)
        {
            _dbConfig = dbConfig;
        }
        public async Task<User> AddUser(User user)
        {
            await _dbConfig.Users.AddAsync(user);
            await _dbConfig.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _dbConfig.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetUserById(Guid Id)
        {
            return await _dbConfig.Users.FirstOrDefaultAsync(u => u.Id == Id);
        }

        public async Task<User> UpdateUser(User user)
        {
            _dbConfig.Users.Update(user);
            await _dbConfig.SaveChangesAsync();
            return user;
        }
    }
}
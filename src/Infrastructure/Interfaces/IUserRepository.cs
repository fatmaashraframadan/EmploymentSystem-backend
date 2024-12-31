using Domain.UserAggregate;

namespace Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserById(Guid Id);
        Task<User> GetUserByEmail(string email);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
    }
}
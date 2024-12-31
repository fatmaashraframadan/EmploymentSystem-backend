using Domain.UserAggregate;
using Infrastructure.Interfaces;

namespace EmploymentSystem_backend.src.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<User> GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserById(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
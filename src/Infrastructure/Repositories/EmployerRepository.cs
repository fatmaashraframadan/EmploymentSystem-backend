using Domain.UserAggregate;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories
{
    public class EmployerRepository : IEmployerRepository
    {
        public Task AddEmployerAsync(Employer employer)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEmployerAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employer>> GetAllEmployersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Employer> GetEmployerByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEmployerAsync(Employer employer)
        {
            throw new NotImplementedException();
        }
    }
}
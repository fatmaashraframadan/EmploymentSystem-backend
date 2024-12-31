using Domain.UserAggregate;

namespace EmploymentSystem.Infrastructure.Interfaces
{
    public interface IEmployerRepository
    {
        Task<Employer> GetEmployerByIdAsync(Guid id);
        Task<IEnumerable<Employer>> GetAllEmployersAsync();
        Task AddEmployerAsync(Employer employer);
        Task UpdateEmployerAsync(Employer employer);
        Task DeleteEmployerAsync(Guid id);
    }
}
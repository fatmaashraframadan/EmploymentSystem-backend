using Domain.ApplicationAggregate;

namespace Infrastructure.Interfaces
{
    public interface IApplicationRepository
    {
        Task<Domain.ApplicationAggregate.Application> GetApplicationByIdAsync(Guid id);
        Task<Guid> AddApplicationAsync(Domain.ApplicationAggregate.Application application);
        Task UpdateApplicationAsync(Domain.ApplicationAggregate.Application application);
        Task DeleteApplicationAsync(Guid id);
    }
}
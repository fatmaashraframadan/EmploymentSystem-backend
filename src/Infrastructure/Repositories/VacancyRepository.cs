using Domain.VacancyAggregate;
using EmploymentSystem_backend.Infrastructure.Interfaces;

namespace EmploymentSystem_backend.src.Infrastructure.Repositories
{
    public class VacancyRepository : IVacancyRepository
    {
        public Task AddVacancyAsync(Vacancy vacancy)
        {
            throw new NotImplementedException();
        }

        public Task DeleteVacancyAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Vacancy>> GetAllVacanciesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Vacancy> GetVacancyByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateVacancyAsync(Vacancy vacancy)
        {
            throw new NotImplementedException();
        }
    }
}
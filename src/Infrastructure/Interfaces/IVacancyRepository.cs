using Domain.VacancyAggregate;

namespace Infrastructure.Interfaces
{
    public interface IVacancyRepository
    {
        Task<IEnumerable<Vacancy>> GetAllVacanciesAsync();
        Task<Vacancy> GetVacancyByIdAsync(Guid id);
        Task AddVacancyAsync(Vacancy vacancy);
        Task UpdateVacancyAsync(Vacancy vacancy);
        Task DeleteVacancyAsync(Guid id);
    }
}
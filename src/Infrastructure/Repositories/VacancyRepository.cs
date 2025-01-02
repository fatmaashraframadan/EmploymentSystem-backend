using AspNetCore.Identity.Database;
using Domain.VacancyAggregate;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class VacancyRepository : IVacancyRepository
    {
        private readonly ApplicationDbContext _context;
        public VacancyRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddVacancyAsync(Vacancy vacancy)
        {
            _context.Vacancies.Add(vacancy);
            await _context.SaveChangesAsync();
        }

        public async Task DeactivateVacancy(Guid id)
        {
            var vacancy = await _context.Vacancies.FindAsync(id);
            if (vacancy != null)
            {
                vacancy.IsExpired = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Vacancy>> GetAllVacanciesAsync()
        {
            return await _context.Vacancies.ToListAsync();
        }

        public async Task<Vacancy> GetVacancyByIdAsync(Guid id)
        {
            return await _context.Vacancies.FindAsync(id);
        }

        public async Task UpdateVacancyAsync(Vacancy vacancy)
        {
            _context.Vacancies.Update(vacancy);
            await _context.SaveChangesAsync();
        }
    }
}
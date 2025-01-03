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

        public async Task AddAsync(Vacancy vacancy)
        {
            await _context.Vacancies.AddAsync(vacancy);
            await _context.SaveChangesAsync();
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

        public Task<Vacancy> GetVacancy(Guid id)
        {
            return _context.Vacancies.FirstOrDefaultAsync(v => v.Id == id);
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

        public async Task<IEnumerable<string>> GetApplicantsByVacancyIdAsync(Guid vacancyId)
        {
            var applicantsIds = await _context.Applications
                .Where(a => a.VacancyId == vacancyId)
                .Select(a => a.ApplicantId)
                .ToListAsync();

            return await _context.Applicants
                .Where(u => applicantsIds.Contains(new Guid(u.Id)))
                .Select(u => u.Email)
                .ToListAsync();
        }
    }
}
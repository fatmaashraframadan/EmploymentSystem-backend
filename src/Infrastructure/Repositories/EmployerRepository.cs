using AspNetCore.Identity.Database;
using Domain.EmployerAggregate;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class EmployerRepository : IEmployerRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddEmployerAsync(Employer employer)
        {
            await _context.Employers.AddAsync(employer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployerAsync(Guid id)
        {
            var employer = await _context.Employers.FindAsync(id);
            if (employer != null)
            {
                _context.Employers.Remove(employer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Employer>> GetAllEmployersAsync()
        {
            return await _context.Employers.ToListAsync();
        }

        public async Task<Employer> GetEmployerByIdAsync(Guid id)
        {
            return await _context.Employers.FindAsync(id);
        }

        public async Task UpdateEmployerAsync(Employer employer)
        {
            _context.Employers.Update(employer);
            await _context.SaveChangesAsync();
        }
    }
}
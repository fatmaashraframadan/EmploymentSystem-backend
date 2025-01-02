using AspNetCore.Identity.Database;
using Domain.ApplicantAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ApplicantRepository : IApplicantRepository
    {
        private readonly ApplicationDbContext _context;
        public ApplicantRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Applicant> AddApplicantAsync(Applicant applicant)
        {
            _context.Applicants.Add(applicant);
            await _context.SaveChangesAsync();
            return applicant;
        }

        public async Task DeleteApplicantAsync(Guid id)
        {
            var applicant = await _context.Applicants.FindAsync(id);
            if (applicant != null)
            {
                _context.Applicants.Remove(applicant);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Applicant> GetApplicant(Guid id)
        {
            return await _context.Applicants.FindAsync(id);
        }

        public async Task<Applicant> GetApplicantByIdAsync(Guid id)
        {
            return await _context.Applicants.FindAsync(id);
        }

        public async Task<IEnumerable<Applicant>> GetApplicantsAsync()
        {
            return await _context.Applicants.ToListAsync();
        }

        public async Task<Applicant> UpdateApplicantAsync(Applicant applicant)
        {
            _context.Applicants.Update(applicant);
            await _context.SaveChangesAsync();
            return applicant;
        }
    }
}
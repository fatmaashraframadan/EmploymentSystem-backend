using AspNetCore.Identity.Database;
using Domain.ApplicationAggregate;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ApplicationDbContext _context;
        public ApplicationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> AddApplicationAsync(Domain.ApplicationAggregate.Application application)
        {
            await _context.AddAsync(application);
            await _context.SaveChangesAsync();
            return application.Id;
        }

        public async Task DeleteApplicationAsync(Guid id)
        {
            var application = await _context.Applications.FindAsync(id);
            if (application != null)
            {
                _context.Applications.Remove(application);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Domain.ApplicationAggregate.Application> GetApplicationByIdAsync(Guid id)
        {
            return await _context.Applications.FindAsync(id);
        }

        public async Task UpdateApplicationAsync(Domain.ApplicationAggregate.Application application)
        {
            _context.Applications.Update(application);
            await _context.SaveChangesAsync();
        }
    }
}
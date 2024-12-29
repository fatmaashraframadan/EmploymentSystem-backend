using Domain.ApplicationAggregate;
using Domain.UserAggregate;
using Domain.VacancyAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class DbConfig : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Employer> Recruiters { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Application> Applications { get; set; }

        public DbConfig(DbContextOptions<DbConfig> options) : base(options)
        {
        }

    }
}

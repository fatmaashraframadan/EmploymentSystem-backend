using Domain.ApplicationAggregate;
using Domain.UserAggregate;
using Domain.VacancyAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Configure SQL Server as the database provider
                optionsBuilder.UseSqlServer(
      "Server=localhost;Database=EmploymentSystem1;User Id=sa;Password=YourPassword123;Trusted_Connection=False;Encrypt=True;TrustServerCertificate=true"
                    );
            }
        }
    }
}


namespace Infrastructure
{
    public class DbConfigFactory : IDesignTimeDbContextFactory<DbConfig>
    {
        public DbConfig CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbConfig>();
            optionsBuilder.UseSqlServer(
                    "Server=localhost;Database=EmploymentSystem1;User Id=sa;Password=YourPassword123;Trusted_Connection=False;Encrypt=True;TrustServerCertificate=true"
            );

            return new DbConfig(optionsBuilder.Options);
        }
    }
}

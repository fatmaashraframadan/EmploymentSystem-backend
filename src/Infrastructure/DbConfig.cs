using Domain.ApplicantAggregate;
using Domain.ApplicationAggregate;
using Domain.EmployerAggregate;
using Domain.VacancyAggregate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Identity.Database;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Applicant> Applicants { get; set; }
    public DbSet<Employer> Employers { get; set; }
    public DbSet<Domain.ApplicationAggregate.Application> Applications { get; set; }
    public DbSet<Vacancy> Vacancies { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.HasDefaultSchema("identity");
    }

}
public class RoleSeeder
{
    public static void SeedRoles(IServiceProvider serviceProvider, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        var roles = new List<string> { "EMPLOYER", "APPLICANT" };

        foreach (var role in roles)
        {
            var roleExist = roleManager.RoleExistsAsync(role).Result;
            if (!roleExist)
            {
                var roleResult = roleManager.CreateAsync(new IdentityRole(role)).Result;
            }
        }
    }
}


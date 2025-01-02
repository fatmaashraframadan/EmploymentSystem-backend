using Microsoft.AspNetCore.Identity;

namespace Domain.EmployerAggregate
{
    public class Employer : IdentityUser
    {
        public string CompanyName { get; set; }

        public Employer()
        {
        }
        public Employer(string companyName)
        {
            CompanyName = companyName;
        }
    }
}
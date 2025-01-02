using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class Roles : IdentityRole
    {
        public string Employer { set; get; } = "EMPLOYER";
        public string Applicant { set; get; } = "APPLICANT";
    }
}
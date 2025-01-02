using Microsoft.AspNetCore.Identity;

namespace Domain.ApplicantAggregate
{
    public class Applicant : IdentityUser
    {
        public string ResumeUrl { get; set; }

        public Applicant() { }
        public Applicant(string resumeUrl)
        {
            ResumeUrl = resumeUrl;
        }
    }
}
namespace Domain.UserAggregate
{
    public class Applicant : User
    {
        public string ResumeUrl { get; set; }

        public Applicant(string firstName, string lastName, string email, string password, UserRole role, string resumeUrl) : base(firstName, lastName, email, password, role)
        {
            ResumeUrl = resumeUrl;
        }

        public void EditCompanyName(string resumeUrl)
        {
            ResumeUrl = resumeUrl;
        }
    }
}
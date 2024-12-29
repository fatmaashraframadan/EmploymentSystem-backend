namespace Domain.UserAggregate
{
    public class Applicant : User
    {
        public string ResumeUrl { get; set; }

        public Applicant(string email, string password, UserRole role, string resumeUrl) : base(email, password, role)
        {
            ResumeUrl = resumeUrl;
        }

        public void EditCompanyName(string resumeUrl)
        {
            ResumeUrl = resumeUrl;
        }
    }
}
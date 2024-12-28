namespace Domain.UserAggregate
{
    public class Employer : User
    {
        public string ResumeUrl { get; set; }

        public Employer(string email, string password, UserRole role, string resumeUrl) : base(email, password, role)
        {
            ResumeUrl = resumeUrl;
        }

        public void EditResumeUrl(string resumeUrl)
        {
            ResumeUrl = resumeUrl;
        }
    }
}
namespace Domain.UserAggregate
{
    public class Employer : User
    {
        public string CompanyName { get; set; }

        public Employer(string email, string password, UserRole role, string companyName) : base(email, password, role)
        {
            CompanyName = companyName;
        }

        public void EditResumeUrl(string companyName)
        {
            CompanyName = companyName;
        }
    }
}
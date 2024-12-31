namespace Domain.UserAggregate
{
    public class Employer : User
    {
        public string CompanyName { get; set; }

        public Employer(string firstName, string lastName, string email, string password, UserRole role, string companyName) : base(firstName, lastName, email, password, role)
        {
            CompanyName = companyName;
        }

        public void EditResumeUrl(string companyName)
        {
            CompanyName = companyName;
        }
    }
}
namespace Domain.UserAggregate
{
    public class Applicant : User
    {
        public string CompanyName { get; set; }

        public Applicant(string email, string password, UserRole role, string companyName) : base(email, password, role)
        {
            CompanyName = companyName;
        }

        public void EditCompanyName(string companyName)
        {
            CompanyName = companyName;
        }
    }
}
namespace Domain.VacancyAggregate
{
    public class Vacancy : Entity
    {
        public Guid EmployerId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; } = "";
        public string Location { get; private set; } = "";
        public int MaxAApplications { get; private set; }
        public int ApplicationsCount { get; private set; } = 0;
        public DateTime ExpiryDate { get; private set; }
        public bool IsExpired => DateTime.Now > ExpiryDate;

        public Vacancy EditEmployerId(Guid employerId)
        {
            EmployerId = employerId;
            return this;
        }

        public Vacancy EditTitle(string title)
        {
            Title = title;
            return this;
        }

        public Vacancy EditDescription(string description)
        {
            Description = description;
            return this;
        }

        public Vacancy EditLocation(string location)
        {
            Location = location;
            return this;
        }

        public Vacancy EditMaxApplications(int maxApplications)
        {
            MaxAApplications = maxApplications;
            return this;
        }

        public Vacancy EditApplicationsCount(int applicationsCount)
        {
            ApplicationsCount = applicationsCount;
            return this;
        }

        public Vacancy EditExpiryDate(DateTime expiryDate)
        {
            ExpiryDate = expiryDate;
            return this;
        }
    }
}
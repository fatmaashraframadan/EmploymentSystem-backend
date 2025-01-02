namespace Domain.VacancyAggregate
{
    public class Vacancy : Entity
    {
        public Guid EmployerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } = "";
        public string Location { get; set; } = "";
        public int MaxAApplications { get; set; }
        public int ApplicationsCount { get; set; } = 0;
        public DateTime ExpiryDate { get; set; }
        public bool IsExpired { set; get; } = false;

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
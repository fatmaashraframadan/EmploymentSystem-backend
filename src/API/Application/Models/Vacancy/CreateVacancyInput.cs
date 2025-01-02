namespace API.Application.Models.Vacancy
{
    public class CreateVacancyInput
    {
        public Guid EmployerId { get; set; } // get it from jst
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int MaxApplications { get; set; }
        public int ApplicationsCount { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
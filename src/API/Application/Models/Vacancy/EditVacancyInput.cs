namespace API.Application.Models.Vacancy
{
    public class EditVacancyInput
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int MaxAApplications { get; set; }
        public int ApplicationsCount { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
namespace Domain.ApplicationAggregate
{
    public class Application : Entity
    {
        public Guid VacancyId { get; private set; }
        public Guid ApplicantId { get; private set; }
        public string Status { get; private set; }
        public string Message { get; private set; }


        public Application(Guid vacancyId, Guid applicantId, string status, string message)
        {
            vacancyId = vacancyId;
            ApplicantId = applicantId;
            Status = status;
            Message = message;
            this.UpdatedAt = DateTime.UtcNow;
        }
        public void UpdateStatus(string status)
        {
            Status = status;
            this.UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateMessage(string message)
        {
            Message = message;
            this.UpdatedAt = DateTime.UtcNow;
        }
    }
}
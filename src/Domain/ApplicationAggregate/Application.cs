namespace Domain.ApplicationAggregate
{
    public class Application : Entity
    {
        public Guid VacationId { get; private set; }
        public Guid ApplicantId { get; private set; }
        public string Status { get; private set; }
        public string Message { get; private set; }


        public Application(Guid vacationId, Guid applicantId, string status, string message)
        {
            VacationId = vacationId;
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
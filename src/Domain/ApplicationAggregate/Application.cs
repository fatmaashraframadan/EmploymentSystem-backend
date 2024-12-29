namespace Domain.ApplicationAggregate
{
    public class Application
    {
        public Guid VacationId { get; private set; }
        public Guid ApplicantId { get; private set; }
        public string Status { get; private set; }
        public string Message { get; private set; }
        public DateTime UpdatedAt { get; private set; }


        public void UpdateStatus(string status)
        {
            Status = status;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateMessage(string message)
        {
            Message = message;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
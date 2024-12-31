namespace Domain
{
    public class Entity
    {
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; } = DateTime.Now;
        //TODO may remove and add for each one
        public DateTime? UpdatedAt { get; private set; }
    }
}
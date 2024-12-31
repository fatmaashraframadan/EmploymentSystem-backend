namespace Domain
{
    public class Entity
    {
        public Guid Id { get; private set; }= Guid.NewGuid();
        public DateTime CreatedAt { get; } = DateTime.Now;
        //TODO may remove and add for each one
        public DateTime? UpdatedAt { get; set; }
    }
}
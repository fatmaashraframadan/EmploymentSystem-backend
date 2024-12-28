namespace Domain
{
    public class Entity
    {
        public int Id { get; private set; }
        public DateTime CreatedAt { get; } = DateTime.Now;
    }
}
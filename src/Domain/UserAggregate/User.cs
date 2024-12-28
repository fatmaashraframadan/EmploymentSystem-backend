namespace Domain.UserAggregate
{
    public class User : Entity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public string Email { get; private set; }
        public string Password { get; private set; }
        public UserRole Role { get; private set; }

        public User(string email, string password, UserRole role)
        {
            Email = email;
            Password = password;
            Role = role;
        }

        public void ChangeRole(UserRole role)
        {
            Role = role;
        }
    }
}
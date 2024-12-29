namespace API.Application.Models.User
{
    public class CreateEmployerInput : CreateUserInput
    {
        public string CompanyName { get; set; }
    }
}
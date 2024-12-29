namespace API.Application.Models.User
{
    public class CreateApplicantInput : CreateUserInput
    {
        public string ResumeUrl { get; set; }
    }
}
using API.Application.Models.User;

namespace EmploymentSystem.API.Application.Models.User.Applicant
{
    public class EditEmployerInput : EditUserInput
    {
        public string ResumeUrl { get; set; }
    }
}
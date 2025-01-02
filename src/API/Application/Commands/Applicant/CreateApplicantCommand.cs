using API.Application.Models.User;
using MediatR;

namespace API.Application.Commands.Applicant
{
    public class CreateApplicantCommand : IRequest<Guid>
    {
        public CreateUserInput Input { get; set; }

        public CreateApplicantCommand(CreateUserInput input)
        {
            Input = input;
        }
    }
}
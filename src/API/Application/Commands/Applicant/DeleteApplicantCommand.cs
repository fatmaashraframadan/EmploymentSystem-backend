using API.Application.Models.User.Applicant;
using MediatR;

namespace API.Application.Commands.Applicant
{
    public class DeleteApplicantCommand : IRequest<bool>
    {
        public DeleteUserInput Input { get; set; }

        public DeleteApplicantCommand(DeleteUserInput input)
        {
            Input = input;
        }
    }
}
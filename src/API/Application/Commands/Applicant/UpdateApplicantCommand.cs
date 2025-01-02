using MediatR;
using API.Application.Models.User;

namespace API.Application.Commands.Applicant
{
    public class UpdateApplicantCommand : IRequest<bool>
    {
        public EditUserInput Input { get; set; }

        public UpdateApplicantCommand(EditUserInput input)
        {
            Input = input;
        }
    }
}
using API.Application.Models.User.Applicant;
using MediatR;

namespace API.Application.Commands.Employer
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public DeleteUserInput Input { get; set; }

        public DeleteUserCommand(DeleteUserInput input)
        {
            Input = input;
        }
    }
}
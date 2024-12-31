using API.Application.Models.User;
using MediatR;

namespace API.Application.Commands.User
{
    public class SignUpCommand : IRequest<Guid>
    {
        public CreateUserInput Input { get; set; }

        public SignUpCommand(CreateUserInput input)
        {
            Input = input;
        }
    }
}
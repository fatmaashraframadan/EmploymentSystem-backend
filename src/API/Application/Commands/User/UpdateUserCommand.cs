using MediatR;
using API.Application.Models.User;

namespace API.Application.Commands.User
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public EditUserInput Input { get; set; }

        public UpdateUserCommand(EditUserInput input)
        {
            Input = input;
        }
    }
}
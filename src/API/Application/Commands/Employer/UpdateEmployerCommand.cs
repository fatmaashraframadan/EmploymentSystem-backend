using MediatR;
using API.Application.Models.User;

namespace API.Application.Commands.Employer
{
    public class UpdateEmployerCommand : IRequest<bool>
    {
        public EditUserInput Input { get; set; }

        public UpdateEmployerCommand(EditUserInput input)
        {
            Input = input;
        }
    }
}
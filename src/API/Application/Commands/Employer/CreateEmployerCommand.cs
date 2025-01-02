using API.Application.Models.User;
using MediatR;

namespace API.Application.Commands.Employer
{
    public class CreateEmployerCommand : IRequest<Guid>
    {
        public CreateUserInput Input { get; set; }

        public CreateEmployerCommand(CreateUserInput input)
        {
            Input = input;
        }
    }
}
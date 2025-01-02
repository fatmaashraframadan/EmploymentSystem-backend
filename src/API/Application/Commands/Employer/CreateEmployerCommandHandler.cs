using MediatR;

namespace API.Application.Commands.Employer
{
    public class CreateEmployerCommandHandler : IRequestHandler<CreateEmployerCommand, Guid>
    {
    /*  private readonly IUserRepository _userRepository;
        public CreateEmployerCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }*/
        public async Task<Guid> Handle(CreateEmployerCommand request, CancellationToken cancellationToken)
        {
           /*ar user = new Domain.UserAggregate.User(
                request.Input.FirstName, request.Input.LastName,
                request.Input.Email, request.Input.Password, request.Input.Role);

            var addedUser = await _userRepository.AddUser(user);

            return addedUser.Id;*/
            return Guid.NewGuid();
        }
    }
}
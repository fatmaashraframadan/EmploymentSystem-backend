using Infrastructure.Interfaces;
using MediatR;

namespace API.Application.Commands.User
{
    public class SignUpCommandHandler : IRequestHandler<SignUpCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        public SignUpCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Guid> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            var user = new Domain.UserAggregate.User(
                request.Input.FirstName, request.Input.LastName,
                request.Input.Email, request.Input.Password, request.Input.Role);

            var addedUser = await _userRepository.AddUser(user);

            return addedUser.Id;
        }
    }
}
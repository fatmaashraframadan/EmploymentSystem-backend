using API.Application.Commands.Employer;
using MediatR;

namespace API.Application.Commands.Employer
{

    public class UpdateUserCommandHandler : IRequestHandler<UpdateEmployerCommand, bool>
    {
       /* private readonly IUserRepository _userRepository;
        private readonly ILogger<UpdateUserCommandHandler> _logger;

        public UpdateUserCommandHandler(IUserRepository userRepository, ILogger<UpdateUserCommandHandler> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }*/

        public async Task<bool> Handle(UpdateEmployerCommand request, CancellationToken cancellationToken)
        {
           /* var user = await _userRepository.GetUserByEmail(request.Input.Email);

            if (user == null)
            {
                _logger.LogError("User not found : {email}", request.Input.Email);
                return false;
            }

            user.UpdateUser(request.Input.FirstName, request.Input.LastName, request.Input.Email);

            await _userRepository.UpdateUser(user);*/
            return true;
        }
    }
}
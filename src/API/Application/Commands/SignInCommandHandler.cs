
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace API.Application.Commands
{
    public class SignInCommandHandler : IRequestHandler<SignInCommand, SignInResult>
    {
     /*   private readonly IUserRepository _userRepository;
        private readonly ILogger<SignInCommandHandler> _logger;

        public SignInCommandHandler(IUserRepository userRepository, ILogger<SignInCommandHandler> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }*/

        public async Task<SignInResult> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
         /*   var user = await _userRepository.GetUserByEmail(request.Email);

            if (user == null)
            {
                _logger.LogError("Invalid login attempt for email: {Email}", request.Email);

                return new SignInResult { Succeeded = false, ErrorMsg = "Invalid login attempt" };
            }
*/
            return new SignInResult { Succeeded = true };
        }
    }
}
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace API.Application.Commands.Applicant
{

    public class UpdateApplicantCommandHandler : IRequestHandler<UpdateApplicantCommand, bool>
    {
        /*
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UpdateApplicantCommandHandler> _logger;

        public UpdateApplicantCommandHandler(IUserRepository userRepository, ILogger<UpdateApplicantCommandHandler> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }
*/
        public async Task<bool> Handle(UpdateApplicantCommand request, CancellationToken cancellationToken)
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
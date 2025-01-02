using Infrastructure.Interfaces;
using MediatR;

namespace API.Application.Commands.Applicant
{
    public class CreateApplicantCommandHandler : IRequestHandler<CreateApplicantCommand, Guid>
    {
  /*      private readonly IUserRepository _userRepository;
        public CreateApplicantCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }*/
        public async Task<Guid> Handle(CreateApplicantCommand request, CancellationToken cancellationToken)
        {
           /* var user = new Domain.UserAggregate.User(
                request.Input.FirstName, request.Input.LastName,
                request.Input.Email, request.Input.Password, request.Input.Role);

            var addedUser = await _userRepository.AddUser(user);

            return addedUser.Id;*/
            return Guid.NewGuid();
        }
    }
}
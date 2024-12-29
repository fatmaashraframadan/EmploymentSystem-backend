using MediatR;

namespace API.Application.Commands.Vacancy
{
    public class DeactivateVacancyCommandHandler : IRequestHandler<DeactivateVacancyCommand, bool>
    {
        //  private readonly 

        public DeactivateVacancyCommandHandler()
        {

        }

        public Task<bool> Handle(DeactivateVacancyCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
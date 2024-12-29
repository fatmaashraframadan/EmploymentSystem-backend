using MediatR;

namespace API.Application.Commands.Vacancy
{
    public class CreateVacancyCommandHandler : IRequestHandler<CreateVacancyCommand, int>
    {
        public CreateVacancyCommandHandler() { }
        public Task<int> Handle(CreateVacancyCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
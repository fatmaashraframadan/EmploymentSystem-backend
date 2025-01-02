using API.Application.Queries.Vacancy;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.Queries.Vacancy
{

    public class GetVacanciesQueryHandler : IRequestHandler<GetVacanciesQuery, IEnumerable<Domain.VacancyAggregate.Vacancy>>
    {
        private readonly IVacancyRepository _vacancyRepository;

        public GetVacanciesQueryHandler(IVacancyRepository vacancyRepository)
        {
            _vacancyRepository = vacancyRepository;
        }

        public async Task<IEnumerable<Domain.VacancyAggregate.Vacancy>> Handle(GetVacanciesQuery request, CancellationToken cancellationToken)
        {
            return await _vacancyRepository.GetAllVacanciesAsync();
        }
    }
}
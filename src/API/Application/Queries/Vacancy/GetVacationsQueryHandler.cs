using API.Application.Queries.Vacancy;
using Infrastructure.Interfaces;
using MediatR;

namespace EmploymentSystem.Application.Queries.Vacancy
{

    public class GetVacationsQueryHandler : IRequestHandler<GetVacationsQuery, IEnumerable<Domain.VacancyAggregate.Vacancy>>
    {
        private readonly IVacancyRepository _vacancyRepository;

        public GetVacationsQueryHandler(IVacancyRepository vacancyRepository)
        {
            _vacancyRepository = vacancyRepository;
        }

        public async Task<IEnumerable<Domain.VacancyAggregate.Vacancy>> Handle(GetVacationsQuery request, CancellationToken cancellationToken)
        {
            return await _vacancyRepository.GetAllVacanciesAsync();
        }
    }
}
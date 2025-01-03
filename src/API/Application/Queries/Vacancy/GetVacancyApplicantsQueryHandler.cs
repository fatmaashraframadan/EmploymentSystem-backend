using API.Application.Queries.Vacancy;
using Infrastructure.Repositories;
using MediatR;

namespace API.Application.Queries
{

    public class GetVacancyApplicantsQueryHandler : IRequestHandler<GetVacancyApplicantsQuery, List<string>>
    {
        private readonly VacancyRepository _vacancyRepository;

        public GetVacancyApplicantsQueryHandler(VacancyRepository vacancyRepository)
        {
            _vacancyRepository = vacancyRepository;
        }
        async Task<List<string>> IRequestHandler<GetVacancyApplicantsQuery, List<string>>.Handle(GetVacancyApplicantsQuery request, CancellationToken cancellationToken)
        {
            var applicants = await _vacancyRepository.GetApplicantsByVacancyIdAsync(request.VacancyId);

            return applicants.ToList();
        }
    }
}
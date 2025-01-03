using MediatR;

namespace API.Application.Queries.Vacancy
{
    public class GetVacancyApplicantsQuery : IRequest<List<string>>
    {
        public Guid VacancyId { get; set; }

        public GetVacancyApplicantsQuery(Guid vacancyId)
        {
            VacancyId = vacancyId;
        }
    }
}
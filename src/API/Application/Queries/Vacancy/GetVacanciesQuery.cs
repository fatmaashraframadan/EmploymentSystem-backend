using MediatR;

namespace API.Application.Queries.Vacancy
{
    public class GetVacanciesQuery : IRequest<IEnumerable<Domain.VacancyAggregate.Vacancy>>
    {
        public GetVacanciesQuery()
        {
        }
    }
}
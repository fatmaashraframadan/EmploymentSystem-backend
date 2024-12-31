using MediatR;

namespace API.Application.Queries.Vacancy
{
    public class GetVacationsQuery : IRequest<IEnumerable<Domain.VacancyAggregate.Vacancy>>
    {
        public GetVacationsQuery()
        {
        }
    }
}
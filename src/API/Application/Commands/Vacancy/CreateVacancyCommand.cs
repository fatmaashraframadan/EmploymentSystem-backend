using API.Application.Models.Vacancy;
using MediatR;

namespace API.Application.Commands.Vacancy
{
    public class CreateVacancyCommand : IRequest<int>
    {
        public CreateVacancyInput Input { get; set; }
        public Guid EmployerId { get; set; }
        public CreateVacancyCommand(CreateVacancyInput input, Guid employerId)
        {
            Input = input;
            EmployerId = employerId;
        }
    }
}
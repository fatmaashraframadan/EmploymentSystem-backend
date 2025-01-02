using API.Application.Models.Vacancy;
using MediatR;

namespace API.Application.Commands.Vacancy
{
    public class CreateVacancyCommand : IRequest<Guid>
    {
        public CreateVacancyInput Input { get; set; }
        public CreateVacancyCommand(CreateVacancyInput input)
        {
            Input = input;
        }
    }
}
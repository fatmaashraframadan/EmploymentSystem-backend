using API.Application.Models.Vacancy;
using MediatR;

namespace API.Application.Commands.Vacancy
{
    public class DeactivateVacancyCommand : IRequest<bool>
    {
        public DeactivateVacancyInput Input{ get; set; }
        public DeactivateVacancyCommand(DeactivateVacancyInput input)
        {
            Input = input;
        }
    }
}
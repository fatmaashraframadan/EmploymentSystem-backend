using MediatR;

namespace API.Application.Commands
{
    public class CreateVacancyCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
    }
}
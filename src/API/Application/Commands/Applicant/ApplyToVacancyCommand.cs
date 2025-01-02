using MediatR;

namespace API.Application.Commands.Applicant
{
    public class ApplyToVacancyCommand : IRequest<Guid>
    {
        public Guid VacancyId { get; set; }
        public Guid ApplicantId { get; set; }
        public string Message { get; set; }
    }
}
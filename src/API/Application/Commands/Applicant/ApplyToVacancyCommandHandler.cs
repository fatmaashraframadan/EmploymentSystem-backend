using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using MediatR;

namespace API.Application.Commands.Applicant
{
    public class ApplyToVacancyCommandHandler : IRequestHandler<ApplyToVacancyCommand, Guid>
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IVacancyRepository _vacancyRepository;
        private readonly IApplicantRepository _applicantRepository;

        public ApplyToVacancyCommandHandler(IApplicationRepository applicationRepository, IVacancyRepository vacancyRepository, IApplicantRepository applicantRepository)
        {
            _applicationRepository = applicationRepository;
            _vacancyRepository = vacancyRepository;
            _applicantRepository = applicantRepository;
        }
        async Task<Guid> IRequestHandler<ApplyToVacancyCommand, Guid>.Handle(ApplyToVacancyCommand request, CancellationToken cancellationToken)
        {
            var vacancy = await _vacancyRepository.GetVacancy(request.VacancyId);
            var applicant = await _applicantRepository.GetApplicant(request.ApplicantId);

            if (vacancy == null || applicant == null)
            {
                throw new Exception("Vacancy or applicant not found");
            }

            var application = new Domain.ApplicationAggregate.Application(request.VacancyId, request.ApplicantId, "Pending", request.Message);
            var applicationId = await _applicationRepository.AddApplicationAsync(application);

            return applicationId;
        }
    }
}
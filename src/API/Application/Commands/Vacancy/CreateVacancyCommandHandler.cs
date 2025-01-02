using Infrastructure.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace API.Application.Commands.Vacancy
{
    public class CreateVacancyCommandHandler : IRequestHandler<CreateVacancyCommand, Guid>
    {
        private readonly IVacancyRepository _vacancyRepository;
        private readonly ILogger<CreateVacancyCommandHandler> _logger;

        public CreateVacancyCommandHandler(IVacancyRepository vacancyRepository, ILogger<CreateVacancyCommandHandler> logger)
        {
            _vacancyRepository = vacancyRepository;
            _logger = logger;
        }
        public async Task<Guid> Handle(CreateVacancyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var vacancy = new Domain.VacancyAggregate.Vacancy
                {
                    EmployerId = request.Input.EmployerId,
                    Title = request.Input.Title,
                    Description = request.Input.Description,
                    Location = request.Input.Location,
                    MaxAApplications = request.Input.MaxApplications,
                    ExpiryDate = request.Input.ExpiryDate
                };

                await _vacancyRepository.AddAsync(vacancy);

                _logger.LogInformation("Vacancy created successfully with ID: {VacancyId}", vacancy.Id);

                return vacancy.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating vacancy");
                throw;
            }
        }
    }
}
using API.Application.Models.Vacancy;
using Infrastructure.Interfaces;
using MediatR;
using System;

namespace EmploymentSystem.Application.Commands.Vacancy
{
    public class EditVacancyCommand : IRequest<bool>
    {
        public EditVacancyInput Input { get; }

        public EditVacancyCommand(EditVacancyInput input)
        {
            Input = input;
        }
    }

    public class EditVacancyCommandHandler : IRequestHandler<EditVacancyCommand, bool>
    {
        private readonly IVacancyRepository _vacancyRepository;

        public EditVacancyCommandHandler(IVacancyRepository vacancyRepository)
        {
            _vacancyRepository = vacancyRepository;
        }

        public async Task<bool> Handle(EditVacancyCommand request, CancellationToken cancellationToken)
        {
            var vacancy = await _vacancyRepository.GetVacancy(request.Input.Id);
            if (vacancy == null)
            {
                return false;
            }

            vacancy.Title = request.Input.Title;
            vacancy.Description = request.Input.Description;
            vacancy.ExpiryDate = request.Input.ExpiryDate;
            vacancy.Location = request.Input.Location;
            vacancy.MaxAApplications = request.Input.MaxAApplications;

            await _vacancyRepository.UpdateVacancyAsync(vacancy);
            return true;
        }
    }
}
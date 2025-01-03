using API.Application.Commands.Vacancy;
using API.Application.Models.Vacancy;
using API.Application.Queries.Vacancy;
using AspNetCore.Identity.Database;
using EmploymentSystem.Application.Commands.Vacancy;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class VacancyController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _context;

        public VacancyController(IMediator mediator, ApplicationDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        [HttpPost]
        [Route("create-vacancy")]
        [Authorize(Roles = "EMPLOYER")]
        public async Task<IActionResult> CreateVacancy([FromBody] CreateVacancyInput input)
        {
            var command = new CreateVacancyCommand(input);
            var vacancyId = await _mediator.Send(command);

            return Ok(vacancyId);
        }

        [HttpPut]
        [Route("update-vacancy")]
        [Authorize]
        public async Task<IActionResult> UpdateVacancy([FromBody] EditVacancyInput input)
        {
            var command = new EditVacancyCommand(input);
            var vacancyId = await _mediator.Send(command);

            return Ok(vacancyId);
        }

        [HttpDelete]
        [Route("deactivate-vacancy")]
        [Authorize]
        public async Task<IActionResult> DeactivateVacancy([FromBody] DeactivateVacancyInput input)
        {
            var command = new DeactivateVacancyCommand(input);
            var vacancyId = await _mediator.Send(command);

            return Ok(vacancyId);
        }

        [HttpGet]
        [Route("get-vacancies")]
        [Authorize]
        public async Task<IActionResult> GetAllVacancies()
        {
            var query = new GetVacanciesQuery();
            var vacancies = await _mediator.Send(query);

            return Ok(vacancies);
        }
        
        [HttpGet]
        [Route("get-vacancy/{vacancyId}")]
        [Authorize]
        public async Task<IActionResult> GetVacancyById(Guid vacancyId)
        {
            var vacancy = await _context.Vacancies.FindAsync(vacancyId);

            return Ok(vacancy);
        }

        [HttpGet]
        [Route("get-applicants-by-vacancy/{vacancyId}")]
        [Authorize(Roles = "EMPLOYER")]
        public async Task<IActionResult> GetApplicantsByVacancyId(Guid vacancyId)
        {
            var query = new GetVacancyApplicantsQuery(vacancyId);
            var applicants = await _mediator.Send(query);

            return Ok(applicants);
        }
    }
}
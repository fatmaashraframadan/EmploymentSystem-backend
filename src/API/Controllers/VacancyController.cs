using System.Security.Claims;
using API.Application.Commands.Vacancy;
using API.Application.Models.Vacancy;
using API.Authorization;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;

namespace API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class VacancyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VacancyController(IMediator mediator)
        {
            _mediator = mediator;
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
        public async Task<IActionResult> UpdateVacancy([FromBody] string command)//UpdateVacancyCommand command)
        {
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
        [Route("get-vacancy")]
        [Authorize]
        public async Task<IActionResult> GetVacancy([FromBody] string query)//GetVacancyQuery query)
        {
            var vacancy = await _mediator.Send(query);
            return Ok(vacancy);
        }
    }
}
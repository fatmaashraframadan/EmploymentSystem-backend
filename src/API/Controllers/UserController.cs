using API.Application.Commands.User;
using API.Application.Models.User;
using API.Application.Models.User.Applicant;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserInput input)
        {
            var command = new SignUpCommand(input);
            var UserId = await _mediator.Send(command);
            return Ok(UserId);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Login([FromBody] string email, string password)
        {
            var command = new SignInCommand(email, password);
            var UserId = await _mediator.Send(command);
            return Ok(UserId);
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteUserInput input)
        {
            var command = new DeleteUserCommand(input);
            var UserId = await _mediator.Send(command);
            return Ok(UserId);
        }
    }
}
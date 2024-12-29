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
        public async Task<IActionResult> CreateUser([FromBody] string command)//CreateUserCommand command)
        {
            var UserId = await _mediator.Send(command);
            return Ok(UserId);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateUser([FromBody] string command)//UpdateUserCommand command)
        {
            var UserId = await _mediator.Send(command);
            return Ok(UserId);
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteUser([FromBody] string command)//DeleteUserCommand command)
        {
            var UserId = await _mediator.Send(command);
            return Ok(UserId);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Login([FromBody] string query)//GetUserQuery query)
        {
            var user = await _mediator.Send(query);
            return Ok(user);
        }
    }
}
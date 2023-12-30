using MediatR;
using Microsoft.AspNetCore.Mvc;
using YetDit.Application.Features.Commands.AppUser.CreateUser;

namespace YetDit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateUserCommandRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}

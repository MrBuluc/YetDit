using MediatR;
using Microsoft.AspNetCore.Mvc;
using YetDit.Application.Features.Queries.Post.GetAllPost;

namespace YetDit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllPostQueryRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}

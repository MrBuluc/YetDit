using MediatR;
using Microsoft.AspNetCore.Mvc;
using YetDit.Application.Features.Commands.Post.CreatePost;
using YetDit.Application.Features.Queries.Post.GetAllPost;
using YetDit.Application.Features.Queries.Post.GetByIdPost;
using System.IdentityModel.Tokens.Jwt;
using YetDit.Application.Features.Commands.Post.UpdatePost;
using YetDit.Application.Features.Commands.Post.RemovePost;
using YetDit.Application.Features.Commands.Post.DecrementUpVoteCountPost;
using YetDit.Application.Features.Commands.Post.IncrementUpVoteCount;

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

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllPosts([FromQuery] GetAllPostQueryRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetByIdPost([FromRoute] GetByIdPostQueryRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreatePost(CreatePostCommandRequest request, [FromHeader] string accessToken)
        {
            request.Claim = new JwtSecurityToken(accessToken).Claims.First();
            return Ok(await _mediator.Send(request));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdatePost(UpdatePostCommandRequest request, [FromHeader] string accessToken)
        {
            request.Claim = new JwtSecurityToken(accessToken).Claims.First();
            return Ok(await _mediator.Send(request));
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> DeletePost([FromRoute] RemovePostCommandRequest request, [FromHeader] string accessToken)
        {
            request.Claim = new JwtSecurityToken(accessToken).Claims.First();
            return Ok(await _mediator.Send(request));
        }

        [HttpPut("[action]/{Id}")]
        public async Task<IActionResult> DecrementUpVoteCountPost([FromRoute]DecrementUpVoteCountPostCommandRequest request, [FromHeader] string accessToken)
        {
            request.Claim = new JwtSecurityToken (accessToken).Claims.First();
            return Ok(await _mediator.Send(request));
        }

        [HttpPut("[action]/{Id}")]
        public async Task<IActionResult> IncrementUpVoteCountPost([FromRoute] string Id, [FromHeader] string accessToken)
        {
            var _request = new IncrementUpVoteCountPostCommandRequest
            {
                Id = Id,
                UserId = new JwtSecurityToken(accessToken).Claims.First(c => c.Type == "sub").Value // Assuming "sub" contains the user ID in the token
            };

            var result = await _mediator.Send(_request);
            return Ok(result);
        }
    }
}

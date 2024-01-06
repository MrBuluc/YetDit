using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using YetDit.Application.Features.Commands.Comment.CreateComment;
using YetDit.Application.Features.Commands.Comment.DecrementUpVoteCountComment;
using YetDit.Application.Features.Commands.Comment.IncrementUpVoteCountComment;
using YetDit.Application.Features.Commands.Comment.RemoveComment;
using YetDit.Application.Features.Commands.Comment.UpdateComment;
using YetDit.Application.Features.Queries.Comment.GetAllComments;
using YetDit.Application.Features.Queries.Comment.GetByIdComment;

namespace YetDit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllComments([FromQuery] GetAllCommentsQueryRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetByIdComment([FromRoute] GetByIdCommentQueryRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateComment(CreateCommentCommandRequest request, [FromHeader] string accessToken)
        {
            request.Claim = new JwtSecurityToken(accessToken).Claims.First();
            return Ok(await _mediator.Send(request));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateComment(UpdateCommentCommandRequest request, [FromHeader] string accessToken)
        {
            request.Claim = new JwtSecurityToken(accessToken).Claims.First();
            return Ok(await _mediator.Send(request));
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> DeleteComment([FromRoute] RemoveCommentCommandRequest request, [FromHeader] string accessToken)
        {
            request.Claim = new JwtSecurityToken(accessToken).Claims.First();
            return Ok(await _mediator.Send(request));
        }

        [HttpPut("[action]/{Id}")]
        public async Task<IActionResult> DecrementUpVoteCountComment([FromRoute] DecrementUpVoteCountCommentCommandRequest request, [FromHeader] string accessToken)
        {
            request.Claim = new JwtSecurityToken(accessToken).Claims.First();
            return Ok(await _mediator.Send(request));
        }

        [HttpPut("[action]/{Id}")]
        public async Task<IActionResult> IncrementUpVoteCountComment([FromRoute] IncrementUpVoteCountCommentCommandRequest request, [FromHeader] string accessToken)
        {
            request.Claim = new JwtSecurityToken(accessToken).Claims.First();
            return Ok(await _mediator.Send(request));
        }
    }
}
